using NavigatorDemo.Interfaces;
using System;

namespace NavigatorDemo.Repositories
{
    public static class SymbolTranslator
    {    

        public static void DoValidation(this string input)
        {
            int amount;

            if (!((input.ToUpper() == "E") ||               
             (input.ToUpper() == "N") ||                
             (input.ToUpper() == "W") ||           
             (input.ToUpper() == "S")||            
             (input == "<")||            
             (input == ">")||
             (input == "*")|| int.TryParse(input, out amount)))
            {
                var msg = string.Format("SymbolTranslator: This symbol: {0} is not valid, application can not translate it to an angle.", input);
                throw new ArgumentException(msg);  
            }
        }

        public static void DoValidation(this char input)
        {
            DoValidation(input.ToString());
        }

        public static int ToAngle(this string input)
        {
            if (input.ToUpper () == "E")
                return 0;
            if (input.ToUpper() == "N")
                return 90;
            if (input.ToUpper() == "W")
                return 180;
            if (input.ToUpper() == "S")
                return 270;
            if (input == "<")
                return 90;
            if (input == ">")
                return -90;
            if (input == "*")
                return 0;

            var msg = string.Format("SymbolTranslator: This symbol: {0} is not valid, application can not translate it to an angle.", input);
            throw new ArgumentException(msg);     
        }

        public static int ToAngle(this char input)
        {
            return ToAngle(input.ToString());
        }

        public static string ToDirection(this int input)
        {
            if (input == 0)
                return "E";
            if (input == 90)
                return "N";
            if (input == 180)
                return "W";
            if (input == 270 )
                return "S";

            var msg = string.Format("SymbolTranslator: This symbol: {0} is not valid, application can not translate it to an direction.", input);
            throw new ArgumentException(msg);        
        }
    }
}
