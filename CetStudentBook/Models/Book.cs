using System.ComponentModel.DataAnnotations;

namespace CetStudentBook.Models;

public class Book
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage =" Name must be between 2 and 200 characters long."]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Author is required")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Author must be between 2 and 200 characters long.")]
        public string Author { get; set; }
        
        [Required(ErrorMessage = "Publish Date is required")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        
        [Required(ErrorMessage = "Page Count is required")]
        [Range(1, 10000, ErrorMessage = "Page Count must be between 1 and 10000.")]
        public int PageCount { get; set; }
        
        [Required]
        public bool IsSecondHand { get; set; }
    }
}