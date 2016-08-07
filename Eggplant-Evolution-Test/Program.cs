using NUnitLite;

namespace Eggplant_Evolution_Test
{
  class Program
  {
    /// <summary>
    /// Will be counted up for each resource created
    /// to ensure the test can use a unique id (if it wants).
    /// </summary>
    public static int UniqueResourceID = 0;

    static int Main(string[] args)
    {
      return new AutoRun().Execute(args);
    }
  }
}
