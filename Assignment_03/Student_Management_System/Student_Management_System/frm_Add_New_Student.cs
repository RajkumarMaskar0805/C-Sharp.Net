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
    public partial class frm_Add_New_Student : Form
    {
        public frm_Add_New_Student()
        {
            InitializeComponent();
        }

        private void frm_Add_New_Student_Load(object sender, EventArgs e)
        {
            lbl_Username.Text = Shared_Class.Username;
            Clear_Controls();
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
            txt_Roll_No.Text = Convert.ToString(Auto_Incr());
            txt_Name.Clear();
            txt_Mobile_No.Clear();
            dtp_DOB.Text = "";
            cmb_Course.SelectedIndex = -1;
        }

        int Auto_Incr()
        {
            int Cnt = 0;
            Con_Open();

            SqlCommand Cmd = new SqlCommand("Select Count(Roll_No) from Student_List", Con);

            Cnt = Convert.ToInt32(Cmd.ExecuteScalar());
            

            if (Cnt > 0)
            {
                Cmd.Connection = Con;
                Cmd.CommandText = "Select Max(Roll_No) from Student_List";

                Cnt = Convert.ToInt32(Cmd.ExecuteScalar()) +1 ;
                
            }
            else
            {
                Cnt = 101;
            }

            Con_Close();

            return Cnt;
        }

        private void Only_Numeric(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void Only_Text(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space) || (e.KeyChar == (char)Keys.ShiftKey)))
            {
                e.Handled = true;
            }
        }

        private void btn_Search_Student_List_Click(object sender, EventArgs e)
        {
            frm_Search_Student_List Obj = new frm_Search_Student_List();
            Obj.Show();
            this.Hide();

        }

        private void btn_View_Student_List_Click(object sender, EventArgs e)
        {
            frm_View_Student_List Obj = new frm_View_Student_List();
            Obj.Show();
            this.Hide();

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Con.Open();

            if (txt_Roll_No.Text != "" && txt_Name.Text != "" && txt_Mobile_No.Text != "" && txt_Mobile_No.TextLength == 10 && cmb_Course.Text != "")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandText = "Insert Into Student_List (Roll_No,Name,DOB,Mobile_No,Course) Values(@RollNo,@Nm,@DOB,@MNo,@Course)";

                Cmd.Parameters.Add("RollNo", SqlDbType.Int).Value = txt_Roll_No.Text;
                Cmd.Parameters.Add("Nm", SqlDbType.VarChar).Value = txt_Name.Text;
                Cmd.Parameters.Add("DOB", SqlDbType.Date).Value = dtp_DOB.Value.Date;
                Cmd.Parameters.Add("MNo", SqlDbType.Decimal).Value = txt_Mobile_No.Text;
                Cmd.Parameters.Add("Course", SqlDbType.NVarChar).Value = cmb_Course.Text;

                Cmd.ExecuteNonQuery();

                MessageBox.Show("Record Inserted Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear_Controls();
                
            }
            else
            {
                MessageBox.Show("Fill All Field Compulsary", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Con.Close();
         }

        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are You sure to Quit", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Res == DialogResult.Yes)
            {
                frm_YC_Login Obj = new frm_YC_Login();
                Obj.Show();
                this.Hide();

            }
        }
     
    }
}
