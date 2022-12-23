using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace Проект
{
    public static class FUNCTIONS
    {
        public static List<Rayon> Rayons;
        public static Form settings = new Settings() , brst = new BRESTSKAY_KREPOST();
        public static CheckedListBox lb;
        public static Label l;
        public static List<Button> ButtonList;
        public static int Time, x, y;
        public static bool Reversed = false, PauseBool = true;
        public static Bitmap bb;
        public static PictureBox X;
        public static Color R, G;
        public static string s;
        public static int startday = 20, endday = 9, curday = startday, curyear = 1941;
        public static List<string> BigCity = new List<string>() { "Баранавічы", "Брэст", "Пінск", "Віцебск", "Полацк", "Гомель", "Гродна", "Мiнск", "Бабруйск", "Магілёў", };
        public static Button brstbtn;
        public static int startmonth = 5, endmonth = 4, curmonth = 5;

        public static string[] Months = new string[12] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        public static int[] MonthsDays = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        static void ClearBackColor(Button b)
        {
            for (int i = 0; i < ButtonList.Count(); i++)
            {
                ButtonList[i].BackColor = Color.Gray;
            }
            b.BackColor = Color.Yellow;
        }
        public static void ButtonMoveClick(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;
            
            int val = b.Text.Length;
            if (b.Text == ">" || b.Text == ">>")
            {
                if(Reversed == true)
                {
                    CheckRayonDates(s);
                }
                PauseBool = false;
                Reversed = false;
                Time = 10 * val * val * val * val;
            }
            if (b.Text == "<" || b.Text == "<<")
            {
                if(Reversed == false)
                {
                    CheckRayonDates(s);
                }
                PauseBool = false;
                Reversed = true;
                Time = 10 * val * val * val * val;
            }
            if(b.Text == "I I")
            {
                PauseBool = true;
                Time = 10;
            }
            ClearBackColor(b);
        }




        public static void ReverseColor(Rayon r)
        {
            int startx = r.Center.X;
            int starty = r.Center.Y;
            Rekurskia(startx, starty, bb.GetPixel(startx, starty));
        }




        public static void Rekurskia(int x, int y, Color c)
        {
            Color get = bb.GetPixel(x, y);
            if (get != c)
                return;
            if (c == R)
                bb.SetPixel(x, y, Color.LightGray);
            else bb.SetPixel(x, y, Color.DarkRed);
            Rekurskia(x + 1, y, c);
            Rekurskia(x - 1, y, c);
            Rekurskia(x, y + 1, c);
            Rekurskia(x, y - 1, c);
        }



        private static void ClearDynamicButtons()
        {
            List<Button> DelBList = new List<Button>();
            foreach (Button b in X.Controls.OfType<Button>())
            {
                if ((String)b.Name == "Delete")
                    DelBList.Add(b);
            }
            foreach (Button b in DelBList)
                X.Controls.Remove(b);
        }

        public static void ShowPerson(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Person p = (Person)b.Tag;
            Form ShowPersonInfo = new ViewPerson(p);
            ShowPersonInfo.ShowDialog();
        }
        private static void CheckPersonDates(string s)
        {
            static void GenerateBut(Person p)
            {
                Button b = new Button()
                {
                    Name = "Delete",
                    Tag = p,
                    Height = 26,
                    Width = 26,
                    FlatStyle = FlatStyle.Flat,
                    Image = Properties.Resources.man_user,
                };
                b.FlatAppearance.BorderSize = 0;
                b.FlatAppearance.MouseDownBackColor = Color.Transparent;
                b.FlatAppearance.MouseOverBackColor = Color.Transparent;
                b.BackColor = Color.FromArgb(45, 0, 0, 0);
                b.Location = new Point { X = p.Loc.X - 13, Y = p.Loc.Y - 13};
                b.Click += ShowPerson;
                if (p.type == "Событие")
                    b.Image = Properties.Resources._event;
                OSNOVA.OSN.Controls.Add(b);
                b.Parent = X;
                b.BringToFront();
            }

            List<Person> person = SerializedClass.PersonList.FindAll(Person => Person.start == s);
            {
                if (person != null)
                {
                    bool k = false;
                    SoundPlayer sndplay = new SoundPlayer(Properties.Resources.MESSAGEEVENT);
                    foreach (Person p in person)
                        if (p.start == s && lb.CheckedItems.Contains(p.type))
                        {
                            if (p.Loc == new Point(0, 0))
                            {
                                sndplay.Play();
                                Form ShowPersonInfo = new ViewPerson(p);
                                ShowPersonInfo.ShowDialog();
                                k = true;
                            }
                            else
                            {
                                GenerateBut(p);
                                k = true;
                            }
                        }
                    if (k)
                    {
                        ButtonMoveClick(ButtonList[2], null);
                        sndplay.Play();
                    }
                }
            }
        }
        private static void CheckRayonDates(string curdata)
        {
            List<Rayon> r = SerializedClass.RayonList.FindAll(Rayon => Rayon.Osvb == curdata);
            List<Rayon> r2 = SerializedClass.RayonList.FindAll(Rayon => Rayon.Zahv == curdata);
            foreach(Rayon ChkR in r)
            {
                ReverseColor(ChkR);
            }
            foreach (Rayon ChkR in r2)
            {
                ReverseColor(ChkR);
            }
            X.Image = bb;
        }

        public async static void Func()
        {
            while (1 == 1)
            {
                await Task.Delay(5000 / (Time + 1)); 
                if (PauseBool == true) continue;
                if ((curday <= startday && curmonth == startmonth && curyear == 1941 && Reversed) || (curday >= endday && curmonth == endmonth && curyear == 1945 && !Reversed))
                {
                    ButtonMoveClick(ButtonList[2], null);
                    continue;
                }
                ClearDynamicButtons();
                if (!Reversed)
                {
                    curday++;
                    if (curday > MonthsDays[curmonth])
                    {
                        curday = 1;
                        curmonth = curmonth + 1;
                        if (curmonth == 12)
                        {
                            curyear++;
                            curmonth = 0;
                        }
                    }
                }
                else
                {
                    curday--;
                    if (curday == 0)
                    {
                        curmonth--;
                        if (curmonth == -1)
                        {
                            curyear--;
                            curmonth = 11;
                        }
                        curday = MonthsDays[curmonth];
                    }
                }
                s = Convert.ToString(curday) + " " + Months[curmonth] + " " + Convert.ToString(curyear);
                CheckRayonDates(s);
                l.Text = Convert.ToString(s + " год");
                CheckPersonDates(s);
                if (s == "23 Июль 1941")
                    RevBrstBtn();

            }
        }
        private static void RevBrstBtn()
        {
            if (brstbtn.Visible == true)
                brstbtn.Visible = false;
            else brstbtn.Visible = true;
        }
    }
}
