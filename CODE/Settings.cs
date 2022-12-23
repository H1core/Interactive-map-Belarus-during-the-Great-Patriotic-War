using System;
using System.Windows.Forms;

namespace Проект
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            FUNCTIONS.lb = checkedListBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form k = new AddPerson();
            k.ShowDialog();
        }

    }
}
