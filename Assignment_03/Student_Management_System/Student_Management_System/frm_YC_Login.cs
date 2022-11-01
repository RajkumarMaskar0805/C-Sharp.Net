using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_Management_System
{
    public partial class frm_YC_Login : Form
    {
        public frm_YC_Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=YC_APP_Management_db;Integrated Security=True");

        void Con_Open()
        {
            if (Con.State != ConnectionState.Open)
            {
                Con.Open();
            }
        }

        void Con_Close()
        {
            if (Con.State != ConnectionState.Closed)
            {
                Con.Close();
            }
        }
           
        private void frm_YC_Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            int Cnt = 0;
            Con_Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "Select Count(*) From Login_Details Where Username = @Uname And Password = @Pwd";

            Cmd.Parameters.Add("Uname", SqlDbType.NVarChar).Value = txt_Username.Text;
            Cmd.Parameters.Add("Pwd", SqlDbType.NVarChar).Value = txt_Password.Text;

            Cnt = Convert.ToInt32(Cmd.ExecuteScalar());

            if (Cnt > 0)
            {
                MessageBox.Show("Login Succesful", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Shared_Class.Username = "Welcome "+ txt_Username.Text;

                frm_Add_New_Student Obj = new frm_Add_New_Student();
                Obj.Show();
                this.Hide();
            }
            else
            {
                lbl_Error.Text = "Invaild Username Or Password";
                lbl_Error.ForeColor = Color.OrangeRed;
            }

            txt_Username.Clear();
            txt_Password.Clear();

            txt_Username.Enabled = false;
            txt_Password.Enabled = false;

            txt_Username.Focus();
            
            Con_Close();


        }

        private void txt_Username_TextChanged(object sender, EventArgs e)
        {
            lbl_Error.Visible = true;
            txt_Password.Enabled = true;

        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            btn_Submit.Enabled = true;

        }

    }
}
