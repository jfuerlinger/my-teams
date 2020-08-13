using System;

namespace MyTeams.UI.Model
{
  public class MainNavigationEntry
  {
    public string Label { get; private set; }
    public Uri ImageUrl { get; private set; }

    public MainNavigationEntry(string label, string imageUrl)
    {
      if (string.IsNullOrEmpty(label))
      {
        throw new ArgumentException($"'{nameof(label)}' cannot be null or empty", nameof(label));
      }

      if (string.IsNullOrEmpty(imageUrl))
      {
        throw new ArgumentException($"'{nameof(imageUrl)}' cannot be null or empty", nameof(imageUrl));
      }

      Label = label;
      ImageUrl = new Uri(imageUrl, UriKind.Relative);
    }
  }
}
