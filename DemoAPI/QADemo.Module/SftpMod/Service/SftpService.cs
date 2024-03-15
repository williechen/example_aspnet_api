using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QADemo.Module.SftpMod.Option;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace QADemo.Module.SftpMod.Service{
    public class SftpService{
        private readonly ILogger<SftpService> _logger;
        private readonly SftpOption _option;
        private readonly SftpClient _sftpClient;

        public SftpService(ILogger<SftpService> logger,
            IOptions<SftpOption> options)
        {
            _logger = logger;
            _option = options.Value;
            _sftpClient = new SftpClient(_option.Host, _option.Port, _option.Username, _option.Password);
        }
        
        public IEnumerable<string> GetFileList(string filePath)
        {
            var result = new List<string>();
            if (_sftpClient != null)
            {
                _sftpClient.Connect();
                try{
                var fileList = _sftpClient.ListDirectory(filePath);
                foreach(SftpFile f in fileList){
                    Console.WriteLine(f.FullName);
                }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Exception");
                }
            }
            else
            {
                _logger.LogError("SmtpClient haven't initialization yet.");
            }
            return result;
        }

    }
}