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
    public partial class frmProduits : Form
    {
        public frmProduits()
        {
            InitializeComponent();
        }
        Connexion connexion = new Connexion();
        public static bool IsFormOpen(Type formType)
        {
            return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connexion.ExecuterCommande("INSERT INTO Produits(Description,Prix_unitaire_de_vente) VALUES ("'+tx+'")", "Enregistrement produit effectuée avec succes");
        }

        private void frmProduits_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
