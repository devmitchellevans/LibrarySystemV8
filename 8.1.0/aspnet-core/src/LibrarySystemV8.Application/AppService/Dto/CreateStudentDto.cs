using Abp.AutoMapper;
using LibrarySystemV8.Entities;

namespace LibrarySystem.AppService.Dto
{
    [AutoMapFrom(typeof(StudentDto))]
    [AutoMapTo(typeof(Student))]
    public class CreateStudentDto
    {
        public string StudentName { get; set; }

        public string StudentContactNumber { get; set; }
        public string StudentEmail { get; set; }

        public int DepartmentId { get; set; }

        public Department DepartmentFk { get; set; }
    }
}
