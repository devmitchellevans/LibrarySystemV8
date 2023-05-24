using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystem.AppService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemV8.AppService
{
    public interface IStudentAppService : IAsyncCrudAppService<StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>
    {
        Task<PagedResultDto<StudentDto>> GetAllStudentsWithDepartment(PagedStudentResultRequestDto input);
        Task<List<StudentDto>> GetAllStudentAsync();
    }
}
