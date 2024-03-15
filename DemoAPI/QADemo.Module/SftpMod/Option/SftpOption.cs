namespace QADemo.Module.SftpMod.Option {
     public class SftpOption {
        public const string Section = "Sftp";

        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
     }
}