using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaTimeDemo.Models.Models {

    [Table(name: "questions")]
    public class Questions {
        [Key]
        [Column("id")]
        public long Id {get; set;}
        [Required]
        [Column("title")]
        public string Title {get; set;} = null!;
        [Required]
        [Column("content")]
        public string Content {get; set;} = null!;
        [Column("tags")]
        public List<string> Tags {get; set;} = null!;
        [Required]
        [Column("created_on")]
        public DateTime CreatedNo {get; set;}

    }
    
}