using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggplant_Evolution.Modifier
{
  class DirectModifier : ModifierBase
  {
    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value">Value of this modifier.</param>
    public DirectModifier(double value)
    {
      Value = value;
    }

    #endregion Construction
  }
}