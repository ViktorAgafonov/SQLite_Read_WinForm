using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var dat = new XavisContext();

            var lists = dat.TbModelInfos.ToList();

            foreach (var l in lists)
            {
                switch (l.ModelUid)
                {
                    // hands select MODEL_UID number to "case"..

                    case 25: textBox1.Text = l.ModelName; break;
                    case 26: textBox2.Text = l.ModelName; break;
                    case 27: textBox3.Text = l.ModelName; break;
                    case 28: textBox4.Text = l.ModelName; break;
                }
            }


        }


    }
}