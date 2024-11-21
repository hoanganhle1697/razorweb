using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entity_Razor.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        
        public string? Slug { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "{0} bắt buộc nhập")]
        [Column(TypeName = "nvarchar")]

        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [Column(TypeName = "ntext")]
        public string? Content { get; set; }
    }
}