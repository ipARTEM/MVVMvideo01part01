using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMvideo03part03.Models.Decanat
{
    internal class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Student> Students { get; set; } = new List<Student>();

        public string Description { get; set; }



    }
}
