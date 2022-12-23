using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace Проект
{
    public partial class CheckPersonList : Form
    {
        private int Space = 75;

        private void ButtonClck(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Person p = (Person)b.Tag;
            try
            {
                if (String.IsNullOrEmpty(p.imagepath) == false) File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + p.imagepath));
                SerializedClass.PersonList.Remove(p);
                SerializedClass.SerializePerson();
                Controls.Clear();
                Init();
            }
            catch
            {
                MessageBox.Show("Удаление не выполнено");
            }
        }
        private void MesButClk(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            MessageBox.Show((String)b.Tag);
        }

        public CheckPersonList()
        {
            Init();
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.Sizable;
            //if ((Space + 20) * SerializedClass.PersonList.Count() + 20 < 450) Height = ((Space + 20) * SerializedClass.PersonList.Count()) + 20;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        void Init()
        {
            int k = 0;
            foreach (Person p in SerializedClass.PersonList)
            {
                Panel pnl = new Panel()
                {
                    Location = new Point() { X = 20, Y = Space * k + 20 },
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightGray,
                    Height = 60,
                    Width = 710,
                };
                Label lbl = new Label()
                {
                    Location = new Point() { X = 0, Y = 10 },
                    Height = 20,
                    Width = 500,
                    Text = "Имя: " + p.name,
                };
                Button b = new Button()
                {
                    Location = new Point() { X = 650, Y = 3 },
                    Height = 52,
                    Width = 52,
                    BackColor = Color.LightGray,
                    Image = Properties.Resources.delete,
                };
                b.Tag = p;
                b.FlatAppearance.BorderSize = 0;
                b.FlatAppearance.MouseDownBackColor = Color.Transparent;
                b.FlatAppearance.MouseOverBackColor = Color.Transparent;
                b.FlatStyle = FlatStyle.Flat;
                b.Click += ButtonClck;
                pnl.Controls.Add(lbl);
                pnl.Controls.Add(b);
                b = new Button()
                {
                    Tag = p.descp,
                    Location = new Point { X = 580, Y = 3 },
                    Height = 52,
                    Width = 52,
                    BackColor = Color.LightGray,
                    Image = Properties.Resources.faqs,
                };
                b.Click += MesButClk;
                b.FlatAppearance.BorderSize = 0;
                b.FlatAppearance.MouseDownBackColor = Color.Transparent;
                b.FlatAppearance.MouseOverBackColor = Color.Transparent;
                b.FlatStyle = FlatStyle.Flat;
                lbl = new Label()
                {
                    Location = new Point() { X = 0, Y = 30 },
                    Height = 30,
                    Width = 500,
                    Text = "Дата: " + p.start,
                };
                pnl.Controls.Add(lbl);
                pnl.Controls.Add(b);
                Controls.Add(pnl);
                k++;
            }
        }
    }
}
