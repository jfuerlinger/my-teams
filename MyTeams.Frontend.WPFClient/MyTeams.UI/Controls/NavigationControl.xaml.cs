using MyTeams.UI.Model;
using System.Windows;
using System.Windows.Controls;

namespace MyTeams.WpfApp.Controls
{
  /// <summary>
  /// Interaction logic for NavigationControl.xaml
  /// </summary>
  public partial class NavigationControl : UserControl
  {
    public NavigationControl()
    {
      InitializeComponent();
    }

    // Dependency Property
    public static readonly DependencyProperty SelectedNavigationEntryProperty =
         DependencyProperty.Register(nameof(SelectedNavigationEntry), typeof(NavigationEntry),
         typeof(NavigationControl), new FrameworkPropertyMetadata(null));

    // .NET Property wrapper
    public NavigationEntry SelectedNavigationEntry
    {
      get { return (NavigationEntry)GetValue(SelectedNavigationEntryProperty); }
      set { SetValue(SelectedNavigationEntryProperty, value); }
    }
  }
}
