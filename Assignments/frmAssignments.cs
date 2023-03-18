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
    public partial class frmAssignments : Form
    {
        private readonly AssignmentsRepository _repository;
        public frmAssignments()
        {
            InitializeComponent();
            _repository= new AssignmentsRepository();   
        }

        private void frmAssignments_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            var data = _repository.GetByUserId(StaticDetails.LoggedInUserId);
            if (data == null)
            {
                MessageBox.Show(_repository.ErrorMessage);
            }
            else
            {
                dgvData.DataSource = data;
            }
        }

        private void frmAssignments_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddAssignment frm = new frmAddAssignment();

            if(frm.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
