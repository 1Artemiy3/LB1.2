using System;
using System.IO;

namespace LB1._2
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                double[] xValues = ReadXValuesFromFile("LAB2.TXT");
                WriteResultsToFile(xValues, "LAB2.RES");
                Console.WriteLine("Розрахунок завершено! Результати записано у файл LAB2.RES.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Файл не знайдено: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сталася помилка: {ex.Message}");
            }
        }

        static double[] ReadXValuesFromFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                var xValues = new System.Collections.Generic.List<double>();

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (double.TryParse(line, out double result))
                        {
                            xValues.Add(result);
                        }
                        else
                        {
                            throw new FormatException($"Некоректне значення: {line}");
                        }
                    }
                }

                return xValues.ToArray();
            }
        }

        static void WriteResultsToFile(double[] xValues, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("Таблиця значень:");
                writer.WriteLine("X\t\tY");

                foreach (double x in xValues)
                {
                    double y;

                    if (x >= 0)
                    {
                        y = 2 * x - 5 * Math.Pow(x, 2.0 / 3);
                    }
                    else
                    {
                        double absX = Math.Abs(x);
                        double absResult = Math.Pow(absX, 2.0 / 3);
                        y = 2 * x - 5 * (x > 0 ? absResult : -absResult);
                    }

                    writer.WriteLine($"{x,8:F2}\t{y,8:F2}");
                }

                writer.WriteLine("Таблицю сформував: Шулещенко Артем Вадимович");
            }
        }
    }
}
