using MyTeams.Core.Contracts;
using MyTeams.UI.ViewModels;
using MyTeams.WpfApp.Infrastructure;

namespace MyTeams.WpfApp.ViewModels
{
  class MainViewModel : ViewModelBase
  {
    public TeamsAreaViewModel TeamsAreaViewModel { get; private set; }
    public NavigationViewModel  NavigationViewModel { get; private set; }

    public MainViewModel(ITeamsService teamsService) : base(teamsService)
    {
      TeamsAreaViewModel = new TeamsAreaViewModel(TeamsService);
      NavigationViewModel = new NavigationViewModel(TeamsService);
    }

  }
}
