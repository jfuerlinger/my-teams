using Microsoft.Rest;
using MyTeams.Frontend.ServicePoC;
using System;
using System.Threading.Tasks;

namespace MyTEams.Frontend.ServicePoc
{
  class Program
  {
    private static void Main(string[] args)
    {
      new Program().Run().GetAwaiter().GetResult();
    }

    public async Task Run()
    {
      ServicePoCClient client = new ServicePoCClient(new BasicAuthenticationCredentials());
      client.BaseUri = new Uri("https://localhost:44328/");
      DateTime lastFetchTime = DateTime.Now;
      while (true)
      {
        var messages = await client.Messages.GetMessagesByChannelIdAsync(lastFetchTime);
        lastFetchTime = DateTime.Now;

        Console.WriteLine($"{DateTime.Now:dd.MM.yyyy hh:mm:ss}: {messages.Count:d4} new messages");

        await Task.Delay(3000);
      }
    }
  }
}
