using System;
using TypewiseAlert.Interfaces;

namespace TypewiseAlert
{
  public class EmailHighTemperature: IEmailSent
  {
    public bool SendEmail(string recepient)
    {
      try
      {
        Console.WriteLine("To: {0}\n", recepient);
        Console.WriteLine("Hi, the temperature is too high\n");

        return true;

      }
      catch (Exception ex)
      {
        Console.WriteLine("The email cannot be sent: {0}", ex.Message);

        return false;
      }
    }
  }
}
