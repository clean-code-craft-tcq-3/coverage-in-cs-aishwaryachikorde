using System;
using static TypewiseAlert.TypewiseAlert;
using TypewiseAlert.Interfaces;

namespace TypewiseAlert.AlertTargets
{
  public class ControllerAsTarget: IBreachAlert
  {
    public bool Send(BreachType breachType)
    {
      try
      {
        const ushort header = 0xfeed;

        Console.WriteLine("{0} : {1}\n", header, breachType);

        return true;

      }
      catch (Exception ex)
      {
        Console.WriteLine("Cannot be sent to controller: {0}", ex.Message);

        return false;
      }

    }
  }
}
