namespace JTTT
{
    partial class View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.jesliTextBox1 = new System.Windows.Forms.TextBox();
            this.confirm = new System.Windows.Forms.Button();
            this.actionSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.jesliTextBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Debug = new System.Windows.Forms.RichTextBox();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.jesli = new System.Windows.Forms.Label();
            this.to = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Perform = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Desirialize = new System.Windows.Forms.Button();
            this.Serialize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jesliTextBox1
            // 
            this.jesliTextBox1.Location = new System.Drawing.Point(30, 72);
            this.jesliTextBox1.Name = "jesliTextBox1";
            this.jesliTextBox1.Size = new System.Drawing.Size(352, 20);
            this.jesliTextBox1.TabIndex = 0;
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(398, 79);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(118, 44);
            this.confirm.TabIndex = 1;
            this.confirm.Text = "Zatwierdż!";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // actionSelect
            // 
            this.actionSelect.FormattingEnabled = true;
            this.actionSelect.Items.AddRange(new object[] {
            "Szukaj po tagach",
            "Szukaj w .txt",
            "Sprawdź pogodę we Wrocławiu"});
            this.actionSelect.Location = new System.Drawing.Point(33, 12);
            this.actionSelect.Name = "actionSelect";
            this.actionSelect.Size = new System.Drawing.Size(244, 21);
            this.actionSelect.TabIndex = 2;
            this.actionSelect.SelectedIndexChanged += new System.EventHandler(this.actionSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = " ";
            // 
            // jesliTextBox2
            // 
            this.jesliTextBox2.Location = new System.Drawing.Point(30, 111);
            this.jesliTextBox2.Name = "jesliTextBox2";
            this.jesliTextBox2.Size = new System.Drawing.Size(352, 20);
            this.jesliTextBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(398, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 44);
            this.button2.TabIndex = 8;
            this.button2.Text = "Dodaj do listy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Debug
            // 
            this.Debug.Location = new System.Drawing.Point(30, 238);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(349, 96);
            this.Debug.TabIndex = 9;
            this.Debug.Text = "";
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(30, 195);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(349, 20);
            this.toTextBox.TabIndex = 10;
            // 
            // jesli
            // 
            this.jesli.AutoSize = true;
            this.jesli.Location = new System.Drawing.Point(46, 36);
            this.jesli.Name = "jesli";
            this.jesli.Size = new System.Drawing.Size(30, 13);
            this.jesli.TabIndex = 11;
            this.jesli.Text = "Jeśli:";
            // 
            // to
            // 
            this.to.AutoSize = true;
            this.to.Location = new System.Drawing.Point(46, 147);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(23, 13);
            this.to.TabIndex = 12;
            this.to.Text = "To:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Wyślij email"});
            this.comboBox1.Location = new System.Drawing.Point(33, 161);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(244, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(548, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(361, 95);
            this.listBox1.TabIndex = 14;
            // 
            // Perform
            // 
            this.Perform.Location = new System.Drawing.Point(548, 132);
            this.Perform.Name = "Perform";
            this.Perform.Size = new System.Drawing.Size(137, 50);
            this.Perform.TabIndex = 15;
            this.Perform.Text = "Wykonaj!";
            this.Perform.UseVisualStyleBackColor = true;
            this.Perform.Click += new System.EventHandler(this.Perform_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(691, 132);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(137, 49);
            this.Clear.TabIndex = 16;
            this.Clear.Text = "Czyść";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Desirialize
            // 
            this.Desirialize.Location = new System.Drawing.Point(834, 132);
            this.Desirialize.Name = "Desirialize";
            this.Desirialize.Size = new System.Drawing.Size(75, 23);
            this.Desirialize.TabIndex = 17;
            this.Desirialize.Text = "Desirialize";
            this.Desirialize.UseVisualStyleBackColor = true;
            // 
            // Serialize
            // 
            this.Serialize.Location = new System.Drawing.Point(834, 161);
            this.Serialize.Name = "Serialize";
            this.Serialize.Size = new System.Drawing.Size(75, 23);
            this.Serialize.TabIndex = 18;
            this.Serialize.Text = "Serialize";
            this.Serialize.UseVisualStyleBackColor = true;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 346);
            this.Controls.Add(this.Serialize);
            this.Controls.Add(this.Desirialize);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Perform);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.to);
            this.Controls.Add(this.jesli);
            this.Controls.Add(this.toTextBox);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.jesliTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.actionSelect);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.jesliTextBox1);
            this.Name = "View";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox jesliTextBox1;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.ComboBox actionSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox jesliTextBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox Debug;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.Label jesli;
        private System.Windows.Forms.Label to;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Perform;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Desirialize;
        private System.Windows.Forms.Button Serialize;
    }
}

