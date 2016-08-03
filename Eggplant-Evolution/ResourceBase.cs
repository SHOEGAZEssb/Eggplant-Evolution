using Eggplant_Evolution.Modifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggplant_Evolution
{
  /// <summary>
  /// Base class for all resources.
  /// </summary>
  abstract class ResourceBase
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

    public List<ModifierBase> Modifiers
    {
      get { return _modifiers; }
      private set
      {
        if (value == null)
          throw new ArgumentException("Modifiers can't be null");
        _modifiers = value;
      }
    }
    private List<ModifierBase> _modifiers;

    #endregion
  }
}