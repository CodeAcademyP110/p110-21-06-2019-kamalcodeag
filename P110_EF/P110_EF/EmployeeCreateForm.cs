using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P110_EF.Model;

namespace P110_EF
{
    public partial class EmployeeCreateForm : Form
    {
        private readonly CompanyEntities _context;

        public EmployeeCreateForm()
        {
            InitializeComponent();
            _context = new CompanyEntities();
        }

        private void EmployeeCreateForm_Load(object sender, EventArgs e)
        {
            cmbDepartments.Items.AddRange(
                _context.Departments.ToArray()
            );
        }

        private void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPositions.Items.Clear();

            Department selectedDepartament = cmbDepartments.SelectedItem as Department;

            cmbPositions.Items.AddRange(
                selectedDepartament.Positions.ToArray()
                //_context.Positions.Where(p => p.DepartmentId == selectedDepartament.Id).ToArray()
            );
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string fname = txtFirstname.Text.Trim();
            string lname = txtLastname.Text.Trim();
            string email = txtEmail.Text.Trim();
            decimal salary = nmSalary.Value;

            Position selectedPosition = cmbPositions.SelectedItem as Position;

            //validation occurs here

            _context.Employees.Add(new Employee
            {
                Firstname = fname,
                Lastname = lname,
                Email = email,
                Salary = salary,
                Password = "mix_can_123_zoku",
                PositionId = selectedPosition.Id
            });
            await _context.SaveChangesAsync();

            MessageBox.Show("Success");

            Close();
        }
    }
}
