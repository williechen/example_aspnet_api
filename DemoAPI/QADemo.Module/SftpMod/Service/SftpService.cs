using Microsoft.Extensions.Logging;
using QADemo.Module.SftpMod.Option;
using Renci.SshNet;

namespace QADemo.Module.SftpMod.Service{
    public class SftpService{
        private readonly ILogger<SftpService> _logger;
        private readonly SftpOption _option;
        private readonly SftpClient _sftpClient;
    }
}