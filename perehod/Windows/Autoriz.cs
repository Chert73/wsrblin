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
    public partial class Autoriz : Form
    {
        private SqlConnection sqlcon = null;
        public Autoriz()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string log = txtLogin.Text;
            string pas = txtPassword.Text;

            SqlDataAdapter sqladap = new SqlDataAdapter();
            DataTable dataT = new DataTable();
            SqlCommand sqlcom = new SqlCommand("SELECT Login, Password FROM Sotr WHERE Login = @uLog AND Password = @uPas", sqlcon);
            sqlcom.Parameters.Add("uLog", SqlDbType.VarChar).Value = log;
            sqlcom.Parameters.Add("uPas", SqlDbType.VarChar).Value = pas;
            sqladap.SelectCommand = sqlcom;
            sqladap.Fill(dataT);
            if (dataT.Rows.Count > 0)
                MessageBox.Show("Ura");
            else
                MessageBox.Show("loh");


        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            Registr reg = new Registr();
            reg.Show();
        }

        private void Autoriz_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["wsrDB"].ConnectionString);
            sqlcon.Open();
        }
    }
}
