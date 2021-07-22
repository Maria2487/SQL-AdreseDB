using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using SQL_AdreseDB_Practica.Adrese;

namespace SQL_AdreseDB_Practica
{
    class Functii
    {
        public static int IDAdresaNespecificata = -1;
        AdreseDBDataContext adreseContext;
        public static string comandaPersoane()
        {
            string com = "SELECT * FROM PersoaneTable";
            return com;
        }
        public static string comandaAdrese(int id)
        {
            if (id != IDAdresaNespecificata)
                return "SELECT * FROM AdreseTable WHERE IdPersoana = " + id;
            else
                return "SELECT * FROM AdreseTable";
        }

        public static void afisarePersoane(SqlConnection connection, DataGridView dataGridTable)
        {
            dataGridTable.DataSource = null;
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter(comandaPersoane(), connection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);

            dataGridTable.DataSource = dataTable;
            connection.Close();
        }

        public static bool VerificareCNP(string cnp)
        {
            if (string.IsNullOrEmpty(cnp))
                return false;
            if (cnp.Length == 13)
            {
                foreach (char c in cnp)
                {
                    if (!Char.IsDigit(c))
                    {
                        MessageBox.Show("CNP-ul a fost introdus incorect");
                        return false;
                    }
                }
                AdreseDBDataContext ad = new AdreseDBDataContext();
                var CNPvalid = (from PersoaneTable in ad.PersoaneTables
                                where cnp == PersoaneTable.CNP
                                select PersoaneTable).Any();
                if (CNPvalid)
                {
                    MessageBox.Show("CNP-ul este deja introdus in baza de date");
                    return false;
                }
                return true;
            }
            MessageBox.Show("CNP-ul a fost introdus incorect");
            return false;
        }

        public static bool VerificareSEX(string sex)
        {
            if (sex != "F" && sex != "M" && sex != "O")
            {
                MessageBox.Show("Sexul a fost incorect specificat");
                return false;
            }
                
            return true;
        }

        public static bool VerificareNume(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
                
            foreach (char c in str)
            {
                if (Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
