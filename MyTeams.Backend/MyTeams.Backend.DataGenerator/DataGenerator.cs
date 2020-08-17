using MyTeams.Backend.Core.Contracts;
using MyTeams.Backend.Core.Model;
using MyTeams.Backend.DataGenerator.Infrastructure;
using MyTeams.Backend.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeams.Backend.DataGenerator
{
  class DataGenerator
  {
    private const double _propabilityOfImageMessage = 0.7;

    private Random _random;

    private List<Team> _teams;
    private List<User> _users;

    private readonly string[] _messages = new string[]
    {
      "Was werden wir heute im Unterricht lernen?",
      "Lässig",
      "Ich freue mich drauf!",
      "Ich bin super vorbereitet, ihr auch?",
      "Ja, klar!!",
      "Wann ist der Test?"
    };

    public async Task PerformCleanup()
    {
      using IUnitOfWork uow = new UnitOfWork();

      Console.Write("Deleting the database ...");
      await uow.DeleteDatabaseAsync();
      Console.WriteLine("  [DONE]");
    }

    public async Task PerformInit()
    {
      using IUnitOfWork uow = new UnitOfWork();

      Console.Write("Deleting the database ...");
      await uow.DeleteDatabaseAsync();
      Console.WriteLine("  [DONE]");

      Console.Write("Migrating the database ...");
      await uow.MigrateDatabaseAsync();
      Console.WriteLine("  [DONE]");
    }

    public async Task PerformGeneration(GenerateOptions options)
    {
      if (options.WithInitialization)
      {
        await PerformInit();
      }

      await InitData();

      _random = new Random();

      using IUnitOfWork uow = new UnitOfWork();
      for (int i = 0; options.IsEndless || i < options.NrOfGenerations; i++)
      {
        await GenerateMessagesAsync(uow);
        await Task.Delay(_random.Next(500));
      }
    }

    private async Task InitData()
    {
      using IUnitOfWork uow = new UnitOfWork();

      InitUsers();
      InitTeamsAndChannels();

      await uow.UserRepository.AddRangeAsync(_users);
      await uow.TeamRepository.AddRangeAsync(_teams);
      await uow.SaveChangesAsync();
    }

    private void InitTeamsAndChannels()
    {
      _teams = new List<Team>
      {
        new Team()
        {
          DisplayName = "POS 5ACIF_AKIF [2019-2020]",
          Channels =  {
            new Channel() { DisplayName = "Allgemein" },
            new Channel() {DisplayName="10 Termin 14.05.2020" },
            new Channel() {DisplayName ="11 Termin 21.05.2020 (Chrisi Himmelfahrt)" }
          }
        },
        new Team()
        {
          DisplayName = "DA 2020_21 Stylist",
          Channels =  {
            new Channel() { DisplayName = "Allgemein" },
            new Channel() {DisplayName="Abstimmungen" },
            new Channel() {DisplayName ="Beurteilung" }
          }
        },
        new Team() {
          DisplayName = "DA 2020_21 Ticketsystem",
          Channels =  {
            new Channel() { DisplayName = "Allgemein" },
            new Channel() {DisplayName="Abstimmungen" },
            new Channel() {DisplayName ="Beurteilung" }
          }
        }
      };
    }

    private void InitUsers()
    {
      _users = new List<User>()
      {
        new User() { Firstname="Simon", Lastname="Aichmayr"},
        new User() { Firstname="Bernhard", Lastname="Grasch"},
        new User() { Firstname="Michael", Lastname="Kienberger"},
        new User() { Firstname="Oscar", Lastname="Yim"},
      };
    }

    private async Task GenerateMessagesAsync(IUnitOfWork uow)
    {
      await GenerateNewMessageAsync(uow);
      await uow.SaveChangesAsync();
    }

    private Channel GetRandomChannel()
    {
      var channels =
        _teams
          .SelectMany(team => team.Channels)
          .ToList();

      return channels.ElementAt(_random.Next(channels.Count()));
    }

    private User GetRandomUser() => _users.ElementAt(_random.Next(_users.Count()));
    private string GetRandomMessage() => _messages[_random.Next(_messages.Length)];

    private async Task GenerateNewMessageAsync(IUnitOfWork unitOfWork)
    {
      int nrOfMessagesToCreate = _random.Next(100);

      for (int i = 0; i < nrOfMessagesToCreate; i++)
      {
        Message newMessage;
        if (_random.NextDouble() < _propabilityOfImageMessage)
        {
          newMessage = new ImageMessage()
          {
            ChannelId = GetRandomChannel().Id,
            FromId = GetRandomUser().Id,
            Text = GetRandomMessage(),
            Sent = DateTime.Now.AddSeconds(_random.NextDouble()),
            ImageUrl = $"https://picsum.photos/id/{_random.Next(500)}/200"
          };
        }
        else
        {
          newMessage = new Message()
          {
            ChannelId = GetRandomChannel().Id,
            FromId = GetRandomUser().Id,
            Text = GetRandomMessage(),
            Sent = DateTime.Now.AddSeconds(_random.NextDouble())
          };
        }

        await unitOfWork.MessageRepository.AddAsync(newMessage);
      }

      Console.WriteLine($"[{DateTime.Now:dd.MM.yyyy hh:mm:ss}] Messages Created: {nrOfMessagesToCreate,3}");
    }
  }
}
