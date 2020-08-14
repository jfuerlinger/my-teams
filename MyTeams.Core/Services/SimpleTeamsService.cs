using MyTeams.Core.Contracts;
using MyTeams.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace MyTeams.Core.Services
{
  public class SimpleTeamsService : ITeamsService
  {
    private const double PropabilityOfImageMessage = 0.3;

    private Timer _timer;
    private Random _random;

    private List<Team> _teams;
    private List<User> _users;

    private List<Message> _messagesToBeSent;


    private readonly string[] _messages = new string[]
    {
      "Was werden wir heute im Unterricht lernen?",
      "Lässig",
      "Ich freue mich drauf!",
      "Ich bin super vorbereitet, ihr auch?",
      "Ja, klar!!",
      "Wann ist der Test?"
    };

    public User CurrentUser { get; }

    public SimpleTeamsService(User user)
    {
      _random = new Random();
      _messagesToBeSent = new List<Message>();

      CurrentUser = user;

      InitTeams();
      InitUsers();
      InitTimer();
    }

    private void InitUsers()
    {
      _users = new List<User>()
      {
        new User() { Firstname="Simon", Lastname="Aichmayr", Id=2},
        new User() { Firstname="Bernhard", Lastname="Grasch", Id=3},
        new User() { Firstname="Michael", Lastname="Kienberger", Id=4},
        new User() { Firstname="Oscar", Lastname="Yim", Id=5},
      };
    }

    private void InitTimer()
    {
      _timer = new Timer(500);
      _timer.Elapsed += (sender, args) => SimulateService();
      _timer.AutoReset = true;
      _timer.Enabled = true;
    }

    private void SimulateService()
    {
      GenerateNewMessage();
      ProcessMessagesToBeSent();
    }

    private void ProcessMessagesToBeSent()
    {
      var toBeProcessed =
        _messagesToBeSent
          .Where(message => message.Sent <= DateTime.Now)
          .ToArray();

      for (int i = 0; i < toBeProcessed.Count(); i++)
      {
        Message message = toBeProcessed[i];
        OnMessageReceived(message);
        _messagesToBeSent.Remove(message);
      }
    }

    private void GenerateNewMessage()
    {
      Message newMessage;
      if (_random.NextDouble() < PropabilityOfImageMessage)
      {
        newMessage = new ImageMessage()
        {
          Channel = GetRandomChannel(),
          From = GetRandomUser(),
          Text = GetRandomMessage(),
          Sent = DateTime.Now.AddSeconds(_random.NextDouble()),
          ImageUrl = $"https://picsum.photos/id/{_random.Next(500)}/200"
        };
      }
      else
      {
        newMessage = new Message()
        {
          Channel = GetRandomChannel(),
          From = GetRandomUser(),
          Text = GetRandomMessage(),
          Sent = DateTime.Now.AddSeconds(_random.NextDouble())
        };
      }


      _messagesToBeSent.Add(newMessage);
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


    private void InitTeams()
    {
      _teams = new List<Team>
      {
        new Team("POS 5ACIF_AKIF [2019-2020]", new [] { "Allgemein", "10 Termin 14.05.2020", "11 Termin 21.05.2020 (Chrisi Himmelfahrt)" }),
        new Team("DA 2020_21 Stylist", new [] { "Allgemein", "Abstimmungen", "Beurteilung" }),
        new Team("DA 2020_21 Ticketsystem", new [] { "Allgemein", "Abstimmungen", "Beurteilung" }),
      };
    }

    public IEnumerable<Team> GetTeams() => _teams;

    public event MessageReceivedHandler MessageReceived;

    protected virtual void OnMessageReceived(Message message)
    {
      MessageReceived?.Invoke(message);
    }

  }
}
