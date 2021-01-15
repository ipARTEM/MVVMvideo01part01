using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMvideo02part02.Model.Decanat
{
    internal class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; }
    }
}
