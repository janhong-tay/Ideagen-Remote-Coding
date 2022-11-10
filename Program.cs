using System;


public class Program
{
    public static void Main()
    {
         Console.WriteLine(Calculate("10 - ( 2 + 3 * ( 7 - 5 ) )"));
         Console.WriteLine(Calculate("( 1 / 2 ) - 1 + 1"));
         Console.WriteLine(Calculate("23 - ( 29.3 - 12.5 )")); 
         Console.WriteLine(Calculate("( 11.5 + 15.4 ) + 10.1"));
         Console.WriteLine(Calculate("1 + 1"));
         Console.WriteLine(Calculate("2 * 2"));
         Console.WriteLine(Calculate("1 + 2 + 3"));
         Console.WriteLine(Calculate("6 / 2"));
         Console.WriteLine(Calculate("11 + 23"));
         Console.WriteLine(Calculate("11.1 + 23"));
         Console.WriteLine(Calculate("1 + 1 * 3"));

    }

    public static double Calculate(string sum)
    {
        try
        {  
            while (sum.Contains("("))
            {
                string insideBracket = sum.Substring(sum.LastIndexOf("(") + 1, sum.IndexOf(")") - sum.LastIndexOf("(") - 1);
                List<string> calculation = insideBracket.Split(" ").ToList();

                while (calculation.Count > 1){
                    List<string> result =   Calculate(calculation);
                    sum = sum.Replace("(" + insideBracket + ")", result[0].ToString());
                }
            }

            List<string> OutterCalculation = sum.Split(" ").ToList();
            while (OutterCalculation.Count > 1)
            {
                    List<string> result =   Calculate(OutterCalculation);
            }

            return Math.Round(Convert.ToDouble(OutterCalculation[0]),2);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return 0;
        }
    }

    public static List<string> Calculate(List<string> calculation)
    {
        double value;
        while (calculation.Contains("*"))
        {
            for (int i = 0; i < calculation.Count; i++)
            {
                if (calculation[i] == "*")
                {
                    value = Convert.ToDouble(calculation[i - 1]) * Convert.ToDouble(calculation[i + 1]);
                    calculation.RemoveRange(i - 1, 3);
                    calculation.Insert(i - 1, value.ToString());

                }
            }
        }
        while (calculation.Contains("*") || calculation.Contains("/"))
        {
            for (int i = 0; i < calculation.Count; i++)
            {
                if (calculation[i] == "*")
                {
                    value = Convert.ToDouble(calculation[i - 1]) * Convert.ToDouble(calculation[i + 1]);
                    calculation.RemoveRange(i - 1, 3);
                    calculation.Insert(i - 1, value.ToString());
                    i = 0;
                }
                if (calculation[i] == "/")
                {
                    value = Convert.ToDouble(calculation[i - 1])/ Convert.ToDouble(calculation[i + 1]);
                    calculation.RemoveRange(i - 1, 3);
                    calculation.Insert(i - 1, value.ToString());
                    i = 0;

                }

            }
        }

        while (calculation.Contains("+") || calculation.Contains("-"))
        {
            for (int i = 0; i < calculation.Count; i++)
            {
                if (calculation[i] == "+")
                {
                    value = Convert.ToDouble(calculation[i - 1]) + Convert.ToDouble(calculation[i + 1]);
                    calculation.RemoveRange(i - 1, 3);
                    calculation.Insert(i - 1, value.ToString());
                    i = 0;
                }
                if (calculation[i] == "-")
                {
                    value = Convert.ToDouble(calculation[i - 1]) - Convert.ToDouble(calculation[i + 1]);
                    calculation.RemoveRange(i - 1, 3);
                    calculation.Insert(i - 1, value.ToString());
                    i = 0;

                }

            }
        }
        while (calculation[0] == "")
        {
            for (int i = 0; i < calculation.Count; i++)
            {
                if (calculation[i] == "")
                {
                    calculation.RemoveRange(i, 1);
                }
            }
        }
        return calculation;
    }
}
