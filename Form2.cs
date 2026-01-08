using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ExerciceL3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection conn=new OleDbConnection();
        //string connStr =
        //    "Provider=SQLOLEDB;" +
        //    "Data Source=DESKTOP-5ILRABH\\SQLEXPRESS;" +
        //    "Initial Catalog=Boutique;" +
        //    "Integrated Security=SSPI;";

        //OleDbConnection conn = null; #reserve@2024=+

        private void button1_Click(object sender, EventArgs e)
        {
            //string nom = Interaction.InputBox(" Entrez votre nom : ");
            try
            {
                //conn.ConnectionString = @"Provider=SQLOLEDB;Data Source=; Initial Catalog=Boutique;User ID=sa; password=1234;Persist Security Info=false";

                conn.ConnectionString =
                @"Provider=SQLOLEDB;
                  Data Source=DESKTOP-5ILRABH;
                  Initial Catalog=Boutique;
                  Integrated Security=SSPI;
                  Persist Security Info=False;";

                conn.Open();   


            } catch {

                MessageBox.Show(" Erreur de connexion à la base de données");
            }   

            ////try
            ////{
            //    conn = new OleDbConnection(connStr);
            //    conn.Open();

            //    //  Condition de vérification réelle
            //    if (conn.State == ConnectionState.Open)
            //    {
            //        MessageBox.Show(" Connexion établie avec succès !");
            //    }
            //    else
            //    {
            //        MessageBox.Show(" La connexion n'est pas ouverte.");
            //    }


            ////}
            ////catch (OleDbException ex)
            ////{
            ////    MessageBox.Show(" Erreur de connexion à la base de données");
            ////    MessageBox.Show(ex.Message);
            ////}
            ///





        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"INSERT INTO Article (code,descri,pu)VALUES("+txtCode.Text+ ",'"+txtDescr.Text+ "','"+txtPU.Text+"')";
            cmd.CommandType = CommandType.Text ;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();


            

            if(conn.State !=ConnectionState.Closed) { 
                
                conn.Close();
            }
        }
    }
}
