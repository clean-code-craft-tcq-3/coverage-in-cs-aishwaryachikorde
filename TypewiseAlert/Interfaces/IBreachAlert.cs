﻿using static TypewiseAlert.TypewiseAlert;

namespace TypewiseAlert.Interfaces
{
  public interface IBreachAlert
  {
     bool Send(BreachType breachType);
  }
}
