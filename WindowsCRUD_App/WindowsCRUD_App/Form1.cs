using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCRUD_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=SENExamPracDB;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into tblUser values (@ID,@Name,@Age)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@Name",txtName.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(txtAge.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully saved");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=SENExamPracDB;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update tblUser set Name = @Name,Age =@Age where ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(txtAge.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=SENExamPracDB;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete tblUser where ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully deleted");
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=SENExamPracDB;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SelectID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=SENExamPracDB;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblUser", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
