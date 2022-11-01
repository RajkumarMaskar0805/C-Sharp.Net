using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class frm_View_Student_List : Form
    {
        public frm_View_Student_List()
        {
            InitializeComponent();
        }

        private void frm_View_Student_List_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yC_APP_Management_dbDataSet.Student_List' table. You can move, or remove it, as needed.
            this.student_ListTableAdapter.Fill(this.yC_APP_Management_dbDataSet.Student_List);

            lbl_Username.Text = Shared_Class.Username;
        }

        private void btn_Add_New_Student_Click(object sender, EventArgs e)
        {
            frm_Add_New_Student Obj = new frm_Add_New_Student();
            Obj.Show();
            this.Hide();

        }

        private void btn_Search_Student_List_Click(object sender, EventArgs e)
        {
            frm_Search_Student_List Obj = new frm_Search_Student_List();
            Obj.Show();
            this.Hide();

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
