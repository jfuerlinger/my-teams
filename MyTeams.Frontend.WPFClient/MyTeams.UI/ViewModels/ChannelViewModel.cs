using MyTeams.Core.Contracts;
using MyTeams.Core.Model;
using MyTeams.WpfApp.Infrastructure;
using System.Collections.ObjectModel;
using System.Windows;

namespace MyTeams.UI.ViewModels
{
  public class ChannelViewModel : ViewModelBase
  {
    private int _unreadMessages;

    public Channel Channel { get; private set; }

    public ObservableCollection<Message> Messages { get; private set; }

    public int UnreadMessages
    {
      get => _unreadMessages;

      set
      {
        _unreadMessages = value;
        OnPropertyChanged();
      }
    }

    public ChannelViewModel(ITeamsService teamsService, Channel channel) : base(teamsService)
    {
      Channel = channel;

      Messages = new ObservableCollection<Message>();

      TeamsService.MessageReceived += TeamsService_MessageReceived;
    }

    private void TeamsService_MessageReceived(Message message)
    {
      if (message.Channel == Channel)
      {
        Application.Current.Dispatcher.Invoke(() => { 
          Messages.Add(message);
          UnreadMessages++;
        });
      }
    }
  }
}
