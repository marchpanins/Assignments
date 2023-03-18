using Assignments.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignments
{
    public partial class frmLogin : Form
    {
        private readonly UsersRepository _usersRepository;
        public frmLogin()
        {
            InitializeComponent();
            _usersRepository = new UsersRepository();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int loggedInUserId = _usersRepository.Login(tbUsername.Text, mtbPassword.Text);
            if (loggedInUserId == 0)
            {
                MessageBox.Show("User or password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(loggedInUserId == -1)
            {
                // exception case
                MessageBox.Show(_usersRepository.ErrorMessage);
            }
            else
            {
                StaticDetails.LoggedInUserId = loggedInUserId;

                frmAssignments frm = new frmAssignments();
                frm.Show();
                this.Hide();
            }
        }
    }
}
