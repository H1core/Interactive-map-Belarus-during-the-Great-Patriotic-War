using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Проект
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            
            SerializedClass.DeSerializePerson();
            List <Person> LP = SerializedClass.PersonList;
            FUNCTIONS.lb.Items.Clear();
            foreach(Person p in LP)
            {
                string t = p.type;
                if (!FUNCTIONS.lb.Items.Contains(t))
                {
                    FUNCTIONS.lb.Items.Add(t);
                    FUNCTIONS.lb.SetItemChecked(FUNCTIONS.lb.Items.Count - 1, true);
                }
            }
            InitializeComponent();
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }
        void DD(object sender, EventArgs e)
        {
            Rayon.Pressed();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OSNOVA.OSN.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form SUS = new CheckPersonList();
            SUS.ShowDialog();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string s = "Создатель программы : Ковш Павел Вячеславович \n\n\nИсчточник информации : ВЕЛИКАЯ ОТЕЧЕСТВЕННАЯ ВОЙНА СОВЕТСКОГО НАРОДА(в контексте Второй мировой войны) \n\n\nСсылка на источник : https://adu.by/images/2020/11/VOV-sovet-naroda-Kovalenya.pdf";
            MessageBox.Show(s);
        }
    }
}
