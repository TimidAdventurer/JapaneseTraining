namespace JapaneseTraining
{
    public class CSVManager
    {
        public CSVManager()
        {
            string filePath = @"C:\path\to\your\file.csv"; // 替换为你的CSV文件路径
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(','); // 假设CSV文件使用逗号作为分隔符
                                                         // 处理数据，例如打印到控制台
                        Console.WriteLine(string.Join(" | ", data));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

    }
}
