using TypewiseAlert.Interfaces;

namespace TypewiseAlert
{
  public class EmailContext
  {
    public IEmailSent _breachAlerter;

    public string _recepient;

    public bool sent = false;

    public void SetBreachAlerter(IEmailSent breachAlerter)
    {
      _breachAlerter = breachAlerter;

    }

    public void SetRecepient(string recepient)
    {
      _recepient = recepient;
    }

    public void Send()
    {
      sent = _breachAlerter.SendEmail(_recepient);
     }
  }
}
