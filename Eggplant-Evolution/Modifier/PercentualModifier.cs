using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggplant_Evolution.Modifier
{
  /// <summary>
  /// Modifier that takes the sum of all <see cref="DirectModifier"/>s
  /// of the target resource and adds a procentual value to it.
  /// </summary>
  class PercentualModifier : ModifierBase
  {
    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value">Value of this modifier.</param>
    public PercentualModifier(double value)
    {
      Value = value;
    }

    #endregion Construction
  }
}