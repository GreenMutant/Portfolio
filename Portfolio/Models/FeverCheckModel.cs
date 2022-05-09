using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class FeverCheckModel
    {
        public static string WriteMessage()
        {
            return "Please enter the fever temperature:";
        }

        public string CheckFever(string temp)
        {
            double dtemp;
            
            if (temp == null)
                return temp;
            else

            temp = temp.Replace('.', ',');
            bool isNumber = double.TryParse(temp, out dtemp);

            if (isNumber == true)
            {

                double.TryParse(temp, out dtemp);
                dtemp.ToString(temp);

                if (dtemp >= 37.8)
                    return "Fever detected";
                else
                    return "No fever detected";
            }
            else
                return "Please insert a number";
        }
    }
}
