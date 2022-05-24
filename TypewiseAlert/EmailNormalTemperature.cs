using System;
using TypewiseAlert.Interfaces;

namespace TypewiseAlert
{
  public class EmailNormalTemperature: IEmailSent
  {
    public bool SendEmail(string recepient)
    {
      Console.WriteLine("All ok :)");

      return true;
    }
  }
}
