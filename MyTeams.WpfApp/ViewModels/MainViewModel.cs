using MyTeams.Core.Contracts;
using MyTeams.WpfApp.Infrastructure;

namespace MyTeams.WpfApp.ViewModels
{
  class MainViewModel : ViewModelBase
  {
    public TeamsOverviewViewModel TeamsOverviewViewModel { get; private set; }

    public MainViewModel(ITeamsService teamsService) : base(teamsService)
    {
      TeamsOverviewViewModel = new TeamsOverviewViewModel(TeamsService);
    }

  }
}
