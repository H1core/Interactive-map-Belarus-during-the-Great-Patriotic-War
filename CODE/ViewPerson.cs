using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace Проект
{
    public partial class ViewPerson : Form
    {
        public ViewPerson(Person p)
        {
            InitializeComponent();
            label2.Text = p.name;
            label6.Text = p.start + "год";
            richTextBox1.Text = p.descp;
            if (p.imagepath != null) pictureBox1.Image = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + p.imagepath));
            else Width = 270;
        }

    }
}
