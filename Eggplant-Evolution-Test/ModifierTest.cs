using Eggplant_Evolution;
using NUnit.Framework;

namespace Eggplant_Evolution_Test
{
  /// <summary>
  /// Tests of the <see cref="Modifier"/>.
  /// </summary>
  [TestFixture]
  class ModifierTest
  {
    /// <summary>
    /// Tests if the constructor initializes all values correctly.
    /// </summary>
    [Test]
    public void TestConstructor()
    {
      Modifier mod = new Modifier("Ident", 0.63, ModifierType.Direct);
      Assert.That(mod.Identifier, Is.EqualTo("Ident"));
      Assert.That(mod.Value, Is.EqualTo(0.63));
      Assert.That(mod.Type, Is.EqualTo(ModifierType.Direct));
    }

    /// <summary>
    /// Tests the use of a single direct modifier.
    /// </summary>
    [Test]
    public void TestDirectValue()
    {
      Modifier mod = new Modifier("Ident", 0.63, ModifierType.Direct);
      Resource rsc = new Resource("Res");
      rsc.Modifiers.Add(mod);
      rsc.Tick(100);
      Assert.That(rsc.Value, Is.EqualTo(0.63));
      rsc.Tick(100);
      Assert.That(rsc.Value, Is.EqualTo(1.26));
    }

    /// <summary>
    /// Tests the use of a percentual modifier.
    /// </summary>
    [Test]
    public void TestPercentualValue()
    {
      Modifier directMod = new Modifier("Ident", 10, ModifierType.Direct);
      Modifier percentualMod = new Modifier("Ident", 50, ModifierType.Percentual);
      Resource rsc = new Resource("Res");
      rsc.Modifiers.Add(directMod);
      rsc.Modifiers.Add(percentualMod);
      rsc.Tick(100);
      Assert.That(rsc.Value, Is.EqualTo(15.0));
      rsc.Tick(100);
      Assert.That(rsc.Value, Is.EqualTo(30.0));
    }

    /// <summary>
    /// Tests the use of a single percentual modifier.
    /// </summary>
    [Test]
    public void TestSinglePercentualValue()
    {
      Modifier percentualMod = new Modifier("Ident", 50, ModifierType.Percentual);
      Resource rsc = new Resource("Res");
      rsc.Modifiers.Add(percentualMod);
      rsc.Tick(100);
      Assert.That(rsc.Value, Is.EqualTo(0));
      rsc.Tick(100);
      Assert.That(rsc.Value, Is.EqualTo(0));
    }
  }
}