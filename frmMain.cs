using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ExerciceL3
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        // Variable qui garde la référence du formulaire actuellement affiché
        // dans le panneau central
        private Form activeForm = null;

        // Méthode qui permet d'afficher un formulaire enfant
        // dans le panneau central (pnlCentraleFrmmain)
        private void callMultiForm(Form chilForm)
        {
            // Si un formulaire est déjà ouvert dans le panneau,
            // on le ferme avant d'en afficher un autre
            if (activeForm != null)
                activeForm.Close();

            // Le nouveau formulaire devient le formulaire actif
            activeForm = chilForm;

            // Indique que le formulaire ne sera pas affiché
            // comme une fenêtre indépendante
            chilForm.TopLevel = false;

            // Suppression de la bordure du formulaire
            // pour qu'il s'intègre dans le panneau
            chilForm.FormBorderStyle = FormBorderStyle.None;

            // Le formulaire occupe tout l'espace du panneau central
            chilForm.Dock = DockStyle.Fill;

            // Ajout du formulaire dans le panneau central
            pnlCentraleFrmmain.Controls.Add(chilForm);

            // Stockage du formulaire dans la propriété Tag du panneau
            pnlCentraleFrmmain.Tag = chilForm;

            // Le formulaire est placé au premier plan
            chilForm.BringToFront();

            // Affichage du formulaire
            chilForm.Show();
        }

        // Méthode appelée lorsqu'on veut afficher le formulaire des clients
        private void call_client()
        {
            // Cette méthode permet d'afficher le formulaire "frmClients"
            // une seule fois (éviter les doublons)
            try
            {
                // Vérifie si le formulaire frmClients n'est pas déjà ouvert
                if (!frmClients.IsFormOpen(typeof(frmClients)))
                {
                    // Si le formulaire n'est pas ouvert,
                    // on l'affiche dans le panneau central
                    callMultiForm(new frmClients());
                }
                else
                {
                    // Si le formulaire est déjà ouvert,
                    // on ne fait rien
                }
            }
            catch
            {
                // Capture silencieuse des erreurs
                // (non recommandée en production)
            }
        }

        private void call_produits()
        {
            //fonction executer lorsqu'on veut faire afficher un frm specifique et ça une selle fois
            try
            {
                if (!frmProduits.IsFormOpen(typeof(frmProduits)))
                {
                    //code pur repatrier la frm concerner dans le pnlCentral
                    callMultiForm(new frmProduits());
                    //...
                }
                else
                {
                    //on ne fait rien
                }
            }
            catch { }
        }
        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmClients frmClients = new frmClients();//Inctatiotion de la calsse
            ////frmClients c'est le nom de l'instance qu'on appel encore objet
            //frmClients.Show();
            //this.Hide();

            call_client();


        }

        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_produits();
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

        private void venteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vente vente = new Vente();
            vente.Show();
        }

        private void pnlCentraleFrmmain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
