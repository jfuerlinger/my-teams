using MyTeams.WpfApp.Infrastructure;
using System;

namespace MyTeams.UI.Model
{
  public class NavigationEntry
  {
    public string Label { get; }
    public ViewModelBase ViewModel { get; }
    public Uri ImageUrl { get; }

    public NavigationEntry(string label, string imageUrl, ViewModelBase viewModel)
    {
      Label = label ?? throw new ArgumentNullException(nameof(label));
      ImageUrl = new Uri(imageUrl ?? throw new ArgumentNullException(nameof(imageUrl)), UriKind.Relative);
      ViewModel = viewModel;
    }
  }
}
