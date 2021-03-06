﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Data.Entity;

namespace JTTT
{
    /*ViewModel is bridge beetwen View and Model
    Uses Models to operate on data, and react to events from View
    ViewModel has whole logic of program*/
    public class ViewModel
    {
        private View view;
        private DataModel model;
        Action action; //strategy design pattern
        NotificationMethod notificiation;
        ViewLayout viewlayout;
        Tuple<DataModel, Action, NotificationMethod> tmp;
        public BindingList<Tuple<DataModel, Action, NotificationMethod>> list;
        Log log;



        public ViewModel(View v)
        {
            view = v;
            model = new DataModel();
            action = new ActionNone();
            notificiation = new NotificationNone();
            viewlayout = new ViewLayout(" ", " ", " ", true, false);
            view.changeView(viewlayout);
            list = new BindingList<Tuple<DataModel, Action, NotificationMethod>>();
            view.addSourceToList(list);
            log = new Log("log.log");
            
            using (var db = new ModelContext())
            {
                var query = from b in db.Models
                            orderby b.ModelId
                            select b;
                view.ShowMessageBoxError("Qeuryset"+query.ToString(),"q");
                foreach (var item in query)
                {
                    view.ShowMessageBoxError("Qeuryset" + item.ImgURL, "q");
                    list.Add(new Tuple<DataModel, Action, NotificationMethod>(new DataModel(item.ImgURL, item.Description, item.address), new Action(), new NotificationMethod()));
                }
            }
        }

        ~ViewModel()
        {
            using (var db = new ModelContext())
            {
                foreach (var element in list)
                {
                    Model m = new Model { ImgURL = element.Item1.ImgURL, Description = element.Item1.Description, address = element.Item1.address };
                    db.Models.Add(m);
                }
                db.SaveChanges();
            }
        }

        //Action class is used to store information what should be done and in wich way
        //Also has some information about layout of View - some actions may take less TextBoxes then the others
        public void changeAction(string newAction)
        {
            switch (newAction) //parse string to action
            {
                case "Szukaj po tagach":
                    action = new SearchImageWebSite(log);
                    viewlayout = new ViewLayout("Podaj adres URL:", "Podaj szukany tag", "Podaj maila:", true, true);
                    break;
                case "Szukaj w .txt":
                    action = new SearchTxt();
                    break;
                case "Sprawdź pogodę we Wrocławiu":
                    action = new CheckWeather(log);
                    viewlayout = new ViewLayout("Podaj datę, w której chcesz sprawdzić pogodę w formacie RRRRMMDD"," ", "Podaj maila:", true, false);
                    break;
                default:
                    action = new ActionNone();
                    viewlayout = new ViewLayout(" ", " ", " ", true, false);
                    break;
            }
            view.changeView(viewlayout);
        }

        public void changeNotificationMethod(string newMethod)
        {
            view.ShowDebugMessage(newMethod);
            switch (newMethod)
            {
                case "Wyślij email":
                    notificiation = new NotificationEmail(log);
                    break;
                default:
                    notificiation = new NotificationNone();
                    break;
            }
        }

        public void addToList()
        {
            tmp = new Tuple<DataModel, Action, NotificationMethod>(model, action, notificiation);
            list.Add(tmp);
        }

        public void clear()
        {
            list.Clear();
        }

        //prepere data using avalible Models
        public void getData(string arg1, string arg2, string arg3)
        {
            try
            {
                model = new DataModel(); //action.prepareEmail(arg1, arg2, arg3);
                //workaround - args (strings from text boxes) are stored temporarly, then they are used when we need to notify (send mail or something)
                model.address = arg1;
                model.Description = arg2;
                model.ImgURL = arg3;
            }
            catch(System.ArgumentException exception)
            {
                view.ShowMessageBoxError(exception.Message, "Blad!");
            }
        }

        public string send()
        {
            //hack from getData - part2: based on strings from view stored in model, 
            //create up-to-date model components
            //all of this is to avoid changes in working code, and lack of time of course
            foreach (var element in list)
            {
                DataModel exact = action.prepareEmail(element.Item1.address, element.Item1.Description, element.Item1.ImgURL);
                element.Item1.address = exact.address;
                element.Item1.Description = exact.Description;
                element.Item1.ImgURL = exact.ImgURL;
            }
            try
            {
                var retval = notificiation.notify(list);
                return retval;
            }
            catch (System.FormatException exception)
            {
                view.ShowMessageBoxError(exception.Message+" Wskazówka: po podaniu adresu email naciśnij zatwierdź", "Blad!");
                return null;
            }
            catch (System.ArgumentException exception)
            {
                view.ShowMessageBoxError(exception.Message, "Blad!");
                return null;
            }
        }

        public string serialize()
        {
            string retval = null;

            FileStream fs = new FileStream("serialize.dat", FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();

            retval = "Po serializacji ";

            foreach (var element in list)
            {
                retval += element.ToString();
            }

            bf.Serialize(fs, list);
            fs.Close();

            return retval;
        }

        public string deserialize()
        {
            string retval = null;

            FileStream fs = new FileStream("serialize.dat", FileMode.Open);

            BinaryFormatter bf = new BinaryFormatter();

            var temp = (BindingList<Tuple<DataModel, Action, NotificationMethod>>)bf.Deserialize(fs);

            foreach (var element in temp)
            {
                list.Add(element);
            }

            retval = "Po deserializacji ";

            foreach (var element in list)
            {
                retval += element.ToString();
            }

            fs.Close();

            return retval;
        }
    }
}
