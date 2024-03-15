namespace QADemo.Module.MailMod.Bo
{
    public class MailMessageBo
    {
        public string From { get; set; } = string.Empty;
        public string FromName { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string ToName { get; set; } = string.Empty;
        public List<string?> Cc { get; set; } = [];
        public List<string?> Bcc { get; set; } = [];
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public List<AttachmentBo?> Attachments { get; set; } = [];
        public string? TemplateId { get; set; }
        public Dictionary<string, string> TemplateParamters { get; set; } = [];
        public string? ConfigurationSetHeader { get; set; }

        public class AttachmentBo
        {
            public string FileName { get; set; } = string.Empty;
            // 服務table欄位
            public string LinkType { get; set; } = string.Empty;
            public string FilePath { get; set; } = string.Empty;
        }

    }


}