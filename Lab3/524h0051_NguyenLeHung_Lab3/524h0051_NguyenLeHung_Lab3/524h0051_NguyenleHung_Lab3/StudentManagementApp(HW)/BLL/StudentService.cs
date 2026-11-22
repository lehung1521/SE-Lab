using System;
using System.Data;
using DAL.Repositories;

namespace BLL
{
    public class StudentService
    {
        private readonly StudentRepository studentRepository;

        public StudentService()
        {
            studentRepository = new StudentRepository();
        }

        public DataTable GetAllStudents()
        {
            return studentRepository.GetAllStudents();
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
            if (string.IsNullOrWhiteSpace(studentName))
                throw new Exception("Student name cannot be empty.");

            if (string.IsNullOrWhiteSpace(city))
                throw new Exception("City cannot be empty.");

            if (age <= 0)
                throw new Exception("Age must be greater than 0.");

            if (yearOfEnroll <= 0)
                throw new Exception("Year of enroll is invalid.");

            if (gpa.HasValue && (gpa.Value < 0 || gpa.Value > 4))
                throw new Exception("GPA must be between 0 and 4.");

            studentRepository.AddStudent(
                studentName,
                dateOfBirth,
                city,
                age,
                yearOfEnroll,
                major,
                gpa);
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
            if (studentID <= 0)
                throw new Exception("Invalid Student ID.");

            if (string.IsNullOrWhiteSpace(studentName))
                throw new Exception("Student name cannot be empty.");

            if (string.IsNullOrWhiteSpace(city))
                throw new Exception("City cannot be empty.");

            if (age <= 0)
                throw new Exception("Age must be greater than 0.");

            if (gpa.HasValue && (gpa.Value < 0 || gpa.Value > 4))
                throw new Exception("GPA must be between 0 and 4.");

            studentRepository.UpdateStudent(
                studentID,
                studentName,
                dateOfBirth,
                city,
                age,
                yearOfEnroll,
                major,
                gpa);
        }

        public void DeleteStudent(int studentID)
        {
            if (studentID <= 0)
                throw new Exception("Invalid Student ID.");

            studentRepository.DeleteStudent(studentID);
        }
    }
}