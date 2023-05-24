using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystem.AppService.Dto;
using LibrarySystemV8.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.AppService
{
    public class DepartmentAppService : AsyncCrudAppService<Department, DepartmentDto, int, PagedDepartmentResultRequestDto, CreateDepartmentDto, DepartmentDto>, IDepartmentAppService
    {

        public readonly IRepository<Department> _departmentRepository;
        public DepartmentAppService(IRepository<Department, int> repository, IRepository<Department> departmentRepository) : base(repository)
        {
            _departmentRepository = departmentRepository;
        }

        public override Task<DepartmentDto> CreateAsync(CreateDepartmentDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<DepartmentDto>> GetAllAsync(PagedDepartmentResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<DepartmentDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<DepartmentDto> UpdateAsync(DepartmentDto input)
        {
            return base.UpdateAsync(input);
        }

        public async Task<List<DepartmentDto>> GetAllDepartmentAsync()
        {
            var departments = await _departmentRepository.GetAll()
                .Select(x => ObjectMapper.Map< DepartmentDto > (x))
                .ToListAsync();

            return departments;
        }

    }
}
