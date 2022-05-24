using TypewiseAlert.AlertTargets;
using Xunit;
using static TypewiseAlert.TypewiseAlert;

namespace TypewiseAlert.Test
{
  public class TypewiseAlertTest
  {
    [Fact]
    public void InfersBreachAsPerLimits()
    {
      Assert.True(TypewiseAlert.InferBreach(15, 30, 50) == TypewiseAlert.BreachType.TOO_LOW);
      Assert.True(TypewiseAlert.InferBreach(36, 30, 50) == TypewiseAlert.BreachType.NORMAL);
      Assert.True(TypewiseAlert.InferBreach(53, 30, 50) == TypewiseAlert.BreachType.TOO_HIGH);
     }

    [Fact]
    public void InfersBreachAsCoolingType()
    {
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, -1) == TypewiseAlert.BreachType.TOO_LOW);
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 33) == TypewiseAlert.BreachType.NORMAL);
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 56) == TypewiseAlert.BreachType.TOO_HIGH);
      
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, -3) == TypewiseAlert.BreachType.TOO_LOW);
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 25) == TypewiseAlert.BreachType.NORMAL);
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 40) == TypewiseAlert.BreachType.TOO_HIGH);
     
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, -2) == TypewiseAlert.BreachType.TOO_LOW);
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 24) == TypewiseAlert.BreachType.NORMAL);
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 46) == TypewiseAlert.BreachType.TOO_HIGH);
     }

    [Fact]
    public void SendAlertsToEmailTests()
    {
      AlertContext alertContext = new AlertContext();
      alertContext.SetTarget(new EmailAsTarget());

      

      // Breach type with value TOO_LOW
      alertContext.SetBreachType(BreachType.TOO_LOW);
      alertContext.Send();
      Assert.True(alertContext.sent == true);

      // Breach type with value NORMAL
      alertContext.SetBreachType(BreachType.NORMAL);
      alertContext.Send();
      Assert.True(alertContext.sent == true);

      // Breach type with value TOO_HIGH
      alertContext.SetBreachType(BreachType.TOO_HIGH);
      alertContext.Send();
      Assert.True(alertContext.sent == true);
    }

    [Fact]
    public void SendAlertsToControllerTests()
    {
      AlertContext alertContext = new AlertContext();
      alertContext.SetTarget(new ControllerAsTarget());

      // Breach type with value TOO_LOW
      alertContext.SetBreachType(BreachType.TOO_LOW);
      alertContext.Send();
      Assert.True(alertContext.sent == true);

      // Breach type with value NORMAL
      alertContext.SetBreachType(BreachType.NORMAL);
      alertContext.Send();
      Assert.True(alertContext.sent == true);

      // Breach type with value TOO_HIGH
      alertContext.SetBreachType(BreachType.TOO_HIGH);
      alertContext.Send();
      Assert.True(alertContext.sent == true);

    }
  }
}
