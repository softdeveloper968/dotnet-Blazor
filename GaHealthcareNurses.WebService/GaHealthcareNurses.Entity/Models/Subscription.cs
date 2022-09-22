using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.Models
{
  public class Subscription
    {
        public int SubscriptionId { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public double Cost { get; set; }
        public int SubscriptionLevel { get; set; }
    }
}
