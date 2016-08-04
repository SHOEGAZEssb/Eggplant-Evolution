using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggplant_Evolution
{
  /// <summary>
  /// Base class for all resources.
  /// </summary>
  class Resource
  {
    #region Properties

    /// <summary>
    /// The name of this resource.
    /// </summary>
    public string Name
    {
      get { return _name; }
      private set { _name = value; }
    }
    private string _name;

    /// <summary>
    /// Current amount/value of this resource.
    /// </summary>
    public double Value
    {
      get { return _value; }
      set { _value = value; }
    }
    private double _value;

    /// <summary>
    /// The current per second value.
    /// </summary>
    public double PerSecond
    {
      get { return _perSecond; }
      private set { _perSecond = value; }
    }
    private double _perSecond;

    /// <summary>
    /// List of currently applied modifiers.
    /// </summary>
    public ObservableCollection<Modifier> Modifiers
    {
      get { return _modifiers; }
      private set
      {
        if (value == null)
          throw new ArgumentException("Modifiers can't be null");
        _modifiers = value;
      }
    }
    private ObservableCollection<Modifier> _modifiers;

    #endregion Properties

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name">Name of this resource.</param>
    public Resource(string name)
    {
      Name = name;
      Modifiers = new ObservableCollection<Modifier>();
      Modifiers.CollectionChanged += Modifiers_CollectionChanged;
    }

    /// <summary>
    /// Updates the <see cref="PerSecond"/> value when a modifier
    /// gets added or removed from <see cref="Modifiers"/>.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Modifiers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
      double basePerSecond = Modifiers.Where(i => i.Type == ModifierType.Direct).Sum(i => i.Value);
      double percentage = 100 + Modifiers.Where(i => i.Type == ModifierType.Percentual).Sum(i => i.Value);

      PerSecond = (percentage * basePerSecond) / 100;
    }

    #endregion Construction
  }
}