using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ExerciceL3
{
    public partial class frmClients : Form
    {
        public frmClients()
        {
            InitializeComponent();
            SetupContextMenuMembre();
        }
        OleDbConnection conn = new OleDbConnection();
        private ContextMenuStrip contextMenu;   
     

        private void SetupContextMenuMembre()
        {
            contextMenu = new ContextMenuStrip();

            var deleteMenuItem = new ToolStripMenuItem("Effacer ce client");
            deleteMenuItem.Click += DeleteMenuItem_Click;
            contextMenu.Items.Add(deleteMenuItem);
            
        }
        private async void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            

            var selectedRow = dataGridViewClients.SelectedRows[0];
            
        }
        //void commandeZetu(string requetteYetu) {

        //    if (conn.State != ConnectionState.Open)
        //    {
        //        conn.Open();
        //    }
        //    OleDbCommand cmd = new OleDbCommand();
        //    //cmd.CommandText = @"INSERT INTO Article (code,descri,pu)VALUES(" + txtCode.Text + ",'" + txtDescr.Text + "','" + txtPU.Text + "')";
        //    cmd.CommandText = requetteYetu;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = conn;
        //    cmd.ExecuteNonQuery();
        //    if (conn.State != ConnectionState.Closed)
        //    {
        //        conn.Close();
        //    }
        //}


        void commandeZetu(string requetteYetu, string messageSucces)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = requetteYetu;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            int lignesAffectees = cmd.ExecuteNonQuery();

            // Condition : si au moins une ligne est insérée/modifiée
            if (lignesAffectees > 0)
            {
                MessageBox.Show(
                    messageSucces
                );
            }

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }


        private void frmClients_Load(object sender, EventArgs e)
        {
            ////try
            ////{
            ////    //conn.ConnectionString = @"Provider=SQLOLEDB;Data Source=; Initial Catalog=Boutique;User ID=sa; password=1234;Persist Security Info=false";

            ////    conn.ConnectionString =
            ////    @"Provider=SQLOLEDB;
            ////      Data Source=DESKTOP-5ILRABH;
            ////      Initial Catalog=GestionBoutique;
            ////      Integrated Security=SSPI;
            ////      Persist Security Info=False;";

            ////    conn.Open();


            ////}
            ////catch
            ////{

            ////    MessageBox.Show(" Erreur de connexion à la base de données");
            ////}
             Afficher();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        Connexion connexion = new Connexion();

        private void button1_Click(object sender, EventArgs e)
        {
            //commandeZetu("INSERT INTO Clients(Nom,Adresse) VALUES('"+txtNom.Text+"','"+txtAdress.Text+"')","Enregistrer avec Succes");
            Connexion cn = new Connexion();
            cn.ExecuterCommande("INSERT INTO Clients(Nom,Adresse) VALUES('" + txtNom.Text + "','" + txtAdress.Text + "')", "Enregistrer avec Succes");
            Afficher();

        }

        void Afficher()
        {
            OleDbConnection con = connexion.GetConnexion();

            string req = "SELECT * FROM Clients";
            OleDbCommand cmd = new OleDbCommand(req, con);
            
            OleDbDataReader reader = cmd.ExecuteReader();

            reader.Read();


            dataGridViewClients.Rows.Clear();

            while (reader.Read())
            {
                dataGridViewClients.Rows.Add(
                    reader[0].ToString(), // Colonne 1
                    reader[1].ToString(), // Colonne 2
                    reader[2].ToString()  // Colonne 3
                );
            }

            reader.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            commandeZetu("DELETE FROM Clients WHERE IdClient=1","Suppression réussie");
        }

        private void dataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewClients.SelectedRows[0];
                txtNom.Text = selectedRow.Cells[0].Value.ToString();
                txtAdress.Text = selectedRow.Cells[1].Value.ToString();
                
            }
        }

        private void dataGridViewClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewClients.SelectedRows[0];
                txtNom.Text = selectedRow.Cells[0].Value.ToString();
                txtAdress.Text = selectedRow.Cells[1].Value.ToString();

            } 
        }
    }
}
