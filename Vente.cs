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
                comboBoxClients.Items.Add(
                   reader["IdProduit"].ToString() + reader["Description"].ToString()
                );
            }

            reader.Close();
        }

        private void Vente_Load(object sender, EventArgs e)
        {
            ChargerProduitsDansComboBox();
            ChargerClientsDansComboBox();
        }
    }
}
