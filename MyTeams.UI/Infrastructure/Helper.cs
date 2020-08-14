using System.Windows;
using System.Windows.Controls;

namespace MyTeams.UI.Infrastructure
{
  public static class Helper
  {
    #region AutoScroll-Property für ScrollViewer -> Siehe ScrollViewer in TeamsAreaControl

    public static readonly DependencyProperty AutoScrollProperty =
       DependencyProperty.RegisterAttached("AutoScroll", typeof(bool), typeof(Helper), new PropertyMetadata(false, AutoScrollPropertyChanged));

    private static void AutoScrollPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var scrollViewer = d as ScrollViewer;

      if (scrollViewer != null && (bool)e.NewValue)
      {
        scrollViewer.ScrollToBottom();
      }
    }

    public static bool GetAutoScroll(DependencyObject obj)
    {
      return (bool)obj.GetValue(AutoScrollProperty);
    }

    public static void SetAutoScroll(DependencyObject obj, bool value)
    {
      obj.SetValue(AutoScrollProperty, value);
    }
    
    #endregion
  }
}
