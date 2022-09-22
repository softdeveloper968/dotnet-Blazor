using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.Models
{
  public enum StatusValues
    {
        //For Sending Offer

        Accepted=1,

        Pending=2,

        Decline=3,

        Applied=4,

        //For Posting jobs

        Created=5,

        InProgress=6,

        Completed=7,

        Suspended=8,

        Cancelled=9

    }
}
