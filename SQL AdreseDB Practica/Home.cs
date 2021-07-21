using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        
        private void afisareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection("Data Source=DESKTOP-DVF30NR\\SQLEXPRESS;Initial Catalog=AdreseDB;Integrated Security=True");
            afisarePersoane(conection, dataGridHome);
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            Adauga adauga = new Adauga();
            //this.Hide();
            adauga.ShowDialog();
            this.Show();
            dataGridHome.DataSource = null;
        }

        private void buttonModificare_Click(object sender, EventArgs e)
        {
            FormEdit modificare = new FormEdit();
            //this.Hide();
            modificare.ShowDialog();
            this.Show();
            dataGridHome.DataSource = null;
        }
    }
}
