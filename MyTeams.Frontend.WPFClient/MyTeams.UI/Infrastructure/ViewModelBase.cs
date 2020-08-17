using MyTeams.Core.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyTeams.WpfApp.Infrastructure
{
  public class ViewModelBase : INotifyPropertyChanged
  {
    public ViewModelBase(ITeamsService teamsService)
    {
      TeamsService = teamsService;
    }

    protected ITeamsService TeamsService { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string memberName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
    }
  }
}
