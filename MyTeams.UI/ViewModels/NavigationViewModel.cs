using MyTeams.Core.Contracts;
using MyTeams.UI.Model;
using MyTeams.WpfApp.Infrastructure;
using System.Collections.ObjectModel;

namespace MyTeams.UI.ViewModels
{
  public class NavigationViewModel : ViewModelBase
  {
    public ObservableCollection<MainNavigationEntry> NavigationEntries { get; private set; }

    public NavigationViewModel(ITeamsService teamsService) : base(teamsService)
    {
      NavigationEntries = new ObservableCollection<MainNavigationEntry>();

      InitNavigationEntries();
    }

    private void InitNavigationEntries()
    {
      NavigationEntries.Add(new MainNavigationEntry("Aktivität", "/Images/activity_32.png"));
      NavigationEntries.Add(new MainNavigationEntry("Chat", "/Images/chat_32.png"));
      NavigationEntries.Add(new MainNavigationEntry("Teams", "/Images/teams_32.png"));
    }
  }
}
