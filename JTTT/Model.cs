using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace JTTT
{
    //single element from BindingList in ViewModel
    public class Model
    {
        public int ModelId { get; set; }
        //DataModel
        public string ImgURL { get; set; }
        public string Description { get; set; }
        public string address { get; set; }
        //Action
        public string action { get; set; }
        //NotificationMethod
        //public System.Type nmtype { get; set; }

        public override string ToString()
        {
            return string.Format("URL {0} {2} ADRESS {1}", ImgURL, address, Description);
        }
    }



    public class ModelContext : DbContext
    {
        public DbSet<Model> Model { get; set; }
    }

}
