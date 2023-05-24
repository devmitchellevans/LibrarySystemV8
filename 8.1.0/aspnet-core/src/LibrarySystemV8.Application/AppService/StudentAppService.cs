using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using LibrarySystem.AppService;
using LibrarySystem.AppService.Dto;
using LibrarySystemV8.AppService.Dto;
using LibrarySystemV8.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemV8.AppService
{
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>, IStudentAppService
    {
        public readonly IRepository<Student> _studentRepository;

        public StudentAppService(IRepository<Student, int> repository, IRepository<Department> departmentRepository, IRepository<Student> studentRepository) : base(repository)
        {
            _studentRepository = studentRepository;
        }

        public override Task<StudentDto> CreateAsync(CreateStudentDto input)
            {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<StudentDto>> GetAllAsync(PagedStudentResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<StudentDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<StudentDto> UpdateAsync(StudentDto input)
        {
            return base.UpdateAsync(input);
        }

        public  async Task<PagedResultDto<StudentDto>> GetAllStudentsWithDepartment(PagedStudentResultRequestDto input)
        {
            var query =  await _studentRepository.GetAll()
                .Include(x => x.DepartmentFk)
                .Select(x => ObjectMapper.Map<StudentDto>(x))
                .ToListAsync();
                


           return new PagedResultDto<StudentDto>(query.Count(), query);
        }

        public async Task<List<StudentDto>> GetAllStudentAsync()
        {
            var students = await _studentRepository.GetAll()
                .Select(x => ObjectMapper.Map<StudentDto>(x))
                .ToListAsync();
            return students;
        }
    }
}
