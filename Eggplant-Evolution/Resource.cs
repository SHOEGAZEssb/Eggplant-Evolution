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
  public class Resource
  {
    /// <summary>
    /// A list holding all loaded unique ids.
    /// Throws an exception if a unique id is about
    /// to get added taht is already added.
    /// </summary>
    public static List<int> ActiveUniqueIDs = new List<int>();

    #region Properties

    /// <summary>
    /// A unique id for this resource to
    /// identify what it is.
    /// </summary>
    public int UniqueID
    {
      get { return _uniqueID; }
      private set { _uniqueID = value; }
    }
    private int _uniqueID;

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
    /// <param name="uniqueID">Unique id of this resource.</param>
    /// <param name="name">Name of this resource.</param>
    public Resource(int uniqueID, string name)
    {
      if (ActiveUniqueIDs.Contains(uniqueID))
        throw new ArgumentException("Resource with id " + uniqueID + " already exists!");
      ActiveUniqueIDs.Add(uniqueID);
      UniqueID = uniqueID;

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
      double percentage = Modifiers.Where(i => i.Type == ModifierType.Percentual).Sum(i => i.Value);

      PerSecond = basePerSecond + (percentage * basePerSecond) / 100;
    }

    #endregion Construction

    /// <summary>
    /// Increases the <see cref="Value"/> by
    /// </summary>
    /// <param name="percentage">
    /// Percentage of <see cref="PerSecond"/> to add.
    /// For example, if the tick is 100 ms, we have
    /// 10%. 1 second tick is 100%
    /// </param>
    public void Tick(double percentage)
    {
      Value += (percentage * PerSecond) / 100;
    }
  }
}