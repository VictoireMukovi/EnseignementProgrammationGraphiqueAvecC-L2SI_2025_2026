using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciceL3
{
    internal class Connexion
    {      

        private OleDbConnection conn;
        public Connexion()
        {
            conn = new OleDbConnection(
                @"Provider=SQLOLEDB;
                  Data Source=DESKTOP-5ILRABH;
                  Initial Catalog=GestionBoutique;
                  Integrated Security=SSPI;
                  Persist Security Info=False;"
            );
        }



        public OleDbConnection GetConnexion()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            return conn;
        }

        public void FermerConnexion()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }

        public void ExecuterCommande(string requete, string messageSucces)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OleDbCommand cmd = new OleDbCommand(requete, conn);
                cmd.CommandType = CommandType.Text;

                int lignesAffectees = cmd.ExecuteNonQuery();

                if (lignesAffectees > 0)
                {
                    MessageBox.Show(
                        messageSucces,
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch
            {
                MessageBox.Show(
                    "Erreur lors de l'exécution de la commande",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

    }
}
