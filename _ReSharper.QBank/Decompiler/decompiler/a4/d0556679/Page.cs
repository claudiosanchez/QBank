// Type: System.Windows.Controls.Page
// Assembly: System.Windows.Controls.Navigation, Version=2.0.5.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Program Files (x86)\Microsoft SDKs\Silverlight\v4.0\Libraries\Client\System.Windows.Controls.Navigation.dll

using System.Windows;
using System.Windows.Navigation;

namespace System.Windows.Controls
{
  /// <summary>
  /// Encapsulates content that can be navigated to by a <see cref="T:System.Windows.Controls.Frame"/>.
  /// </summary>
  public class Page : UserControl
  {
    /// <summary>
    /// Gets an object that contains information about the navigation request.
    /// </summary>
    /// 
    /// <returns>
    /// An object that contains information about the navigation request.
    /// </returns>
    public NavigationContext NavigationContext
    {
      get
      {
        return JournalEntry.GetNavigationContext((DependencyObject) this);
      }
    }

    /// <summary>
    /// Gets the service that the host used to navigate to this page.
    /// </summary>
    /// 
    /// <returns>
    /// The service the host used to navigate to this page.
    /// </returns>
    public NavigationService NavigationService
    {
      get
      {
        return NavigationService.GetNavigationService((DependencyObject) this);
      }
    }

    /// <summary>
    /// Gets or sets the name for the page.
    /// </summary>
    /// 
    /// <returns>
    /// The name for the page.
    /// </returns>
    public string Title
    {
      get
      {
        return JournalEntry.GetName((DependencyObject) this);
      }
      set
      {
        JournalEntry.SetName((DependencyObject) this, value);
      }
    }

    /// <summary>
    /// Gets or sets a value that indicates whether this page is cached and whether it is cached indefinitely.
    /// </summary>
    /// 
    /// <returns>
    /// The value that specifies the caching behavior for this page.
    /// </returns>
    public NavigationCacheMode NavigationCacheMode
    {
      get
      {
        return NavigationCache.GetNavigationCacheMode((DependencyObject) this);
      }
      set
      {
        NavigationCache.SetNavigationCacheMode((DependencyObject) this, value);
      }
    }

    internal void InternalOnFragmentNavigation(FragmentNavigationEventArgs e)
    {
      this.OnFragmentNavigation(e);
    }

    internal void InternalOnNavigatedTo(NavigationEventArgs e)
    {
      this.OnNavigatedTo(e);
    }

    internal void InternalOnNavigatingFrom(NavigatingCancelEventArgs e)
    {
      this.OnNavigatingFrom(e);
    }

    internal void InternalOnNavigatedFrom(NavigationEventArgs e)
    {
      this.OnNavigatedFrom(e);
    }

    /// <summary>
    /// Called when navigating to a fragment on a page.
    /// </summary>
    /// <param name="e">An object that contains the event data.</param>
    protected virtual void OnFragmentNavigation(FragmentNavigationEventArgs e)
    {
    }

    /// <summary>
    /// Called when a page becomes the active page in a frame.
    /// </summary>
    /// <param name="e">An object that contains the event data.</param>
    protected virtual void OnNavigatedTo(NavigationEventArgs e)
    {
    }

    /// <summary>
    /// Called just before a page is no longer the active page in a frame.
    /// </summary>
    /// <param name="e">An object that contains the event data.</param>
    protected virtual void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
    }

    /// <summary>
    /// Called when a page is no longer the active page in a frame.
    /// </summary>
    /// <param name="e">An object that contains the event data.</param>
    protected virtual void OnNavigatedFrom(NavigationEventArgs e)
    {
    }
  }
}
