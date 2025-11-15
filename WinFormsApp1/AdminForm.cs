using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lblProfessors_Click(object sender, EventArgs e)
        {
            ProfessorsForm ProfessorsForm = new ProfessorsForm();
            ProfessorsForm.Show();
            this.Hide();

        }

        private void lblManage_Click(object sender, EventArgs e)
        {
            ManageForm ManageForm = new ManageForm();
            ManageForm.Show();
            this.Hide();
        }

        private void lblUsers_Click(object sender, EventArgs e)
        {
            UsersForm UsersForm = new UsersForm();
            UsersForm.Show();
            this.Hide();
        }
    }
}
