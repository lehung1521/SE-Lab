using System;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace StudentManagementApp_HW_
{
    public partial class StudentsForm : Form
    {
        private StudentService studentService;

        public StudentsForm()
        {
            InitializeComponent();

            studentService = new StudentService();
        }

        private void StudentsForm_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DataTable table = studentService.GetAllStudents();

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                studentService.AddStudent(
                    "New Student",
                    DateTime.Now,
                    "City",
                    20,
                    2021,
                    "Major",
                    4.0m);

                LoadData();

                MessageBox.Show("Student added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student.");
                return;
            }

            try
            {
                int studentID = Convert.ToInt32(
                    dataGridView1.SelectedRows[0]
                        .Cells["StudentID"]
                        .Value);

                studentService.UpdateStudent(
                    studentID,
                    "Updated Student",
                    DateTime.Now,
                    "Updated City",
                    21,
                    2022,
                    "Updated Major",
                    3.9m);

                LoadData();

                MessageBox.Show("Student updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student.");
                return;
            }

            try
            {
                int studentID = Convert.ToInt32(
                    dataGridView1.SelectedRows[0]
                        .Cells["StudentID"]
                        .Value);

                studentService.DeleteStudent(studentID);

                LoadData();

                MessageBox.Show("Student deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}