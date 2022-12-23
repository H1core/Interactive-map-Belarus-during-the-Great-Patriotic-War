using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект
{
    public partial class ShowRayonInfo : Form
    {
        public ShowRayonInfo(Rayon r)
        {
            InitializeComponent();
            //label1.Text = Convert.ToString(r.id);
            label2.Text = "Название:" +r.name;
            label3.Text = "Год оккупации:" +r.Zahv;
            label4.Text = "Год освобождения:" +r.Osvb;
        }
    }
}
