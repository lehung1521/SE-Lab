using System.Data.Entity;

namespace StudentsApp.Models
{
    public class StudentsDBEntities : DbContext
    {
        public StudentsDBEntities() : base("name=StudentsDBEntities")
        {
            Database.SetInitializer<StudentsDBEntities>(null);
        }

        public DbSet<tblStudent> tblStudents { get; set; }
    }
}
