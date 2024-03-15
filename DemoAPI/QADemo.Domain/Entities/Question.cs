using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QADemo.Domain.Entities;

public partial class Question
{
    public int Id { get; set; }
    [Required(ErrorMessage = "標題必填")]
    public string Title { get; set; } = null!;
    [Required]
    public string Content { get; set; } = null!;

    public List<string>? Tags { get; set; }
    [Required]
    public DateTime CreatedOn { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
}
