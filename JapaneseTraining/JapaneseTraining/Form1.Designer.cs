namespace JapaneseTraining
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_select_file = new Button();
            label_csv_path = new Label();
            dataGridView_word = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView_word).BeginInit();
            SuspendLayout();
            // 
            // button_select_file
            // 
            button_select_file.Location = new Point(12, 12);
            button_select_file.Name = "button_select_file";
            button_select_file.Size = new Size(137, 23);
            button_select_file.TabIndex = 0;
            button_select_file.Text = "选择CSV文件";
            button_select_file.UseVisualStyleBackColor = true;
            button_select_file.Click += button_select_file_Click;
            // 
            // label_csv_path
            // 
            label_csv_path.AutoSize = true;
            label_csv_path.Location = new Point(155, 15);
            label_csv_path.Name = "label_csv_path";
            label_csv_path.Size = new Size(56, 17);
            label_csv_path.TabIndex = 1;
            label_csv_path.Text = "CSVPath";
            // 
            // dataGridView_word
            // 
            dataGridView_word.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_word.Location = new Point(12, 41);
            dataGridView_word.Name = "dataGridView_word";
            dataGridView_word.Size = new Size(310, 208);
            dataGridView_word.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView_word);
            Controls.Add(label_csv_path);
            Controls.Add(button_select_file);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView_word).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_select_file;
        private Label label_csv_path;
        private DataGridView dataGridView_word;
    }
}
