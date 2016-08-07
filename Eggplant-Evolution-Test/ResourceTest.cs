using Eggplant_Evolution;
using NUnit.Framework;
using System;

namespace Eggplant_Evolution_Test
{
  /// <summary>
  /// Tests of the <see cref="Resource"/>.
  /// </summary>
  [TestFixture]
  class ResourceTest
  {
    /// <summary>
    /// Tests if the constructor initializes all values correctly.
    /// </summary>
    [Test]
    public void TestConstructor()
    {
      Resource rsc = new Resource(Program.UniqueResourceID++, "Eggplant");
      Assert.That(rsc.Name, Is.EqualTo("Eggplant"));
      Assert.That(rsc.Value, Is.EqualTo(0));
      Assert.That(rsc.PerSecond, Is.EqualTo(0));
      Assert.That(rsc.Modifiers.Count, Is.EqualTo(0));
    }

    /// <summary>
    /// Tests if using the same unique id two times throws
    /// an exception.
    /// </summary>
    [Test]
    public void TestUniqueID()
    {
      int id = Program.UniqueResourceID++;
      Assert.DoesNotThrow(() => new Resource(id, "Rsc"));
      Assert.Throws<ArgumentException>(() => new Resource(id, "Rsc"));
    }
  }
}