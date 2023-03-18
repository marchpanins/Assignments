using Assignments.Models;
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
using System.Xml.Linq;

namespace Assignments
{
    public partial class frmAddAssignment : Form
    {
        private readonly AssignmentsRepository _repository;
        public frmAddAssignment()
        {
            InitializeComponent();
            _repository = new AssignmentsRepository();
            cbUrgencyLevel.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            Assignment a = new Assignment();
            a.UserId = StaticDetails.LoggedInUserId;
            a.Name = tbName.Text;
            a.UrgencyLevel = cbUrgencyLevel.Text;
            a.DueDate = dtpDueDate.Value;

            bool added = _repository.AddAssignment(a);
            if (!added)
            {
                MessageBox.Show(_repository.ErrorMessage);
            }
            else
            {
                DialogResult= DialogResult.OK;
            }
            
        }
    }
}
