using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GaHealthcareNurses.Client.Helper
{
    public static  class GetFrequencyValue
    {
        public static List<Frequency> GetFrequency(Object instance)
        {          
            List<Frequency> frequencyValue = new List<Frequency>();

            var properties = instance.GetType().GetProperties(
              BindingFlags.Instance |
              BindingFlags.Static |
              BindingFlags.Public |
              BindingFlags.NonPublic);

            foreach (var prop in properties)
            {
                Frequency frequency = new Frequency();
                frequency.Day = prop.Name;
                frequency.Value = (bool)prop.GetValue(instance);
                frequencyValue.Add(frequency);
            }
            return frequencyValue;
        }
    }
}
