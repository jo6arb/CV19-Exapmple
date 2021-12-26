using System;
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

        public bool Create(Student student, string GroupName)
        {
            if (student is null) throw new ArgumentNullException(nameof(student));
            if (string.IsNullOrWhiteSpace(GroupName)) throw new ArgumentException("некорректное имя группы", nameof(GroupName));
            
            var group = _groups.Get(GroupName);

            if (group is null)
            {
                group = new Group {Name = GroupName};
                _groups.Add(group);
            }
            group.Students.Add(student);
            _students.Add(student);
            return true;
        }

        public void Update(Student student) => _students.Update(student.Id, student);
    }
}