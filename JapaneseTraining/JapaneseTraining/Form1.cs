using JapaneseTraining.Model;
using System.Text;

namespace JapaneseTraining
{
    public partial class Form1 : Form
    {
        List<Word> words = new List<Word>();
        public string[] SimulatorListKeys = { "Chinese", "Japanese", "pos" };//导入的csv文件的表头

        public Form1()
        {
            InitializeComponent();
        }
        public class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public bool InStock { get; set; }
        }

        private void button_select_file_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv"; // 设置文件类型过滤器为CSV文件
                openFileDialog.Title = "Select a CSV File"; // 设置对话框标题

                string filePath = string.Empty;
                if (openFileDialog.ShowDialog() == DialogResult.OK) // 如果用户点击了“打开”按钮
                {
                    filePath = openFileDialog.FileName; // 获取选定文件的路径
                    label_csv_path.Text = filePath;//显示路径
                }
                //读取CSV中数据
                List<Word> words = LoadWordsList(filePath);

                // 自动生成列（可选，因为默认情况下会自动生成）
                dataGridView_word.AutoGenerateColumns = true;
                //显示数据
                dataGridView_word.DataSource = words;
                dataGridView_word.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_word.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;

                //可以根据需要调整列的属性，例如列宽、标题等（可选）
                dataGridView_word.Columns["Chinese"].HeaderText = "Chinese";
                dataGridView_word.Columns["Japanese"].HeaderText = "Japanese";
                dataGridView_word.Columns["pos"].HeaderText = "pos";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public List<Word> LoadWordsList(string filePath)
        {
            List<Word> result = new List<Word>();
            FileStream fs;
            StreamReader sr;
            try
            {
                if (!File.Exists(filePath))
                {
                    CreateCSVFile(filePath, SimulatorListKeys);
                    return result;
                }
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                sr = new StreamReader(fs, Encoding.UTF8);
                string strLine = "";
                bool start = true;
                string[] aryLine;
                while ((strLine = sr.ReadLine()) != null)
                {
                    if (start)
                    {
                        start = false;
                        continue;
                    }
                    aryLine = strLine.Split(',');
                    Pos temp = WordManager.ConvertStringToPos(aryLine[2]);
                    Word info = new Word
                    {
                        Chinese = aryLine[0],
                        Japanese = aryLine[1],
                        pos = temp,
                    };
                    result.Add(info);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return result;
        }

        /// <summary>
        /// 创建CSV文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="keys"></param>
        public void CreateCSVFile(string filePath, string[] keys)
        {
            if (string.IsNullOrEmpty(filePath) || File.Exists(filePath) || keys == null)
                return;

            try
            {
                File.Create(filePath).Close();
                var str = string.Join(",", keys);
                File.WriteAllLines(filePath, new string[] { str });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
