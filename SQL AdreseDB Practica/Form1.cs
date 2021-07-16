using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SQL_AdreseDB_Practica.Adrese;

namespace SQL_AdreseDB_Practica
{
    public partial class Home : Form
    {
        AdreseDBDataContext adreseContext;
        public Home()
        {
            InitializeComponent();
            adreseContext = new AdreseDBDataContext();
        }
        
        private string comandaPersoane()
        {
            string com = "SELECT * FROM PersoaneTable";
            return com;
        }

        private string comandaAdrese()
        {
            string com = "SELECT * FROM AdreseTable";
            return com;
        }

        private bool uniqueIdPersoana(int idc)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DVF30NR\\SQLEXPRESS;Initial Catalog=AdreseDB;Integrated Security=True"))
            {
                connection.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter(comandaPersoane(), connection);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);

                foreach (DataRow dtRow in dataTable.Rows)
                    if (dtRow[0].ToString() == idc.ToString())
                        return false;

            }
            return true;
        }

        private bool uniqueIdAdrese(int idc)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DVF30NR\\SQLEXPRESS;Initial Catalog=AdreseDB;Integrated Security=True"))
            {
                connection.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter(comandaAdrese(), connection);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);

                foreach (DataRow dtRow in dataTable.Rows)
                    if (dtRow[0].ToString() == idc.ToString())
                        return false;

            }
            return true;
        }

        public void SalvareAdrese(SqlConnection connection, int IdPersoana, TextBox Municipiu, TextBox Judet, TextBox Oras, TextBox Comuna, TextBox Sat, TextBox Strada,
        TextBox Numar, TextBox Bloc, TextBox Scara)
        {
            Random random = new Random();
            int idA;
            do
            {
                idA = random.Next(0, 9999);
            } while (uniqueIdPersoana(idA) == false);

            SqlCommand command = new SqlCommand("insert into AdreseTable values (@IdAdresa, @Municipiu, @Judet, @Oras, @Comuna, @Sat, @Strada, @Numar, @Bloc, @Scara, @IdPersoana)", connection);
            command.Parameters.AddWithValue("@IdAdresa", idA);
            command.Parameters.AddWithValue("@Municipiu", Municipiu.Text.Trim());
            command.Parameters.AddWithValue("@Judet", Judet.Text.Trim());
            command.Parameters.AddWithValue("@Oras", Oras.Text.Trim());
            command.Parameters.AddWithValue("@Comuna", Comuna.Text.Trim());
            command.Parameters.AddWithValue("@Sat", Sat.Text.Trim());
            command.Parameters.AddWithValue("@Strada", Strada.Text.Trim());
            command.Parameters.AddWithValue("@Numar", Numar.Text.Trim());
            command.Parameters.AddWithValue("@Bloc", Bloc.Text.Trim());
            command.Parameters.AddWithValue("@Scara", Scara.Text.Trim());
            command.Parameters.AddWithValue("@IdPersoana", IdPersoana);
            connection.Open();
            int i = command.ExecuteNonQuery();
            if (i != 0)
                MessageBox.Show("Este bine");
            connection.Close();
        }

        private void afisareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DVF30NR\\SQLEXPRESS;Initial Catalog=AdreseDB;Integrated Security=True"))
            {
                connection.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter(comandaPersoane(), connection);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);

                dataGrid.DataSource = dataTable;
            }
        }

        private void modificareToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stergereToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adaugareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DVF30NR\\SQLEXPRESS;Initial Catalog=AdreseDB;Integrated Security=True");

            SqlCommand command = new SqlCommand("insert into PersoaneTable values (@IdPersoana, @Nume, @Prenume, @Sex, @DataNasteri, @CNP)", connection);
            Random random = new Random();
            int idP;
            do
            {
                idP = random.Next(0,9999);
            } while (uniqueIdPersoana(idP) == false);

            command.Parameters.AddWithValue("@IdPersoana", idP);
            command.Parameters.AddWithValue("@Nume", txtNume.Text.Trim());
            command.Parameters.AddWithValue("@Prenume", txtPrenume.Text.Trim());
            command.Parameters.AddWithValue("@Sex", txtSex.Text.Trim());
            command.Parameters.AddWithValue("@DataNasteri", txtDataNasterii.Text.Trim());
            command.Parameters.AddWithValue("@CNP", txtCNP.Text.Trim());

            connection.Open();
            int i = command.ExecuteNonQuery();

            connection.Close();
            if (i != 0)
                MessageBox.Show("Date salvate");
            else
                MessageBox.Show("Eroare");
            SalvareAdrese(connection, idP, txtMunicipiuD, txtJudetD, txtOrasD, txtComunaD, txtSatD, txtStradaD, txtNumarD, txtBlocD, txtScaraD);
            SalvareAdrese(connection, idP, txtMunicipiuN, txtJudetN, txtOrasN, txtComunaN, txtSatN, txtStradaN, txtNumarN, txtBlocN, txtScaraN);
            SalvareAdrese(connection, idP, txtMunicipiu1, txtJudet1, txtOras1, txtComuna1, txtSat1, txtStrada1, txtNumar1, txtBloc1, txtScara1);
            SalvareAdrese(connection, idP, txtMunicipiu2, txtJudet2, txtOras2, txtComuna2, txtSat2, txtStrada2, txtNumar2, txtBloc2, txtScara2);
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            StringBuilder obj = new StringBuilder();
            
            txtNume.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
            txtPrenume.Text = dataGrid.CurrentRow.Cells[2].Value.ToString();
            txtSex.Text = dataGrid.CurrentRow.Cells[3].Value.ToString();
            txtDataNasterii.Text = dataGrid.CurrentRow.Cells[4].Value.ToString();
            txtCNP.Text = dataGrid.CurrentRow.Cells[5].Value.ToString();

            var info = (from AdreseTable in adreseContext.AdreseTables
                        where Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString()) == AdreseTable.IdPersoana
                        select AdreseTable).ToList();
            //foreach(int cod in info)
            //{
            //    var adresaCautata = (from AdreseTable in adreseContext.AdreseTables
            //                         where cod == AdreseTable.IdAdresa
            //                         select AdreseTable).FirstOrDefault();
            //    MessageBox.Show(adresaCautata.ToString());

            //}
            DataTable tabelA = new DataTable();
            
            MessageBox.Show(info.ToString());
        }
        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
