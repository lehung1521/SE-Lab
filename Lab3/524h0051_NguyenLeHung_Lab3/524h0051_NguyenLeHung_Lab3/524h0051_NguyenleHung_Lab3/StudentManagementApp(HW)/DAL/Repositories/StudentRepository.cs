using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories
{
    public class StudentRepository
    {
        public DataTable GetAllStudents()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                string query = @"SELECT 
                                    StudentID,
                                    StudentName,
                                    DateOfBirth,
                                    City,
                                    Age,
                                    YearOfEnroll,
                                    Major,
                                    GPA
                                 FROM tblStudents";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        public void AddStudent(
            string studentName,
            DateTime dateOfBirth,
            string city,
            int age,
            int yearOfEnroll,
            string major,
            decimal? gpa)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                string query = @"INSERT INTO tblStudents
                                (StudentName, DateOfBirth, City, Age, YearOfEnroll, Major, GPA)
                                VALUES
                                (@StudentName, @DateOfBirth, @City, @Age, @YearOfEnroll, @Major, @GPA)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentName", studentName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@YearOfEnroll", yearOfEnroll);
                    cmd.Parameters.AddWithValue("@Major",
                        string.IsNullOrWhiteSpace(major)
                            ? (object)DBNull.Value
                            : major);
                    cmd.Parameters.AddWithValue("@GPA",
                        gpa.HasValue
                            ? (object)gpa.Value
                            : DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudent(
            int studentID,
            string studentName,
            DateTime dateOfBirth,
            string city,
            int age,
            int yearOfEnroll,
            string major,
            decimal? gpa)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                string query = @"UPDATE tblStudents
                                 SET StudentName = @StudentName,
                                     DateOfBirth = @DateOfBirth,
                                     City = @City,
                                     Age = @Age,
                                     YearOfEnroll = @YearOfEnroll,
                                     Major = @Major,
                                     GPA = @GPA
                                 WHERE StudentID = @StudentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@StudentName", studentName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@YearOfEnroll", yearOfEnroll);
                    cmd.Parameters.AddWithValue("@Major",
                        string.IsNullOrWhiteSpace(major)
                            ? (object)DBNull.Value
                            : major);
                    cmd.Parameters.AddWithValue("@GPA",
                        gpa.HasValue
                            ? (object)gpa.Value
                            : DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStudent(int studentID)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                string query = "DELETE FROM tblStudents WHERE StudentID = @StudentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}