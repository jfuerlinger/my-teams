﻿using MyTeams.Core.Model;
using System.Windows;
using System.Windows.Controls;

namespace MyTeams.WpfApp.Controls
{
  /// <summary>
  /// Interaction logic for AddTeamControl.xaml
  /// </summary>
  public partial class TeamsAreaControl : UserControl
  {
    public TeamsAreaControl()
    {
      InitializeComponent();
      Loaded += TeamsOverviewControl_Loaded;
    }

    private void TeamsOverviewControl_Loaded(object sender, RoutedEventArgs e)
    {

    }

    // Dependency Property
    public static readonly DependencyProperty SelectedChannelProperty =
         DependencyProperty.Register(nameof(SelectedChannel), typeof(Channel),
         typeof(TeamsAreaControl), new FrameworkPropertyMetadata(null));

    // .NET Property wrapper
    public Channel SelectedChannel
    {
      get { return (Channel)GetValue(SelectedChannelProperty); }
      set { SetValue(SelectedChannelProperty, value); }
    }
  }
}
