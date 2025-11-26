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
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }
        private void btnStudentRegistration_Click(object sender, EventArgs e)
        {
            StudentRegistration StudentRegister = new StudentRegistration();
            StudentRegister.Show();
            this.Hide();
        }
    
        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersForm Users = new UsersForm();
            Users.Show();
            this.Hide();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageForm manage = new ManageForm();
            manage.Show();
            this.Hide();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            admin.Show();
            this.Hide();
        }

        private void btnProfessors_Click(object sender, EventArgs e)
        {
            ProfessorsForm professors = new ProfessorsForm();
            professors.Show();
            this.Hide();
        }

    }

}
