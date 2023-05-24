using System.ComponentModel.DataAnnotations;

namespace LibrarySystemV8.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}