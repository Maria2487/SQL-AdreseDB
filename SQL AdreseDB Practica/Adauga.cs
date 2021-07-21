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
using static SQL_AdreseDB_Practica.Functii;

namespace SQL_AdreseDB_Practica
{
    public partial class Adauga : Form
    {
        AdreseDBDataContext adreseContext;
        SqlConnection connection;
        public Adauga()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source=DESKTOP-DVF30NR\\SQLEXPRESS;Initial Catalog=AdreseDB;Integrated Security=True");
            adreseContext = new AdreseDBDataContext();
        }

        private bool uniqueIdPersoana(int idc)
        {
            using (connection)
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
            using (connection)
            {
                connection.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter(comandaAdrese(IDAdresaNespecificata), connection);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);

                foreach (DataRow dtRow in dataTable.Rows)
                    if (dtRow[0].ToString() == idc.ToString())
                        return false;

            }
            return true;
        }

        public void SalvareAdrese(int IdPersoana, TextBox Municipiu, TextBox Judet, TextBox Oras, TextBox Comuna, TextBox Sat, TextBox Strada,
        TextBox Numar, TextBox Bloc, TextBox Scara, int cod)
        {
            Random random = new Random();
            int idA;
            do
            {
                idA = random.Next(0, 9999);
            } while (uniqueIdAdrese(idA) == false);

            SqlCommand command = new SqlCommand("insert into AdreseTable values (@IdAdresa, @Municipiu, @Judet, @Oras, @Comuna, @Sat, @Strada, @Numar, @Bloc, @Scara, @IdPersoana)", connection);
            command.Parameters.AddWithValue("@IdAdresa", idA);
            command.Parameters.AddWithValue("@Municipiu", Municipiu.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@Judet", Judet.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@Oras", Oras.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@Comuna", Comuna.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@Sat", Sat.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@Strada", Strada.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@Numar", Numar.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@Bloc", Bloc.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@Scara", Scara.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@IdPersoana", IdPersoana);
            connection.Open();
            int i = command.ExecuteNonQuery();
            if (i != 0)
            {
                if (cod == 1)
                    MessageBox.Show("Adresa de domiciliu a fost salvata");
                if (cod == 2)
                    MessageBox.Show("Locul nasterii a fost salvat");
                if (cod == 3)
                    MessageBox.Show("Adresa 1 a fost salvata");
                if (cod == 4)
                    MessageBox.Show("Adresa 2 a fost salvata");
            }
            else
            {
                if (cod == 1)
                    MessageBox.Show("Eroare la salarea adresei de domiciliu");
                if (cod == 2)
                    MessageBox.Show("Eroare la salarea locului de nastere");
                if (cod == 3)
                    MessageBox.Show("Eroare la salarea adresei 1");
                if (cod == 4)
                    MessageBox.Show("Eroare la salarea adresei 2");
            }

            connection.Close();
        }

        private void salveazaInregistrareaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SqlCommand command = new SqlCommand("insert into PersoaneTable values (@IdPersoana, @Nume, @Prenume, @Sex, @DataNasteri, @CNP)", connection);
            Random random = new Random();
            int idP;
            do
            {
                idP = random.Next(0, 9999);
            } while (uniqueIdPersoana(idP) == false);

            command.Parameters.AddWithValue("@IdPersoana", idP);
            command.Parameters.AddWithValue("@Nume", txtNume.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@Prenume", txtPrenume.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@Sex", txtSex.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@DataNasteri", txtDataNasterii.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@CNP", txtCNP.Text.Trim().ToUpper());

            connection.Open();
            int i = command.ExecuteNonQuery();

            connection.Close();
            if (i != 0)
                MessageBox.Show("Date personale au fost salvate");
            else
                MessageBox.Show("Eroare la salvarea datelor personale");
            SalvareAdrese(idP, txtMunicipiuD, txtJudetD, txtOrasD, txtComunaD, txtSatD, txtStradaD, txtNumarD, txtBlocD, txtScaraD, 1);
            SalvareAdrese(idP, txtMunicipiuN, txtJudetN, txtOrasN, txtComunaN, txtSatN, txtStradaN, txtNumarN, txtBlocN, txtScaraN, 2);
            SalvareAdrese(idP, txtMunicipiu1, txtJudet1, txtOras1, txtComuna1, txtSat1, txtStrada1, txtNumar1, txtBloc1, txtScara1, 3);
            SalvareAdrese(idP, txtMunicipiu2, txtJudet2, txtOras2, txtComuna2, txtSat2, txtStrada2, txtNumar2, txtBloc2, txtScara2, 4);

            ClearTextBox();
        }

        public void ClearTextBox()
        {
            foreach (Control a in this.Controls)
            {
                if (a is TextBox)
                    a.Text = string.Empty;
            }
        }

    }
}
