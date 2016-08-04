using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggplant_Evolution
{
  /// <summary>
  /// Possible types of modifiers.
  /// </summary>
  public enum ModifierType
  {
    /// <summary>
    /// A direct "per second" value that will be
    /// added to the resource.
    /// </summary>
    Direct,

    /// <summary>
    /// A percentual value that will be added
    /// to the sum of direct modifiers.
    /// </summary>
    Percentual
  }

  public class Modifier
  {
    #region Properties

    /// <summary>
    /// A unique identifier of this specific modifier.
    /// For example a specific building always has the
    /// identifier "Building X" or so.
    /// </summary>
    public string Identifier
    {
      get { return _identifier; }
      private set { _identifier = value; }
    }
    private string _identifier;

    /// <summary>
    /// The value of this modifier.
    /// </summary>
    public double Value
    {
      get { return _value; }
      set
      {
        if (value == 0)
          throw new ArgumentException("Value can't be 0");
        _value = value;
      }
    }
    private double _value;

    /// <summary>
    /// The type of this modifier.
    /// </summary>
    public ModifierType Type
    {
      get { return _type; }
      private set { _type = value; }
    }
    private ModifierType _type;

    #endregion Properties

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="identifier">Source identifier.</param>
    /// <param name="value">Value.</param>
    /// <param name="type">Modifier type.</param>
    public Modifier(string identifier, double value, ModifierType type)
    {
      Identifier = identifier;
      Value = value;
      Type = type;
    }

    #endregion Construction
  }
}