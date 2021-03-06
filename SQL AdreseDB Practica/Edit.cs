using SQL_AdreseDB_Practica.Adrese;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static SQL_AdreseDB_Practica.Functii;

namespace SQL_AdreseDB_Practica
{
    public partial class FormEdit : Form
    {
        private AdreseDBDataContext adreseContext;
        private SqlConnection connection;

        public FormEdit()
        {
            InitializeComponent();
            adreseContext = new AdreseDBDataContext();
            connection = new SqlConnection("Data Source=DESKTOP-DVF30NR\\SQLEXPRESS;Initial Catalog=AdreseDB;Integrated Security=True");
            afisarePersoane(connection, dataGridHome);
            buttonEdit.Visible = false;
        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridHome.Columns.Contains("Nume") == true)
            {
                var editNume = this.dataGridHome.Rows[e.RowIndex].Cells["Nume"];
                var newNume = editNume.Value.ToString().Trim().ToUpper();

                var editPrenume = this.dataGridHome.Rows[e.RowIndex].Cells["Prenume"];
                var newPrenume = editPrenume.Value.ToString().Trim().ToUpper();

                var editSex = this.dataGridHome.Rows[e.RowIndex].Cells["Sex"];
                var newSex = editSex.Value.ToString().Trim().ToUpper();

                var PersoanaId = Convert.ToInt32(this.dataGridHome.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper());

                if (VerificareNume(newNume) == false)
                {
                    MessageBox.Show("Casuta pentru nume nu poate fi goala sau sa contina cifre");
                    afisarePersoane(connection, dataGridHome);
                    return;
                }
                if (VerificareNume(newPrenume) == false)
                {
                    MessageBox.Show("Casuta pentru prenume nu poate fi goala sau sa contina cifre");
                    afisarePersoane(connection, dataGridHome);
                    return;
                }

                if (VerificareSEX(newSex) == false)
                {
                    afisarePersoane(connection, dataGridHome);
                    return;
                }

                if (newNume is null)
                    newNume = "NULL";
                if (newPrenume is null)
                    newPrenume = "NULL";
                if (newSex is null)
                    newSex = "NULL";

                SqlCommand command = new SqlCommand("update PersoaneTable set Nume = @Nume, Prenume = @Prenume, Sex = @Sex, where IdPersoana = @IdPersoana", connection);
                command.Parameters.AddWithValue("@IdPersoana", PersoanaId);
                command.Parameters.AddWithValue("@Nume", newNume);
                command.Parameters.AddWithValue("@Prenume", newPrenume);
                command.Parameters.AddWithValue("@Sex", newSex);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                afisarePersoane(connection, dataGridHome);
            }
            else
            {
                var editMunicipiu = this.dataGridHome.Rows[e.RowIndex].Cells["Municipiu"];
                var newMunicipiu = editMunicipiu.Value.ToString().ToUpper();

                var editJudet = this.dataGridHome.Rows[e.RowIndex].Cells["Judet"];
                var newJudet = editJudet.Value.ToString().ToUpper();

                var editOras = this.dataGridHome.Rows[e.RowIndex].Cells["Oras"];
                var newOras = editOras.Value.ToString().ToUpper();

                var editComuna = this.dataGridHome.Rows[e.RowIndex].Cells["Comuna"];
                var newComuna = editComuna.Value.ToString().ToUpper();

                var editSat = this.dataGridHome.Rows[e.RowIndex].Cells["Sat"];
                var newSat = editSat.Value.ToString().ToUpper();

                var editStrada = this.dataGridHome.Rows[e.RowIndex].Cells["Strada"];
                var newStrada = editStrada.Value.ToString().ToUpper();

                var editNumar = this.dataGridHome.Rows[e.RowIndex].Cells["Numar"];
                var newNumar = editNumar.Value.ToString().ToUpper();

                var editBloc = this.dataGridHome.Rows[e.RowIndex].Cells["Bloc"];
                var newBloc = editBloc.Value.ToString().ToUpper();

                var editScara = this.dataGridHome.Rows[e.RowIndex].Cells["Scara"];
                var newScara = editScara.Value.ToString().ToUpper();

                var PersoanaId = Convert.ToInt32(this.dataGridHome.Rows[e.RowIndex].Cells[10].Value.ToString().ToUpper());

                if (newBloc is null)
                    newBloc = "NULL";
                if (newComuna is null)
                    newComuna = "NULL";
                if (newJudet is null)
                    newJudet = "NULL";
                if (newMunicipiu is null)
                    newMunicipiu = "NULL";
                if (newNumar is null)
                    newNumar = "NULL";
                if (newOras is null)
                    newOras = "NULL";
                if (newSat is null)
                    newSat = "NULL";
                if (newScara is null)
                    newScara = "NULL";
                if (newStrada is null)
                    newStrada = "NULL";

                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DVF30NR\\SQLEXPRESS;Initial Catalog=AdreseDB;Integrated Security=True");

                SqlCommand command = new SqlCommand("update AdreseTable set Municipiu = @Municipiu, Judet = @Judet, Oras = @Oras, Comuna = @Comuna, Sat = @Sat, Strada = @Strada, Numar = @Numar, Bloc = @Bloc, Scara = @Scara where IdPersoana = @IdPersoana and IdAdresa = @IdAdresa", connection);
                command.Parameters.AddWithValue("@IdAdresa", Convert.ToInt32(this.dataGridHome.Rows[e.RowIndex].Cells[0].Value));
                command.Parameters.AddWithValue("@IdPersoana", PersoanaId);
                command.Parameters.AddWithValue("@Municipiu", newMunicipiu);
                command.Parameters.AddWithValue("@Judet", newJudet);
                command.Parameters.AddWithValue("@Oras", newOras);
                command.Parameters.AddWithValue("@Comuna", newComuna);
                command.Parameters.AddWithValue("@Sat", newSat);
                command.Parameters.AddWithValue("@Strada", newStrada);
                command.Parameters.AddWithValue("@Numar", newNumar);
                command.Parameters.AddWithValue("@Bloc", newBloc);
                command.Parameters.AddWithValue("@Scara", newScara);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                afisareAdrese(PersoanaId);
            }
        }

