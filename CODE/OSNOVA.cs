using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Проект
{
    public partial class OSNOVA : Form
    {
        public static Form OSN = new OSNOVA();
        public OSNOVA()
        {
            InitializeComponent();
            FUNCTIONS.Time = 50;
            FUNCTIONS.brstbtn = button7;
            List<Button> k = new List<Button>()
            {
                button1 , button2 , button3 , button4 , button5,
            };

            FUNCTIONS.ButtonList = k;

            for (int i = 0; i < 5; i++)
            {
                FUNCTIONS.ButtonList[i].Click += FUNCTIONS.ButtonMoveClick;
                FUNCTIONS.ButtonList[i].BackColor = Color.Gray;
            }


            Bitmap b;
            b = new Bitmap(pictureBox1.Image);

            b.SetPixel(0, 0, Color.DarkRed);
            FUNCTIONS.R = b.GetPixel(0, 0);
            b.SetPixel(0, 0, Color.LightGray);
            FUNCTIONS.G = b.GetPixel(0, 0);

            string colorcontrol = b.GetPixel(200, 200).ToString();
            Color c = b.GetPixel(200, 200);
            Color cc = b.GetPixel(376, 25);
            int f = 0;
            List<Rayon> NewRayList = new List<Rayon>();
            for (int i = 0; i < b.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    Color ArColor = b.GetPixel(j, i);
                    if (ArColor.ToString() == colorcontrol)b.SetPixel(j, i, Color.DarkRed);
                    else
                    if (ArColor.ToString() == cc.ToString())
                    {
                        b.SetPixel(j, i, Color.DarkRed);
                        f++;
                        Rayon addrayon = new Rayon() { id = f, Center = new Point() { X = j, Y = i, }, };
                        NewRayList.Add(addrayon);
                        SerializedClass.RayonList.Add(addrayon);

                    }
                }
            }

            READRAYONS();
            f = 0;
            foreach (Rayon r in SerializedClass.RayonList)
            {
                f++;
                Label lbl = new Label()
                {
                    Location = new Point() { X = r.Center.X, Y = r.Center.Y },
                    AutoSize = true,
                    BackColor = Color.FromArgb(195,65,65,65),
                    Text =  "*",
                };
                lbl.FlatStyle = FlatStyle.Flat;
                FontFamily fml = new FontFamily("Times New Roman");
                lbl.Font = new Font(fml, 4.5f);
                lbl.ForeColor = Color.White;
                if (FUNCTIONS.BigCity.Contains(r.name))
                {
                    lbl.Tag = 5;
                    lbl.Text = r.name;
                    lbl.Font = new Font(fml, 6.5f);
                    lbl.Location = new Point(lbl.Location.X - 10, lbl.Location.Y);
                }
                lbl.Click += LblClick;
                lbl.Tag = r;
                pictureBox1.Controls.Add(lbl);
                lbl.BringToFront();
            }
            FUNCTIONS.X = pictureBox1;
            pictureBox1.Image = b;
            FUNCTIONS.bb = b;
            FUNCTIONS.l = label1;
            FUNCTIONS.Func();
        }
        private void READRAYONS()
        {
            string filepath = Path.GetFullPath("Doc.txt");
            int k = 0;
            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    if (s == "---")
                    {
                        k++;
                    }
                    else
                    {
                        if (s[0] == 'N' && s[1] == 'a')
                        {
                            if (s.Length > 7) SerializedClass.RayonList[k].name = s.Substring(7);
                        }
                        else
                        {
                            if (s[0] == 'O' && s[1] == 'v')
                            {
                                string ss = s.Substring(7);
                                if (ss[0] > '0' && s[0] < '9' && s[1] == ' ')
                                    ss = '0' + ss;
                                if (s.Length > 7)SerializedClass.RayonList[k].Osvb = ss ;
                            }
                            else if (s[0] == 'Z' && s[1] == 'a')
                            {

                                string ss = s.Substring(7);
                                if (ss[0] > '0' && s[0] < '9' && s[1] == ' ')
                                    ss = '0' + ss;
                                if (s.Length > 7) SerializedClass.RayonList[k].Zahv = ss;
                            }
                        }
                    }
                }
            }
        }
        public void AddComp(Button b)
        {
            this.Controls.Add(b);
        }
        private void LblClick(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            Form Frm = new ShowRayonInfo((Rayon)l.Tag);
            Frm.ShowDialog();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            FUNCTIONS.settings.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach(Control x in pictureBox1.Controls)
            {
                Label l;
                if (x is Label)
                {
                    l = (Label)x;
                    if (l.Visible == true)
                        l.Visible = false;
                    else l.Visible = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FUNCTIONS.brst.ShowDialog();
        }
    }
}