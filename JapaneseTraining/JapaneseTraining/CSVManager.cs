namespace JapaneseTraining
{
    public class CSVManager
    {
        /// <summary>
        /// 通过路径路径获取CSV数据
        /// </summary>
        /// <returns></returns>
        public static List<string[]> GetCSVFileContent(string csvFilePath)
        {
            try
            {
                List<string[]> datas = new List<string[]>();
                using (StreamReader sr = new StreamReader(csvFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(','); // 假设CSV文件使用逗号作为分隔符\
                        datas.Add(data);
                    }
                }
                return datas;
            }
            catch
            {
                return null;
            }
        }
    }
}
