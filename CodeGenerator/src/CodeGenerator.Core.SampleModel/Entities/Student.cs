using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGenerator.Core.SampleModel.Entities
{
    public class Student : Person
    {
        public List<Course> Courses { get; set; }
    }
}
