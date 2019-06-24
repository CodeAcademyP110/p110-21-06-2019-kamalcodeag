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
    public partial class Form1 : Form
    {
        private readonly CompanyEntities _context;

        public Form1()
        {
            InitializeComponent();
            _context = new CompanyEntities();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateEmployeeDGW();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var employeeForm = new EmployeeCreateForm();

            employeeForm.FormClosed += OnEmployeeFormClosed;

            employeeForm.ShowDialog();
        }

        private void OnEmployeeFormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateEmployeeDGW();
        }

        private void UpdateEmployeeDGW()
        {
            dgwEmployees.DataSource =
                _context.Employees
                .Where(emp =>
                    emp.Id >= 3 && emp.Email.Contains("@")
                )
                .Select(delegate (Employee employee)
                {
                    return new
                    {
                        Adi = employee.Firstname,
                        Soyadi = employee.Lastname,
                        employee.Email,
                        Vezifesi = employee.Position.Name,
                        Department = employee.Position.Department.Name
                    };
                })
                .ToList();
        }
    }
}
