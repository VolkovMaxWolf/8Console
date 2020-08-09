using System;
using System.Text.RegularExpressions;

namespace _8console
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите дату (например 01.01.2001)");
                String currentDate = Console.ReadLine();
                Console.WriteLine(GetNextDay(currentDate));

            }   
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода данных");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }
        public static String GetNextDay(String date)
        {
            
            String pattern = "[0-3][0-9].[0-1][0-9].[1,2][9,0][0-9][0-9]";

            MatchCollection matches;
            
            Regex reg = new Regex(pattern);
            matches = reg.Matches(date);
            for (int i = 0; i < matches.Count; i++)
            {
                

                String prevDay = DateTime.Parse(matches[i].Value).AddDays(-1).ToShortDateString();
                date = date.Replace(matches[i].Value, prevDay);
            }
            return date;
            
        }

    }
}
