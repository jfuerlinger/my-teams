using MyTeams.Core.Contracts;
using MyTeams.UI.Model;
using MyTeams.WpfApp.Infrastructure;
using System;
using System.Collections.ObjectModel;

namespace MyTeams.UI.ViewModels
{
  public class MainNavigationViewModel : ViewModelBase
  {
    public ObservableCollection<MainNavigationEntry> NavigationEntries { get; private set; }

    public MainNavigationViewModel(ITeamsService teamsService) : base(teamsService)
    {
      NavigationEntries = new ObservableCollection<MainNavigationEntry>();

      InitNavigationEntries();
    }

    private void InitNavigationEntries()
    {
      NavigationEntries.Add(new MainNavigationEntry("Aktivität", "/Images/activity_32.png"));
      NavigationEntries.Add(new MainNavigationEntry("Chat", "/Images/chat_32.png"));
      NavigationEntries.Add(new MainNavigationEntry("Teams", "/Images/conversation_32.png"));
      NavigationEntries.Add(new MainNavigationEntry("Aufgaben", "/Images/conversation_32.png"));
      NavigationEntries.Add(new MainNavigationEntry("Kalender", "/Images/conversation_32.png"));
      NavigationEntries.Add(new MainNavigationEntry("Anrufe", "/Images/conversation_32.png"));
      NavigationEntries.Add(new MainNavigationEntry("Dateien", "/Images/conversation_32.png"));
    }
  }
}
