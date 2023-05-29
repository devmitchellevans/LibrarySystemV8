using Abp.Domain.Entities.Auditing;

namespace LibrarySystemV8.Entities
{
    public class Book :FullAuditedEntity<int>
    {
        public string BookTitle { get; set; }
        public string BookPublisher { get ; set; }
        public bool IsBorrowed { get; set; }
        public int BookCategoryId { get; set; }
        public BookCategory BookCategoryFk { get; set; }
        public int AuthorId { get; set; }
        public Author AuthorFk{ get; set; }

    }
}