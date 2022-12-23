using System.Drawing;

namespace Проект
{
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };
    public class Person
    {
        public int id;
        public string name;
        public string type;
        public string start;
        public string descp;
        public Point Loc;
        public string imagepath;
    }
    public class Rayon
    {
        public int id;
        public Point Center;
        public string name;
        public string Zahv, Osvb;
        public static void Pressed()
        {
            // Form f = new Form2();
            // f.Show();
        }
    }
}
