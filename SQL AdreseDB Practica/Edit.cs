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
    public partial class FormEdit : Form
    {
        AdreseDBDataContext adreseContext;
        SqlConnection connection;
        public FormEdit()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source=DESKTOP-DVF30NR\\SQLEXPRESS;Initial Catalog=AdreseDB;Integrated Security=True");
            afisarePersoane(connection, dataGridHome);
            buttonEdit.Visible = false;
            
        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridHome.Columns.Contains("Nume") == true)
            {
                var editNume = this.dataGridHome.Rows[e.RowIndex].Cells["Nume"];
                var newNume = editNume.Value.ToString().ToUpper();

                var editPrenume = this.dataGridHome.Rows[e.RowIndex].Cells["Prenume"];
                var newPrenume = editPrenume.Value.ToString().ToUpper();

                var editSex = this.dataGridHome.Rows[e.RowIndex].Cells["Sex"];
                var newSex = editSex.Value.ToString().ToUpper();

                var editDataNasteri = this.dataGridHome.Rows[e.RowIndex].Cells["DataNasteri"];
                var newDataNasteri = editDataNasteri.Value.ToString().ToUpper();

                var editCNP = this.dataGridHome.Rows[e.RowIndex].Cells["CNP"];
                var newCNP = editCNP.Value.ToString().ToUpper();

                var PersoanaId = Convert.ToInt32(this.dataGridHome.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper());

                if (newNume is null)
                    newNume = "NULL";
                if (newPrenume is null)
                    newPrenume = "NULL";
                if (newSex is null)
                    newSex = "NULL";
                if (newDataNasteri is null)
                    newDataNasteri = "NULL";
                if (newCNP is null)
                    newCNP = "NULL";

                SqlCommand command = new SqlCommand("update PersoaneTable set Nume = @Nume, Prenume = @Prenume, Sex = @Sex, DataNasteri = @DataNasteri, CNP = @CNP where IdPersoana = @IdPersoana", connection);
                command.Parameters.AddWithValue("@IdPersoana", PersoanaId);
                command.Parameters.AddWithValue("@Nume", newNume);
                command.Parameters.AddWithValue("@Prenume", newPrenume);
                command.Parameters.AddWithValue("@Sex", newSex);
                command.Parameters.AddWithValue("@DataNasteri", newDataNasteri);
                command.Parameters.AddWithValue("@CNP", newCNP);

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
            using (connection)
            {
                connection.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter(comandaPersoane(), connection);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);

                dataGridHome.DataSource = dataTable;
            }
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
                using (connection)
                {
                    connection.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter(comandaDeleteA, connection);
                    DataTable dataTable = new DataTable();
                    sqlData.Fill(dataTable);
                    connection.Close();
                }

                string comandaDeleteP = "DELETE FROM PersoaneTable WHERE IdPersoana = " + idCautat;
                using (connection)
                {
                    connection.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter(comandaDeleteP, connection);
                    DataTable dataTable = new DataTable();
                    sqlData.Fill(dataTable);
                    connection.Close();
                }

                afisarePersoane(connection,dataGridHome);
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
