using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RockyApp.Models
{
    public class ApplicationType
    {
        [Key]
       
        public int Id { get; set; }
        [DisplayName("Application Name")]
        [Required]
        public string Name { get; set; }

    }
}
