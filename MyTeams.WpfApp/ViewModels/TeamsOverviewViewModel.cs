using MyTeams.Core.Contracts;
using MyTeams.Core.Model;
using MyTeams.WpfApp.Infrastructure;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyTeams.WpfApp.ViewModels
{
  public class TeamsOverviewViewModel : ViewModelBase
  {
    public ObservableCollection<Channel> Channels { get; set; }

    public TeamsOverviewViewModel(ITeamsService teamsService) : base(teamsService)
    {
      Channels = new ObservableCollection<Channel>();

      TeamsService
        .Teams
        .SelectMany(team => team.Channels)
        .ToList()
        .ForEach(channel => Channels.Add(channel));
    }
  }
}