        private void afisareAdrese(int i)
        {
            dataGridHome.DataSource = null;

            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter(comandaAdrese(i), connection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            dataGridHome.DataSource = dataTable;
            connection.Close();

            buttonEdit.Visible = false;
        }

        private void dataGridHome_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var idCautat = Convert.ToInt32(dataGridHome.CurrentRow.Cells[0].Value.ToString());
            afisareAdrese(idCautat);
        }

        private void listaPersoaneToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dataGridHome.DataSource = null;
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter(comandaPersoane(), connection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            dataGridHome.DataSource = dataTable;
            buttonEdit.Visible = false;
        }

        private void dataGridHome_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridHome.Columns.Contains("Nume") == true)
            {
                buttonEdit.Visible = true;
                buttonEdit.Text = "Stergere persoana";
            }
            else
            {
                buttonEdit.Visible = true;
                buttonEdit.Text = "Stergere adresa";
            }
        }

        private void buttonStergerePersoana_Click(object sender, EventArgs e)
        {
            if (dataGridHome.Columns.Contains("Nume") == true)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Sunteti sigur ca doriti sa eliminati persoana?", "Confirmare", buttons);
                if (result == DialogResult.No)
                {
                    return;
                }

                var idCautat = Convert.ToInt32(dataGridHome.CurrentRow.Cells[0].Value.ToString());

                string comandaDeleteA = "DELETE FROM AdreseTable WHERE IdPersoana = " + idCautat;
                connection.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter(comandaDeleteA, connection);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);
                connection.Close();

                string comandaDeleteP = "DELETE FROM PersoaneTable WHERE IdPersoana = " + idCautat;

                connection.Open();
                sqlData = new SqlDataAdapter(comandaDeleteP, connection);
                dataTable = new DataTable();
                sqlData.Fill(dataTable);
                connection.Close();

                afisarePersoane(connection, dataGridHome);
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Sunteti sigur ca doriti sa stergeti datele adresei?", "Confirmare", buttons);
                if (result == DialogResult.No)
                {
                    return;
                }

                SqlCommand command = new SqlCommand("update AdreseTable set Municipiu = @Municipiu, Judet = @Judet, Oras = @Oras, Comuna = @Comuna, Sat = @Sat, Strada = @Strada, Numar = @Numar, Bloc = @Bloc, Scara = @Scara where IdPersoana = @IdPersoana and IdAdresa = @IdAdresa", connection);

                command.Parameters.AddWithValue("@IdAdresa", Convert.ToInt32(this.dataGridHome.CurrentRow.Cells["IdAdresa"].Value));
                command.Parameters.AddWithValue("@IdPersoana", Convert.ToInt32(this.dataGridHome.CurrentRow.Cells["IdPersoana"].Value));
                command.Parameters.AddWithValue("@Municipiu", DBNull.Value);
                command.Parameters.AddWithValue("@Judet", DBNull.Value);
                command.Parameters.AddWithValue("@Oras", DBNull.Value);
                command.Parameters.AddWithValue("@Comuna", DBNull.Value);
                command.Parameters.AddWithValue("@Sat", DBNull.Value);
                command.Parameters.AddWithValue("@Strada", DBNull.Value);
                command.Parameters.AddWithValue("@Numar", DBNull.Value);
                command.Parameters.AddWithValue("@Bloc", DBNull.Value);
                command.Parameters.AddWithValue("@Scara", DBNull.Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                afisareAdrese(Convert.ToInt32(dataGridHome.CurrentRow.Cells[10].Value.ToString()));
            }
        }

        private void buttonCautare_Click(object sender, EventArgs e)
        {
            var itemCautat = (from PersoaneTable in adreseContext.PersoaneTables where txtNumeEdit.Text.ToUpper() == PersoaneTable.Nume.ToUpper() select PersoaneTable).ToList();
            dataGridHome.DataSource = null;
            dataGridHome.DataSource = itemCautat;
        }
    }
}