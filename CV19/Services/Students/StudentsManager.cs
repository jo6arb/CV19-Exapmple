using System.Collections.Generic;
using CV19.Models.Decanat;

namespace CV19.Services
{
    class StudentsManager
    {
        private readonly StudentRepository _students;
        private readonly GroupRepository _groups;

        public IEnumerable<Student> Students => _students.GetAll();

        public IEnumerable<Group> Groups => _groups.GetAll();


        public StudentsManager(StudentRepository students, GroupRepository groups)
        {
            _students = students;
            _groups = groups;
        }
    }
}