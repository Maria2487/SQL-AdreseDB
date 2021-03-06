using SQL_AdreseDB_Practica.Adrese;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static SQL_AdreseDB_Practica.Functii;

namespace SQL_AdreseDB_Practica
{
    public partial class Adauga : Form
    {
        private AdreseDBDataContext adreseContext;
        private SqlConnection connection;

        public Adauga()
        {
            InitializeComponent();
            adreseContext = new AdreseDBDataContext();
            connection = new SqlConnection("Data Source=DESKTOP-DVF30NR\\SQLEXPRESS;Initial Catalog=AdreseDB;Integrated Security=True");
        }

        private bool uniqueIdPersoana(int idc)
        {
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter(comandaPersoane(), connection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);

            foreach (DataRow dtRow in dataTable.Rows)
                if (dtRow[0].ToString() == idc.ToString())
                {
                    connection.Close();
                    return false;
                }
            connection.Close();

            return true;
        }

        private bool uniqueIdAdrese(int idc)
        {
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter(comandaAdrese(IDAdresaNespecificata), connection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);

            foreach (DataRow dtRow in dataTable.Rows)
                if (dtRow[0].ToString() == idc.ToString())
                {
                    connection.Close();
                    return false;
                }
            connection.Close();

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
            if (VerificareNume(txtNume.Text.Trim().ToUpper()) == false)
            {
                MessageBox.Show("Casuta pentru nume nu poate fi goala sau sa contina cifre");
                return;
            }
            if (VerificareNume(txtPrenume.Text.Trim().ToUpper()) == false)
            {
                MessageBox.Show("Casuta pentru prenume nu poate fi goala sau sa contina cifre");
                return;
            }
            if (VerificareCNP(txtCNP.Text.Trim()) == false)
            {
                return;
            }
            if (VerificareSEX(txtSex.Text.Trim().ToUpper()) == false)
            {
                return;
            }
            if(dateTimePicker.Value > DateTime.Now)
            {
                MessageBox.Show("Data nasterii a fost incorect introdusa");
                return;
            }    

            SqlCommand command = new SqlCommand("insert into PersoaneTable values (@IdPersoana, @Nume, @Prenume, @Sex, @DataNasteri, @CNP)", connection);
            Random random = new Random();
            int idP;
            do
            {
                idP = random.Next(0, 9999);
            } while (uniqueIdPersoana(idP) == false);

            string time = dateTimePicker.Value.ToString();
            string[] dateTime1 = time.Split('/');
            string[] dateTime2 = dateTime1[2].Split(' ');
            string data = dateTime2[0] + "/" + dateTime1[0] + "/" + dateTime1[1];

            command.Parameters.AddWithValue("@IdPersoana", idP);
            command.Parameters.AddWithValue("@Nume", txtNume.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@Prenume", txtPrenume.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@Sex", txtSex.Text.Trim().ToUpper());
            command.Parameters.AddWithValue("@DataNasteri", data);
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