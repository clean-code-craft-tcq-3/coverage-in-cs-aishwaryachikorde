using System.Collections.Generic;
using static TypewiseAlert.TypewiseAlert;
using TypewiseAlert.Interfaces;

namespace TypewiseAlert.AlertTargets
{
  public class EmailAsTarget: IBreachAlert
  {
    static Dictionary<BreachType, IEmailSent> breachAlerters = new Dictionary<BreachType, IEmailSent>
      {

            {BreachType.TOO_LOW, new EmailLowTemperature() },
            {BreachType.TOO_HIGH, new EmailHighTemperature() },
            {BreachType.NORMAL, new EmailLowTemperature() },

        };

    public bool Send(BreachType breachType)
    {
      string recepient = "a.b@c.com";

      EmailContext emailContext = new EmailContext();

      emailContext.SetBreachAlerter(breachAlerters[breachType]);

      emailContext.SetRecepient(recepient);

      emailContext.Send();

      return emailContext.sent;

    }
  }
}
