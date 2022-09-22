using System;
using System.Collections.Generic;
using System.Reflection;
using GaHealthcareNurses.Entity.ViewModels;

namespace Services.Helper
{
    public static class StepsInformationChecker
    {
        public static bool StepsInfoCheck(Object instance)
        {
            var stepObjCheck = false;
            if (Object.ReferenceEquals(null, instance))
                return false;

            var properties = instance.GetType().GetProperties(
              BindingFlags.Instance |
              BindingFlags.Static |
              BindingFlags.Public |
              BindingFlags.NonPublic);

            foreach (var prop in properties)
            {
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    var instanceType = prop.Name;
                    switch (instanceType)
                    {
                        case "EducationDto":
                            stepObjCheck = CheckListEmpty<EducationDto>(prop, instance);
                            if (stepObjCheck == false)
                                return false;
                            break;
                        case "CertificationDto":
                            stepObjCheck = CheckListEmpty<CertificationDto>(prop, instance);
                            if (stepObjCheck == false)
                                return false;
                            break;
                        case "ReferenceDto":
                            stepObjCheck = CheckListEmpty<ReferenceDto>(prop, instance);
                            if (stepObjCheck == false)
                                return false;
                            break;
                        case "WorkExperienceDto":
                            stepObjCheck = CheckListEmpty<WorkExperienceDto>(prop, instance);
                            if (stepObjCheck == false)
                                return false;
                            break;
                        default:
                            break;
                    }
                }

                if (stepObjCheck == true)
                {
                    stepObjCheck = false;
                    continue;
                }

                var value = prop.GetValue(instance);

                if (value == null)
                  return false;
                
                if (!prop.CanRead) 
                    continue;

                if (value.GetType().IsValueType)
                    continue;

                String str = value as String;
               
                    if (str.Equals(""))
                        return false;
            }

            return true;
        }

        public static StepsInformation SetProperties(Object instance)
        {
            StepsInformation stepsInformation = new StepsInformation();
            stepsInformation.Value = StepsInfoCheck(instance);
             stepsInformation.StepName = instance.GetType().Name;
            return stepsInformation;
        }
 
        public static bool CheckListEmpty<T>(PropertyInfo prop, Object instance)
        {            
            var checkListObject = false;

            var listObj = (List<T>)prop.GetValue(instance);
            if (listObj == null)
            {
                return false;
            }
           
            if (listObj.Count == 0)
            {
                return false;
            }

            foreach (var item in listObj)
            {
                var instanceType = prop.ReflectedType.Name;
               checkListObject = StepsInfoCheck(item);
               if(!checkListObject) return false;
                continue;
            }
            return true;
        }

    }

}
