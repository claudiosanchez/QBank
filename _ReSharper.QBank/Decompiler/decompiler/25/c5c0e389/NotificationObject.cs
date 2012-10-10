// Type: Microsoft.Practices.Prism.ViewModel.NotificationObject
// Assembly: Microsoft.Practices.Prism, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Users\Claudio\SkyDrive\Source Code\QBank\packages\Prism.4.1.0.0\lib\SL4\Microsoft.Practices.Prism.dll

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Threading;

namespace Microsoft.Practices.Prism.ViewModel
{
  /// <summary>
  /// Base class for items that support property notification.
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// This class provides basic support for implementing the <see cref="T:System.ComponentModel.INotifyPropertyChanged"/> interface and for
  ///             marshalling execution to the UI thread.
  /// 
  /// </remarks>
  [DataContract]
  public abstract class NotificationObject : INotifyPropertyChanged
  {
    private PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Raised when a property on this object has a new value.
    /// 
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged
    {
      add
      {
        PropertyChangedEventHandler changedEventHandler = this.PropertyChanged;
        PropertyChangedEventHandler comparand;
        do
        {
          comparand = changedEventHandler;
          changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.PropertyChanged, comparand + value, comparand);
        }
        while (changedEventHandler != comparand);
      }
      remove
      {
        PropertyChangedEventHandler changedEventHandler = this.PropertyChanged;
        PropertyChangedEventHandler comparand;
        do
        {
          comparand = changedEventHandler;
          changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.PropertyChanged, comparand - value, comparand);
        }
        while (changedEventHandler != comparand);
      }
    }

    /// <summary>
    /// Raises this object's PropertyChanged event.
    /// 
    /// </summary>
    /// <param name="propertyName">The property that has a new value.</param>
    protected virtual void RaisePropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler changedEventHandler = this.PropertyChanged;
      if (changedEventHandler == null)
        return;
      changedEventHandler((object) this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Raises this object's PropertyChanged event for each of the properties.
    /// 
    /// </summary>
    /// <param name="propertyNames">The properties that have a new value.</param>
    protected void RaisePropertyChanged(params string[] propertyNames)
    {
      if (propertyNames == null)
        throw new ArgumentNullException("propertyNames");
      foreach (string propertyName in propertyNames)
        this.RaisePropertyChanged(propertyName);
    }

    /// <summary>
    /// Raises this object's PropertyChanged event.
    /// 
    /// </summary>
    /// <typeparam name="T">The type of the property that has a new value</typeparam><param name="propertyExpression">A Lambda expression representing the property that has a new value.</param>
    protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
    {
      this.RaisePropertyChanged(PropertySupport.ExtractPropertyName<T>(propertyExpression));
    }
  }
}
