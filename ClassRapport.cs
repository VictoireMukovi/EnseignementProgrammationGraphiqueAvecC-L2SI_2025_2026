using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;

namespace ExerciceL3
{
    internal class ClassRapport
    {
        private string Query;


        SqlDataAdapter InvPhisiqueAdapter;

        private ReportDocument document;

        public ClassRapport(string query)
        {
            Query = query;
            document = new ReportDocument();
        }
    }
}
