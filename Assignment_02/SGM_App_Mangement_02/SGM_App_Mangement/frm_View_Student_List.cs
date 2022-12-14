using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGM_App_Mangement
{
    public partial class frm_View_Student_List : Form
    {
        public frm_View_Student_List()
        {
            InitializeComponent();
        }

        private void btn_Add_New_Student_Click(object sender, EventArgs e)
        {
            Frm_Add_New_Student Obj = new Frm_Add_New_Student();
            this.Hide();
            Obj.Show();
        }

        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are you sure to Quit", "Logout", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (Res == DialogResult.Yes)
            {
                frm_Login Obj = new  frm_Login();
                this.Hide();
                Obj.Show();
            }
        }

        private void frm_View_Student_List_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sGM_App_Mangement_dbDataSet.tbl_Student_List' table. You can move, or remove it, as needed.
            this.tbl_Student_ListTableAdapter.Fill(this.sGM_App_Mangement_dbDataSet.tbl_Student_List);

        }

        private void btn_Search_Student_List_Click(object sender, EventArgs e)
        {
            frm_Search_Student_List Obj = new frm_Search_Student_List();
            this.Hide();
            Obj.Show();
        }
    }
}
