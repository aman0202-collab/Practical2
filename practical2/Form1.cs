using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;

namespace practical2
{
    public partial class Form1 : Form
    {
        TextBox txtID, txtName, txtBasic, txtHours, txtRate;
        ComboBox cmbType;
        DataGridView dgvEmployees;

        // All employees are stored as base class objects,
        // so the correct CalculateSalary() runs by itself
        List<Employee> employees = new List<Employee>();

        public Form1()
        {
            InitializeComponent();
            this.Controls.Clear();
            CreateInterface();
        }

        private void CreateInterface()
        {
            this.Text = "Employee Payroll System";
            this.Size = new Size(1100, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Heading
            Label heading = new Label();
            heading.Text = "EMPLOYEE PAYROLL SYSTEM";
            heading.Font = new Font("Arial", 22, FontStyle.Bold);
            heading.ForeColor = Color.DarkBlue;
            heading.Location = new Point(250, 25);
            heading.Size = new Size(700, 45);
            this.Controls.Add(heading);

            // Employee ID
            AddLabel("Employee ID:", 120, 120);
            txtID = AddTextBox(340, 120);

            // Employee Name
            AddLabel("Employee Name:", 120, 180);
            txtName = AddTextBox(340, 180);

            // Employee Type
            AddLabel("Employee Type:", 120, 240);
            cmbType = new ComboBox();
            cmbType.Location = new Point(340, 240);
            cmbType.Size = new Size(375, 32);
            cmbType.Font = new Font("Arial", 12);
            cmbType.BackColor = Color.White;
            cmbType.ForeColor = Color.Black;
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Items.Add("Full Time");
            cmbType.Items.Add("Part Time");
            cmbType.SelectedIndex = 0;
            this.Controls.Add(cmbType);

            // Basic Salary
            AddLabel("Basic Salary:", 120, 300);
            txtBasic = AddTextBox(340, 300);

            // Working Hours
            AddLabel("Working Hours:", 120, 360);
            txtHours = AddTextBox(340, 360);

            // Hourly Rate
            AddLabel("Hourly Rate:", 120, 420);
            txtRate = AddTextBox(340, 420);

            // Add Button
            Button btnAdd = new Button();
            btnAdd.Text = "ADD EMPLOYEE";
            btnAdd.Location = new Point(340, 480);
            btnAdd.Size = new Size(180, 50);
            btnAdd.BackColor = Color.SeaGreen;
            btnAdd.ForeColor = Color.White;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Font = new Font("Arial", 11, FontStyle.Bold);
            btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(btnAdd);

            // Clear Button
            Button btnClear = new Button();
            btnClear.Text = "CLEAR";
            btnClear.Location = new Point(550, 480);
            btnClear.Size = new Size(150, 50);
            btnClear.BackColor = Color.DarkOrange;
            btnClear.ForeColor = Color.White;
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Font = new Font("Arial", 11, FontStyle.Bold);
            btnClear.Click += BtnClear_Click;
            this.Controls.Add(btnClear);

            // DataGridView
            dgvEmployees = new DataGridView();
            dgvEmployees.Location = new Point(50, 555);
            dgvEmployees.Size = new Size(980, 145);

            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.ForeColor = Color.Black;
            dgvEmployees.GridColor = Color.LightGray;

            dgvEmployees.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;

            dgvEmployees.EnableHeadersVisualStyles = false;

            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor =
                Color.Navy;
            dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font =
                new Font("Arial", 10, FontStyle.Bold);

            dgvEmployees.DefaultCellStyle.BackColor = Color.White;
            dgvEmployees.DefaultCellStyle.ForeColor = Color.Black;

            dgvEmployees.DefaultCellStyle.SelectionBackColor =
                Color.LightBlue;
            dgvEmployees.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgvEmployees.AlternatingRowsDefaultCellStyle.BackColor =
                Color.LightGray;

            // Columns
            dgvEmployees.Columns.Add("ID", "Employee ID");
            dgvEmployees.Columns.Add("Name", "Employee Name");
            dgvEmployees.Columns.Add("Type", "Type");
            dgvEmployees.Columns.Add("Basic", "Basic Salary");
            dgvEmployees.Columns.Add("Net", "Net Salary");

            this.Controls.Add(dgvEmployees);
        }

        // Label method
        private void AddLabel(string text, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(180, 30);
            lbl.Font = new Font("Arial", 12, FontStyle.Bold);
            lbl.ForeColor = Color.Black;
            lbl.BackColor = Color.White;

            this.Controls.Add(lbl);
        }

        // TextBox method
        private TextBox AddTextBox(int x, int y)
        {
            TextBox txt = new TextBox();
            txt.Location = new Point(x, y);
            txt.Size = new Size(375, 32);
            txt.Font = new Font("Arial", 12);
            txt.BackColor = Color.White;
            txt.ForeColor = Color.Black;

            this.Controls.Add(txt);
            return txt;
        }

        // Add Employee button
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string id = txtID.Text.Trim();
            string name = txtName.Text.Trim();
            string type = cmbType.SelectedItem.ToString();

            // Check duplicate Employee ID
            foreach (Employee emp in employees)
            {
                if (emp.EmployeeID == id)
                {
                    MessageBox.Show("Employee ID already exists!");
                    return;
                }
            }

            Employee employee;

            if (type == "Full Time")
            {
                decimal basic;

                if (id == "" || name == "" ||
                    txtBasic.Text.Trim() == "")
                {
                    MessageBox.Show("Please fill all employee details!");
                    return;
                }

                // Validate Basic Salary
                if (!decimal.TryParse(
                    txtBasic.Text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out basic) || basic < 0)
                {
                    MessageBox.Show("Please enter a valid Basic Salary!");
                    return;
                }

                // Create FullTimeEmployee object (Inheritance)
                employee = new FullTimeEmployee(id, name, basic);
            }
            else
            {
                int hours;
                decimal rate;

                if (id == "" || name == "" ||
                    txtHours.Text.Trim() == "" ||
                    txtRate.Text.Trim() == "")
                {
                    MessageBox.Show("Please fill all employee details!");
                    return;
                }

                // Validate Working Hours and Hourly Rate
                if (!int.TryParse(txtHours.Text.Trim(), out hours) ||
                    hours <= 0)
                {
                    MessageBox.Show("Please enter valid Working Hours!");
                    return;
                }

                if (!decimal.TryParse(
                    txtRate.Text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out rate) || rate < 0)
                {
                    MessageBox.Show("Please enter a valid Hourly Rate!");
                    return;
                }

                // Create PartTimeEmployee object (Inheritance)
                employee = new PartTimeEmployee(id, name, hours, rate);
            }

            // Store Employee
            employees.Add(employee);

            // CalculateSalary() runs the child class formula
            // automatically - this is Polymorphism
            decimal netSalary = employee.CalculateSalary();

            // Display in DataGridView
            dgvEmployees.Rows.Add(
                employee.EmployeeID,
                employee.EmployeeName,
                type,
                employee.BasicSalary.ToString("0.##"),
                netSalary.ToString("0.##")
            );

            MessageBox.Show(
                "Employee Added Successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            ClearFields();
        }

        // Clear button
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Clear all textboxes
        private void ClearFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtBasic.Clear();
            txtHours.Clear();
            txtRate.Clear();
            cmbType.SelectedIndex = 0;

            txtID.Focus();
        }
    }
}
