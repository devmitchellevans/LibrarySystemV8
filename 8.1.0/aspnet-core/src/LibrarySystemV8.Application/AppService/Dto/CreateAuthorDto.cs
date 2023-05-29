using Abp.AutoMapper;
using LibrarySystemV8.Entities;

namespace LibrarySystem.AppService.Dto
{
    [AutoMapFrom(typeof(AuthorDto))]
    [AutoMapTo(typeof(Author))]
    public class CreateAuthorDto
    {
        public string Name { get; set; }
    }
}
