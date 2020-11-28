using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Pattern.Factory
{
    class StudentFactory
    {
        private readonly List<Model.Student> students;
        public IEnumerable<Model.Student> GetAllStudents()
        {
            return students;
        }

        public StudentFactory()
        {
            students = new List<Model.Student>
            {
                new Model.Student() { Grade = "1", Class = "3", Name = "gildong", Number = "1010", Score = "A" },
                new Model.Student() { Grade = "1", Class = "1", Name = "gildong", Number = "1020", Score = "A" },
                new Model.Student() { Grade = "1", Class = "2", Name = "gildong", Number = "1030", Score = "A" },
                new Model.Student() { Grade = "1", Class = "4", Name = "gildong", Number = "1040", Score = "B" },
                new Model.Student() { Grade = "1", Class = "2", Name = "gildong", Number = "1050", Score = "A" },
                new Model.Student() { Grade = "1", Class = "5", Name = "gildong", Number = "1060", Score = "C" }
            };
        }
    }
}
