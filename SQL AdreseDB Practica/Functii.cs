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
    }
}
