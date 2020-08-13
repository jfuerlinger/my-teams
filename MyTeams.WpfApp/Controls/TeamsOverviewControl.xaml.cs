using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyTeams.WpfApp.Controls
{
  /// <summary>
  /// Interaction logic for AddTeamControl.xaml
  /// </summary>
  public partial class TeamsOverviewControl : UserControl
  {
    public TeamsOverviewControl()
    {
      InitializeComponent();
      Loaded += TeamsOverviewControl_Loaded;
    }

    private void TeamsOverviewControl_Loaded(object sender, RoutedEventArgs e)
    {
      
    }

    //public static readonly DependencyProperty SelectedChannelProperty =
    //     DependencyProperty.Register("SetText", typeof(string), typeof(TeamsOverviewControl), new
    //        PropertyMetadata("", new PropertyChangedCallback(OnSelectedChannelChanged)));

    //public Channel SelectedChannel
    //{
    //  get { return (string)GetValue(SelectedChannelProperty); }
    //  set { SetValue(SelectedChannelProperty, value); }
    //}

    //private static void OnSelectedChannelChanged(DependencyObject d,
    //   DependencyPropertyChangedEventArgs e)
    //{
    //  TeamsOverviewControl UserControl1Control = d as TeamsOverviewControl;
    //  UserControl1Control.OnSetTextChanged(e);
    //}

    //private void OnSelectedChannelChanged(DependencyPropertyChangedEventArgs e)
    //{
    //  tbTest.Text = e.NewValue.ToString();
    //}
  }
}
