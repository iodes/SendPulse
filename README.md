# SendPulse
[![Release](https://img.shields.io/badge/Release-v1.0.0-brightgreen.svg)](https://github.com/iodes/SendPulse/releases)
[![NuGet](https://img.shields.io/badge/NuGet-v1.0.0-blue.svg)](https://www.nuget.org/packages/SendPulse.SDK/)  
Managed SendPulse .NET SDK

# Getting Started
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
