using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystem.AppService.Dto;
using LibrarySystemV8.AppService.Dto;
using LibrarySystemV8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.AppService
{
    public interface IDepartmentAppService: IAsyncCrudAppService<DepartmentDto, int, PagedDepartmentResultRequestDto, CreateDepartmentDto, DepartmentDto>
    {
         Task<List<DepartmentDto>> GetAllDepartmentAsync();
    }
}
