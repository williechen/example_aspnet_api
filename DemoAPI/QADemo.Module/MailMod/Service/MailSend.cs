using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QADemo.Module.MailMod.Option;
using static QADemo.Module.MailMod.Bo.MailMessageBo;

namespace QADemo.Module.MailMod.Bo
{
    public class MailSend
    {
        private readonly ILogger<MailSend> _logger;
        private readonly MailOption _option;
        private readonly SmtpClient? _smtpClient;
        public MailSend(ILogger<MailSend> logger,
            IOptions<MailOption> options)
        {
            _logger = logger;
            _option = options.Value;
            try
            {
                _smtpClient = new SmtpClient()
                {
                    Host = _option.Host,
                    Port = _option.Port,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(_option.Username, _option.Password),
                };
                _smtpClient.ServicePoint.MaxIdleTime = 1;
                _smtpClient.ServicePoint.ConnectionLimit = 1;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception");
            }
        }
        public async Task<bool> Run(MailMessageBo mmb)
        {
            var result = false;
            if (_smtpClient != null)
            {
                try
                {
                    var mail = new MailMessage();
                    mail.IsBodyHtml = true;

                    mail.From = new MailAddress(mmb.From, mmb.FromName);
                    mail.To.Add(new MailAddress(mmb.To, mmb.ToName));
                    if (mmb.Cc.Count > 0)
                    {
                        foreach (string ccMail in mmb.Cc)
                        {
                            if (ccMail != null && ccMail != "")
                            {
                                mail.CC.Add(new MailAddress(ccMail));
                            }

                        }
                    }
                    if (mmb.Bcc.Count > 0)
                    {
                        foreach (string bccMail in mmb.Bcc)
                        {
                            if (bccMail != null && bccMail != "")
                            {
                                mail.Bcc.Add(new MailAddress(bccMail));
                            }

                        }
                    }
                    mail.Subject = mmb.Subject;
                    mail.Body = mmb.Body;

                    if (mmb.Attachments.Count > 0)
                    {
                        foreach (AttachmentBo attachment in mmb.Attachments)
                        {
                            if (attachment.FilePath != null && attachment.FilePath != "")
                            {
                                mail.Attachments.Add(new Attachment(attachment.FilePath, attachment.FileName));
                            }

                        }
                    }

                    await _smtpClient.SendMailAsync(mail);
                    result = true;
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