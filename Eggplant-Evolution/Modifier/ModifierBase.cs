using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggplant_Evolution.Modifier
{
  abstract class ModifierBase
  {
    #region Properties

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

    #endregion Properties
  }
}