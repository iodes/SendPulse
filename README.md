# SendPulse
[![Release](https://img.shields.io/badge/Release-v1.0.0-brightgreen.svg)](https://github.com/iodes/SendPulse/releases)
[![NuGet](https://img.shields.io/badge/NuGet-v1.0.0-blue.svg)](https://www.nuget.org/packages/SendPulse.SDK/)  
Managed SendPulse .NET SDK  
[SendPulse](https://sendpulse.com) is an Email marketing service maximizing open rates automatically.  
Send up to 15,000 e-mails every month fo free.

# Getting Started
## Send Email
```csharp
using (var sendPulse = new SendPulseService("CLIENT_ID", "CLIENT_SECRET"))
{
    await sendPulse.SendEmailAsync(new EmailData
    {
        Subject = "Sample Subject",
        From = new EmailAddress
        {
            Name = "Sender Name",
            Address = "sender@example.com"
        },
        To = new List<EmailAddress>
        {
            new EmailAddress
            {
                Name = "Recipient Name",
                Address = "recipient@example.com"
            }
        },
        HTML = "<p>Example Text</p>",
        Text = "Example Text"
    });
}
```

## Send Email From Template
```csharp
using (var sendPulse = new SendPulseService("CLIENT_ID", "CLIENT_SECRET"))
{
    await sendPulse.SendEmailAsync(new EmailData
    {
        Subject = "Sample Subject",
        From = new EmailAddress
        {
            Name = "Sender Name",
            Address = "sender@example.com"
        },
        To = new List<EmailAddress>
        {
            new EmailAddress
            {
                Name = "Recipient Name",
                Address = "recipient@example.com"
            }
        },
        TemplateID = "TEMPLATE_ID",
        TemplateVariables = new Dictionary<string, string>
        {
            { "ec_es_email_sender_company", "Company Name" },
            { "ec_es_email_sender_address", "Sender Address" },
            { "current_year", "2019" }
        }
    });
}
```

# Features
* Lightweight library based on .NET Standard
* Send mail with text and HTML or Template
* Get Balance info of SendPulse account
