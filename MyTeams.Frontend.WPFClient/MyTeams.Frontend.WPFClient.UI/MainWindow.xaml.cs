using MyTeams.Core.Model;
using MyTeams.Core.Services;
using MyTeams.WpfApp.ViewModels;
using System.Windows;

namespace MyTeams.WpfApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      MainViewModel mainViewModel = new MainViewModel(new SimpleTeamsService(new User() { Id = 1, Firstname = "Josef", Lastname = "Fürlinger" }));
      DataContext = mainViewModel;
    }
  }
}
