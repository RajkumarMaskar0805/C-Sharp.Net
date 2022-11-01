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
    public partial class frm_Search_Student_List : Form
    {
        public frm_Search_Student_List()
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

        void Clear_Controls()
        {
            txt_Roll_No.Clear();
            txt_Name.Clear();
            txt_Mobile_No.Clear();
            dtp_DOB.Text = "";
            cmb_Course.Text = "";
        }

        private void frm_Search_Student_List_Load(object sender, EventArgs e)
        {
            lbl_Username.Text = Shared_Class.Username;
        }

        private void Only_Numeric(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear_Controls();
        }

        private void btn_Add_New_Student_Click(object sender, EventArgs e)
        {
            frm_Add_New_Student Obj = new frm_Add_New_Student();
            Obj.Show();
            this.Hide();
        }

        private void btn_View_Student_List_Click(object sender, EventArgs e)
        {
            frm_View_Student_List Obj = new frm_View_Student_List();
            Obj.Show();
            this.Hide();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Con_Open();

            SqlCommand cmd = new SqlCommand("Select * From Student_List Where Roll_No = @Rno", Con);

            cmd.Parameters.Add("Rno", SqlDbType.Int).Value = txt_Roll_No.Text;
            SqlDataReader Dr = cmd.ExecuteReader();

            if (Dr.Read())
            {
                txt_Name.Text = Dr.GetString(Dr.GetOrdinal("Name"));
                txt_Mobile_No.Text = (Dr["Mobile_No"].ToString());
                dtp_DOB.Text = (Dr["DOB"].ToString());
                cmb_Course.Text= Dr.GetString(Dr.GetOrdinal("Course"));
            }
            else
            {
                MessageBox.Show("No Recored Found ", "Invaild Roll No ");
                txt_Roll_No.Clear();
            }

            Con_Close();
        }

        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are You sure to Quit", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Res == DialogResult.Yes)
            {
                frm_YC_Login Obj = new frm_YC_Login();
                this.Hide();
                Obj.Show();
            }
        }
    }
}
