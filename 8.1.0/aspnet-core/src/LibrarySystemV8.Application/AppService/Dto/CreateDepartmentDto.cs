using Abp.AutoMapper;
using LibrarySystemV8.Entities;

namespace LibrarySystem.AppService.Dto
{
    [AutoMapFrom(typeof(DepartmentDto))]
    [AutoMapTo(typeof(Department))]
    public class CreateDepartmentDto
    {
        public string Name { get; set; }
    }
}
