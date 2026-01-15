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
    public partial class Vente : Form
    {
        public Vente()
        {
            InitializeComponent();
        }
        Connexion connexion = new Connexion();
        void ChargerClientsDansComboBox()
        {
             OleDbConnection con = connexion.GetConnexion();

            string req = "SELECT IdClient, Nom FROM Clients";
            OleDbCommand cmd = new OleDbCommand(req, con);

            OleDbDataReader reader = cmd.ExecuteReader();

            comboBoxClients.Items.Clear();

            while (reader.Read())
            {
                // Texte affiché dans le ComboBox
                comboBoxClients.Items.Add(
                   reader["IdClient"].ToString()+" "  +  reader["Nom"].ToString()
                );
            }

            reader.Close();
        }
        void ChargerProduitsDansComboBox()
        {
            OleDbConnection con = connexion.GetConnexion();

            string req = "SELECT IdProduit, Description FROM Produits";
            OleDbCommand cmd = new OleDbCommand(req, con);

            OleDbDataReader reader = cmd.ExecuteReader();

            comboBoxProduits.Items.Clear();

            while (reader.Read())
            {
                // Texte affiché dans le ComboBox
                comboBoxProduits.Items.Add(
                   reader["IdProduit"].ToString()+"  " + reader["Description"].ToString()
                );
            }

            reader.Close();
        }

        private void Vente_Load(object sender, EventArgs e)
        {
            ChargerProduitsDansComboBox();
            ChargerClientsDansComboBox();
            Afficher();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewVentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public string PrendrePremierMot(string txt)
        {
            string[] mots = txt.Split(' ');
            return mots[0];
        }


        private void button2_Click(object sender, EventArgs e)
        {

            string produits = "";
            foreach (DataGridViewRow row in dataGridViewPannier.Rows)
            {
                // Ignorer la dernière ligne vide
                if (row.IsNewRow)
                    continue;

                string idProduit = row.Cells[0].Value.ToString();
                string qtte = row.Cells[2].Value.ToString();
                string pvu = row.Cells[3].Value.ToString();
                string ptt = row.Cells[4].Value.ToString();

                produits += idProduit + "," + qtte + "," + pvu + ";";
            }

            //MessageBox.Show(produits);

            connexion.InsererVenteAvecPlusieursProduitsSimple(
                int.Parse(PrendrePremierMot(comboBoxClients.Text)), 
                produits,"Vente enregistrer avec succes");

            Afficher();

            dataGridViewPannier.Rows.Clear();










            //connexion.InsererVenteAvecPlusieursProduitsSimple(
            //    int.Parse(PrendrePremierMot(comboBoxClients.Text)),
            //    produits,
            //    "Vente enregistrée avec succès"
            //);
        }
        void Afficher()
        {
            OleDbConnection con = connexion.GetConnexion();

            string req = "SELECT v.IdVente,c.Nom,v.DateVente FROM Vente as v INNER JOIN Clients as c ON c.IdClient=v.IdClient ";
            OleDbCommand cmd = new OleDbCommand(req, con);

            OleDbDataReader reader = cmd.ExecuteReader();

            reader.Read();


            dataGridViewVentes.Rows.Clear();

            while (reader.Read())
            {
                dataGridViewVentes.Rows.Add(
                    reader[0].ToString(), // Colonne 1
                    reader[1].ToString(), // Colonne 2
                    reader[2].ToString()  // Colonne 3
                );
            }

            reader.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(PrendrePremierMot(comboBoxProduits.Text));
            dataGridViewPannier.Rows.Add(PrendrePremierMot( comboBoxProduits.Text),comboBoxProduits.Text,txtPVU.Text, txtQtte.Text,float.Parse(txtPVU.Text)*float.Parse(txtQtte.Text));
        }
    }
}
