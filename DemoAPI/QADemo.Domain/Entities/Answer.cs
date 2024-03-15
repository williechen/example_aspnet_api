using System;
using System.Collections.Generic;

namespace QADemo.Domain.Entities;

public partial class Answer
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public int? CorrespondingQuestion { get; set; }

    public virtual Question? CorrespondingQuestionNavigation { get; set; }
}
