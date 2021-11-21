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
using System.Configuration;

namespace perehod
{
    public partial class Registr : Form
    {
        public SqlConnection sqlcon = null;
        public Registr()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcomm = new SqlCommand(
                $"INSERT INTO [Sotr] (Login, Password, Doljnost) VALUES (@Login, @Password, @Doljnost)", sqlcon);
            sqlcomm.Parameters.AddWithValue("Login", txtLogin.Text);
            sqlcomm.Parameters.AddWithValue("Password", txtPassword.Text);
            sqlcomm.Parameters.AddWithValue("Doljnost", txtDoljnost.Text);
            MessageBox.Show(sqlcomm.ExecuteNonQuery().ToString());
        }

        private void Registr_Load(object sender, EventArgs e)
        {

            sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["wsrDB"].ConnectionString);
            sqlcon.Open();
            if (sqlcon.State == ConnectionState.Open)
            {
                MessageBox.Show("jkhkj");
            }

        }
    }
}
