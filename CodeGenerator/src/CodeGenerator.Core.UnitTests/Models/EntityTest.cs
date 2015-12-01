using CodeGenerator.Core.Models;
using CodeGenerator.Core.Services;
using CodeGenerator.Core.UnitTests.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CodeGenerator.Core.UnitTests.Models
{
    public class EntityTest
    {
        [Fact]
        public void CourseClassEntityContainsAllProperties()
        {
            var courseType = GetTypeOfClassName("Course");

            var courseEntity = new Entity(courseType);

            Assert.Equal(6, courseEntity.Properties.Count);
        }


        [Fact]
        public void DerivedStudentEntityContainsOneProperty()
        {
            var studentType = GetTypeOfClassName("Student");

            var courseEntity = new Entity(studentType);

            Assert.Equal(1, courseEntity.Properties.Count);
        }


        [Fact]
        public void StudenEntityGenericListPropertyHasCorrectTypeName()
        {
            var studentType = GetTypeOfClassName("Student");

            var studentEntity = new Entity(studentType);

            Assert.Equal("List<Course>", studentEntity.Properties[0].TypeName);
        }

        [Fact]
        public void CourseEntityTeacherPropertyCreatesClassNamePostfix()
        {
            var courseType = GetTypeOfClassName("Course");

            var courseEntity = new Entity(courseType);

            var teacherProp = courseEntity.Properties.FirstOrDefault(x => x.Name == "Teacher");

            Assert.Equal("TeacherDto", teacherProp.GetTypeNameWithPostfix("CodeGenerator.Core.SampleModel.Entities", "Dto"));
        }


        private EntityReaderService GetEntityReaderService()
        {
            return new EntityReaderService();
        }

        public Type GetTypeOfClassName(string className)
        {
            var absPathDll = TestHelper.GetTestAssemblyPath();

            var entityReader = GetEntityReaderService();

            var classTypes = entityReader.GetAllTypes(absPathDll, new[] { TestHelper.AssemblyName + ".Entities" }).ToList();

            return classTypes.FirstOrDefault(x => x.Name == className);
        }
    }
}
