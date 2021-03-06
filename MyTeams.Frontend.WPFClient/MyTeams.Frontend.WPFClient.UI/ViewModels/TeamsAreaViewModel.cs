﻿using ActReport.ViewModel;
using MyTeams.Core.Contracts;
using MyTeams.UI.ViewModels;
using MyTeams.WpfApp.Infrastructure;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace MyTeams.WpfApp.ViewModels
{
  public class TeamsAreaViewModel : ViewModelBase
  {
    private ChannelViewModel _currentChannel;

    public ObservableCollection<ChannelViewModel> Channels { get; set; }

    public ChannelViewModel CurrentChannel
    {
      get => _currentChannel;
      set
      {
        _currentChannel = value;
        _currentChannel.UnreadMessages = 0;
        OnPropertyChanged();
      }
    }

    public ICommand AddTeamCommand { get; private set; }

    public TeamsAreaViewModel(ITeamsService teamsService) : base(teamsService)
    {
      AddTeamCommand = new RelayCommand(
        execute: (_) => Debug.WriteLine("TODO: Add team per web admin interface"),
        canExecute: (_) => false);

      Channels = new ObservableCollection<ChannelViewModel>();

      TeamsService
        .GetTeams()
        .SelectMany(team => team.Channels)
        .ToList()
        .ForEach(channel => Channels.Add(new ChannelViewModel(teamsService, channel)));

      CurrentChannel = Channels.FirstOrDefault();
    }
  }
}
