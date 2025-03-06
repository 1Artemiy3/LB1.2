namespace LB1._2
{
    internal class Program
    {
        static void Main()
        {
            // Перевірка файлу
            if (!File.Exists("LAB2.TXT"))
            {
                Console.WriteLine("Файл LAB2.TXT не знайдено.");
                return;
            }

            // Зчитування даних з файлу 
            double[] xValues = File.ReadAllLines("LAB2.TXT")
                                   .Select(line => line.Trim())
                                   .Where(line => !string.IsNullOrEmpty(line))
                                   .Select(line =>
                                   {
                                       if (double.TryParse(line, out double result))
                                           return result;
                                       else
                                           throw new FormatException($"Некоректне значення: {line}");
                                   })
                                   .ToArray();

            // Підготовка файлу для запису
            using (StreamWriter writer = new StreamWriter("LAB2.RES"))
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

            Console.WriteLine("Розрахунок завершено! Результати записано у файл LAB2.RES.");
        }
    }
}
