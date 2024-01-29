namespace WebUI;
using MailKit.Net.Smtp;
using MimeKit;
using ZAlpha.Domain.Identity;

public class EmailSender
{
    private readonly IWebHostEnvironment _environment;

    public EmailSender(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public bool EmailSenderAsync(string toMail, string subject, string confirmLink)
    {
        if (_environment.IsDevelopment() || _environment.IsStaging())
        {
            subject = "'" + subject + "'";
        }
        var email = new MimeMessage();

        email.From.Add(MailboxAddress.Parse("zalphacpn@gmail.com"));
        email.To.Add(MailboxAddress.Parse(toMail));
        var bccAddress = new MailboxAddress("admin","zalphacpn@gmail.com");

        email.Bcc.Add(bccAddress);
        email.Subject = subject;

        var builder = new BodyBuilder();

        builder.HtmlBody = confirmLink + "<div style=\"font-weight: bold;\">Trân trọng, <br>\r\n        <div style=\"color: #FF630E;\">Bộ phận hỗ trợ học viên BSMART</div>\r\n    </div>\r\n<br>    <img src=\"cid:image1\" alt=\"\" width=\"200px\">\r\n    <br>\r\n    <br>\r\n    <div>\r\n        Email liên hệ: tuankietgg291@gmail.com\r\n    </div>\r\n    <div>Số điện thoại: 028 9999 79 39</div>\r\n</div>";
        // Khởi tạo phần đính kèm của email (ảnh)
        var attachment = builder.LinkedResources.Add("wwwroot/assets/images/zalpha.png");
        attachment.ContentId = "image1"; // Thiết lập Content-ID cho phần đính kèm

        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        smtp.Authenticate("zalphacpn@gmail.com", "iuih qwtu hzba ggfn");
        try
        {
            smtp.Send(email);

        }
        catch (SmtpCommandException ex)
        {
            return false;
        }
        smtp.Disconnect(true);
        return true;
    }

    public bool SendEmailNoBccAsync(string toMail, string subject, string confirmLink)
    {


        if (_environment.IsDevelopment() || _environment.IsStaging())
        {
            subject = "'" + subject + "'";
        }
        var email = new MimeMessage();

        email.From.Add(MailboxAddress.Parse("zalphacpn@gmail.com"));
        email.To.Add(MailboxAddress.Parse(toMail));
        email.Subject = subject;

        var builder = new BodyBuilder();

        builder.HtmlBody = confirmLink + "<div style=\"font-weight: bold;\">Trân trọng, <br>\r\n        <div style=\"color: #FF630E;\">Bộ phận hỗ trợ mạng xã hội Zalpha</div>\r\n    </div>\r\n<br>    <img src=\"cid:image1\" alt=\"\" width=\"200px\">\r\n    <br>\r\n    <br>\r\n    <div>\r\n        Email liên hệ: tuankietgg291@gmail.com\r\n    </div>\r\n    <div>Số điện thoại: 028 9999 79 39</div>\r\n</div>";
        // Khởi tạo phần đính kèm của email (ảnh)
        var attachment = builder.LinkedResources.Add("wwwroot/assets/images/zalpha.png");
        attachment.ContentId = "image1"; // Thiết lập Content-ID cho phần đính kèm

        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        smtp.Authenticate("zalphacpn@gmail.com", "iuih qwtu hzba ggfn");
        try
        {
            smtp.Send(email);
        }
        catch (SmtpCommandException ex)
        {
            return false;
        }
        smtp.Disconnect(true);
        return true;
    }

    public bool SendEmailBcc(List<UserAccount> listMail, string subject, string confirmLink)
    {
        if (_environment.IsDevelopment() || _environment.IsStaging())
        {
            subject = "'" + subject + "'";
        }
        var email = new MimeMessage();

        email.From.Add(MailboxAddress.Parse("zalphacpn@gmail.com"));
        var bccAdminAddress = new MailboxAddress("admin", "zalphacpn@gmail.com");

        email.Bcc.Add(bccAdminAddress);
        foreach (var item in listMail)
        {
            var bccAddress = new MailboxAddress(item.UserName, item.Email);

            email.Bcc.Add(bccAddress);
        }

        email.Subject = subject;

        var builder = new BodyBuilder();

        builder.HtmlBody = confirmLink + "<div style=\"font-weight: bold;\">Trân trọng, <br>\r\n        <div style=\"color: #FF630E;\">Bộ phận hỗ trợ học viên Zalpha</div>\r\n    </div>\r\n<br>    <img src=\"cid:image1\" alt=\"\" width=\"200px\">\r\n    <br>\r\n    <br>\r\n    <div>\r\n        Email liên hệ: tuankietgg291@gmail.com\r\n    </div>\r\n    <div>Số điện thoại: 028 9999 79 39</div>\r\n</div>";
        // Khởi tạo phần đính kèm của email (ảnh)
        var attachment = builder.LinkedResources.Add("wwwroot/assets/images/zalpha.png");
        attachment.ContentId = "image1"; // Thiết lập Content-ID cho phần đính kèm

        email.Body = builder.ToMessageBody();
        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        smtp.Authenticate("zalphacpn@gmail.com", "iuih qwtu hzba ggfn");
        try
        {
            smtp.Send(email);

        }
        catch (SmtpCommandException ex)
        {
            return false;
        }
        smtp.Disconnect(true);
        return true;
    }
}
