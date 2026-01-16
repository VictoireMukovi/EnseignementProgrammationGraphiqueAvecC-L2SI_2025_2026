using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Xml.Linq;

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
        // Adaptateur OLE DB : sert à exécuter une requête SQL
        // et à remplir un DataSet avec les données récupérées
        OleDbDataAdapter InvPhisiqueAdapter;

        // Objet Crystal Report qui contiendra le rapport final
        private ReportDocument document;

        void RapportVente()
        {
            // Requête SQL qui récupère toutes les informations
            // d'une vente précise (IdVente = 3)
            // avec les données du client et des produits vendus
            string req =
                "SELECT " +
                "v.IdVente AS IdVente, " +
                "v.DateVente AS DateVente, " +
                "c.Nom AS Nom, " +
                "p.IdProduit AS IdProduit, " +
                "p.Description AS Designation, " +
                "dv.Qtte AS Qtte, " +
                "dv.PU AS PU, " +
                "dv.Ptt AS PT " +
                "FROM Vente v " +
                "INNER JOIN Clients c ON v.IdClient = c.IdClient " +
                "INNER JOIN DetailsVente dv ON v.IdVente = dv.IdVente " +
                "INNER JOIN Produits p ON dv.IdProduit = p.IdProduit " +
                "WHERE v.IdVente = 3;";

            // Récupération de la connexion à la base de données
            OleDbConnection con = connexion.GetConnexion();

            // Création de l'adaptateur OLE DB avec la requête SQL
            // et la connexion à la base de données
            OleDbDataAdapter InvPhisiqueAdapter =
                new OleDbDataAdapter(req, con);

            // Désactivation du timeout pour les requêtes longues
            InvPhisiqueAdapter.SelectCommand.CommandTimeout = 0;

            // Création du DataSet physique typé
            // (celui utilisé lors de la conception du rapport Crystal)
            DataSet1 ds = new DataSet1();

            // Remplissage de la table "DataTableFacture"
            // avec les données retournées par la requête SQL
            InvPhisiqueAdapter.Fill(ds.DataTableFacture);

            // Instanciation du rapport Crystal
            MonFacture CFACTT = new MonFacture();

            // Association du DataSet au rapport Crystal
            CFACTT.SetDataSource(ds);

            // Création du formulaire contenant le CrystalReportViewer
            FormPetitRapport frm = new FormPetitRapport();

            // Chargement du rapport dans le CrystalReportViewer
            frm.crystalReportViewer1.ReportSource = CFACTT;

            // Affichage du formulaire contenant le rapport
            frm.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            RapportVente();
        }
    }
}
