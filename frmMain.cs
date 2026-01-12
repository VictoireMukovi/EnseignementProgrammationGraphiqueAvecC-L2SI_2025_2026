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

namespace ExerciceL3
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClients frmClients = new frmClients();//Inctatiotion de la calsse
            //frmClients c'est le nom de l'instance qu'on appel encore objet
            frmClients.Show();
            this.Hide();
        }

        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduits frmProduits= new frmProduits();
            frmProduits.Show();
            this.Hide();
        }
        OleDbConnection conn = new OleDbConnection();


        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //conn.ConnectionString = @"Provider=SQLOLEDB;Data Source=; Initial Catalog=Boutique;User ID=sa; password=1234;Persist Security Info=false";

                conn.ConnectionString =
                @"Provider=SQLOLEDB;
                  Data Source=DESKTOP-5ILRABH;
                  Initial Catalog=GestionBoutique;
                  Integrated Security=SSPI;
                  Persist Security Info=False;";

                conn.Open();


            }
            catch
            {

                MessageBox.Show(" Erreur de connexion à la base de données");
            }
        }
    }
}
