using System.Windows;
using System.Windows.Controls;

namespace MyTeams.UI.Controls
{
  /// <summary>
  /// Interaction logic for NavigationButton.xaml
  /// </summary>
  public partial class NavigationButton : UserControl
  {
    public NavigationButton()
    {
      InitializeComponent();
      Loaded += NavigationButton_Loaded;
    }

    private void NavigationButton_Loaded(object sender, RoutedEventArgs e)
    {
      
    }

    // Dependency Property
    public static readonly DependencyProperty TextProperty =
         DependencyProperty.Register(nameof(Text), typeof(string),
         typeof(NavigationButton), new FrameworkPropertyMetadata(""));

    // .NET Property wrapper
    public string Text
    {
      get { return (string)GetValue(TextProperty); }
      set { SetValue(TextProperty, value); }
    }

    // Dependency Property
    public static readonly DependencyProperty ImageUrlProperty =
         DependencyProperty.Register(nameof(ImageUrl), typeof(string),
         typeof(NavigationButton), new FrameworkPropertyMetadata(""));

    // .NET Property wrapper
    public string ImageUrl
    {
      get { return (string)GetValue(ImageUrlProperty); }
      set { SetValue(TextProperty, value); }
    }
  }
}
