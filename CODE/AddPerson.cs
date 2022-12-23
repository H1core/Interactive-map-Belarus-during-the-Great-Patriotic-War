using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace Проект
{
    public partial class AddPerson : Form
    {
        private string curpath;
        private List<TextBox> L = new List<TextBox>();
        public AddPerson()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            List<Rayon> r = SerializedClass.RayonList;
            foreach (Rayon rr in r)
            {
                comboBox1.Items.Add(rr.name);
            }
            comboBox1.Items.Add("Невядома");
            foreach (var k in Controls.OfType<TextBox>())
                L.Add(k);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog k = new OpenFileDialog();
            k.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (k.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Фото добавлено!");
                curpath = k.FileName;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < L.Count(); i++)
            {
                if (String.IsNullOrEmpty(L[i].Text) == true)
                {
                    MessageBox.Show("Не заполнены все поля");
                    return;
                }
            }
            if(String.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Описание не заполнено");
                return;
            }
            Person AddPers = new Person();
            for (int i = 0; i < L.Count(); i++)
            {
                if (L[i].TabIndex == 0)
                {
                    AddPers.name = L[i].Text;
                }
                else if (L[i].TabIndex == 1)
                {
                    AddPers.type = L[i].Text;
                }
                L[i].Text = "";
            }
            //AddPers.start = monthCalendar1.
            String sd = monthCalendar1.SelectionStart.ToShortDateString().ToString();
            string month = FUNCTIONS.Months[Convert.ToInt16(sd[3].ToString() + sd[4].ToString()) -1 ];
            AddPers.start = Convert.ToString((sd[0] - '0') * 10 + (sd[1]-'0')) + " " + month + " " + sd[6] + sd[7] + sd[8] + sd[9];
            AddPers.id = SerializedClass.PersonList.Count() + 1;
            AddPers.descp = richTextBox1.Text;
            if (comboBox1.SelectedItem == "Невядома")
                AddPers.Loc = new Point(0, 0);
            else
            {
                Rayon k = SerializedClass.RayonList.Find(Rayon => Rayon.id == (comboBox1.SelectedIndex) + 1);
                AddPers.Loc = k.Center;
            }
            if (String.IsNullOrEmpty(curpath) == false)
            {
                string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + "/PictureSources");
                string NameImg = "/" + AddPers.name + Convert.ToString(AddPers.id);
                Bitmap img = new Bitmap(curpath);
                curpath = Path.Combine(path + NameImg);
                img.Save(curpath);
                AddPers.imagepath = Path.Combine("/PictureSources" + NameImg);
            }

            MessageBox.Show("Операция выполнена");
            SerializedClass.PersonList.Add(AddPers);
            SerializedClass.SerializePerson();
            if (!FUNCTIONS.lb.Items.Contains(AddPers.type))
                FUNCTIONS.lb.Items.Add(AddPers.type);
        }

    }
}
