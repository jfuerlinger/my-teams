﻿using MyTeams.Core.Contracts;
using MyTeams.UI.ViewModels;
using MyTeams.WpfApp.Infrastructure;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyTeams.WpfApp.ViewModels
{
  public class TeamsOverviewViewModel : ViewModelBase
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

    public TeamsOverviewViewModel(ITeamsService teamsService) : base(teamsService)
    {
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
