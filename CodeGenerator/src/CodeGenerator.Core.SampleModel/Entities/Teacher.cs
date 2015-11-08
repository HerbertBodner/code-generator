using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGenerator.Core.SampleModel.Entities
{
    public class Teacher : Person
    {
        public string Type { get; set; }

        public List<Course> Courses { get; set; }
    }
}
