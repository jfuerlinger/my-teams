using MyTeams.Core.Contracts;
using MyTeams.UI.Model;
using MyTeams.WpfApp.Infrastructure;
using MyTeams.WpfApp.ViewModels;
using System.Collections.ObjectModel;

namespace MyTeams.UI.ViewModels
{
  public class NavigationViewModel : ViewModelBase
  {
    private NavigationEntry _selectedNavigationEntry;

    public ObservableCollection<NavigationEntry> NavigationEntries { get; private set; }

    public NavigationEntry SelectedNavigationEntry
    {
      get => _selectedNavigationEntry;
      set
      {
        _selectedNavigationEntry = value;
        OnPropertyChanged();
      }
    }

    public NavigationViewModel(ITeamsService teamsService) : base(teamsService)
    {
      NavigationEntries = new ObservableCollection<NavigationEntry>();

      InitNavigationEntries();
    }

    private void InitNavigationEntries()
    {
      NavigationEntries.Add(new NavigationEntry("Aktivität", "/Images/activity_32.png", null));
      NavigationEntries.Add(new NavigationEntry("Chat", "/Images/chat_32.png", null));
      NavigationEntries.Add(new NavigationEntry("Teams", "/Images/teams_32.png", new TeamsAreaViewModel(TeamsService)));
    }
  }
}
