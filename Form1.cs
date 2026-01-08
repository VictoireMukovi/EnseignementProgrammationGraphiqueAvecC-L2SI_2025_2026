using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciceL3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //Type le nom de la variable
        int nbre1, nbre2, res;
        
        private void button1_Click(object sender, EventArgs e)
        {
            nbre1=int.Parse( txtNbr1.Text);
            nbre2 = int.Parse(txtNbr2.Text);



            res = nbre1 + nbre2;
            txtRes.Text=res.ToString();


        }
    }
}
