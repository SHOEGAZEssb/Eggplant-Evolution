using Eggplant_Evolution;
using NUnit.Framework;

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
      Resource rsc = new Resource("Eggplant");
      Assert.That(rsc.Name, Is.EqualTo("Eggplant"));
      Assert.That(rsc.Value, Is.EqualTo(0));
      Assert.That(rsc.PerSecond, Is.EqualTo(0));
      Assert.That(rsc.Modifiers.Count, Is.EqualTo(0));
    }
  }
}