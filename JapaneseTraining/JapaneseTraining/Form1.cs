using JapaneseTraining.Model;
using System.Text;

namespace JapaneseTraining
{
    public partial class Form1 : Form
    {
        List<Word> words = new List<Word>();
        public string[] SimulatorListKeys = { "Chinese", "Japanese", "pos" };//�����csv�ļ��ı�ͷ

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
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv"; // �����ļ����͹�����ΪCSV�ļ�
                openFileDialog.Title = "Select a CSV File"; // ���öԻ������

                string filePath = string.Empty;
                if (openFileDialog.ShowDialog() == DialogResult.OK) // ����û�����ˡ��򿪡���ť
                {
                    filePath = openFileDialog.FileName; // ��ȡѡ���ļ���·��
                    label_csv_path.Text = filePath;//��ʾ·��
                }
                //��ȡCSV������
                List<Word> words = LoadWordsList(filePath);

                // �Զ������У���ѡ����ΪĬ������»��Զ����ɣ�
                dataGridView_word.AutoGenerateColumns = true;
                //��ʾ����
                dataGridView_word.DataSource = words;
                dataGridView_word.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_word.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;

                //���Ը�����Ҫ�����е����ԣ������п�����ȣ���ѡ��
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
        /// ����CSV�ļ�
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
