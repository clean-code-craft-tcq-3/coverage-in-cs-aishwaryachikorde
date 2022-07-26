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
      Assert.True(TypewiseAlert.InferBreach(30, 30, 50) == TypewiseAlert.BreachType.NORMAL);
      Assert.True(TypewiseAlert.InferBreach(50, 30, 50) == TypewiseAlert.BreachType.TOO_HIGH);
      Assert.True(TypewiseAlert.InferBreach(30, 30, 30) == TypewiseAlert.BreachType.NORMAL);
     }

    [Fact]
    public void InfersBreachAsCoolingType()
    {
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, -1) == TypewiseAlert.BreachType.TOO_LOW);
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 33) == TypewiseAlert.BreachType.NORMAL);
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 56) == TypewiseAlert.BreachType.TOO_HIGH);
      
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, -3) == TypewiseAlert.BreachType.TOO_LOW);
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 25) == TypewiseAlert.BreachType.NORMAL);
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 62) == TypewiseAlert.BreachType.TOO_HIGH);
     
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, -2) == TypewiseAlert.BreachType.TOO_LOW);
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 24) == TypewiseAlert.BreachType.NORMAL);
      Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 46) == TypewiseAlert.BreachType.TOO_HIGH);
     }

   [Fact]
    public void SendAlertsToEmailTests()
    {
      AlertContext alertContextToEmail = new AlertContext();
      alertContextToEmail.SetTarget(new EmailAsTarget());

      
      // Breach type with value TOO_LOW
      alertContextToEmail.SetBreachType(BreachType.TOO_LOW);
      alertContextToEmail.Send();
      Assert.True(alertContextToEmail.sent == true);

      // Breach type with value NORMAL
      alertContextToEmail.SetBreachType(BreachType.NORMAL);
      alertContextToEmail.Send();
      Assert.True(alertContextToEmail.sent == true);

      // Breach type with value TOO_HIGH
      alertContextToEmail.SetBreachType(BreachType.TOO_HIGH);
      alertContextToEmail.Send();
      Assert.True(alertContextToEmail.sent == true);
    }

    [Fact]
    public void SendAlertsToControllerTests()
    {
      AlertContext alertContextToController = new AlertContext();
      alertContextToController.SetTarget(new ControllerAsTarget());

      // Breach type with TOO_LOW
      alertContextToController.SetBreachType(BreachType.TOO_LOW);
      alertContextToController.Send();
      Assert.True(alertContextToController.sent == true);

      // Breach type with NORMAL
      alertContextToController.SetBreachType(BreachType.NORMAL);
      alertContextToController.Send();
      Assert.True(alertContextToController.sent == true);

      // Breach type with TOO_HIGH
      alertContextToController.SetBreachType(BreachType.TOO_HIGH);
      alertContextToController.Send();
      Assert.True(alertContextToController.sent == true);
    }
  }
}
