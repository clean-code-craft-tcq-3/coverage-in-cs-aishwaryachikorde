using static TypewiseAlert.TypewiseAlert;
using TypewiseAlert.Interfaces;

namespace TypewiseAlert
{
  public class AlertContext
  {
    
      public IBreachAlert _alertTarget;

      public BreachType _breachType;

      public bool sent = false;

      public void SetTarget(IBreachAlert target)
      {
        _alertTarget = target;
      }

      public void SetBreachType(BreachType breachType)
      {
        _breachType = breachType;
      }

      public void Send()
      {
        sent = _alertTarget.Send(_breachType);
      }
    
  }
}
