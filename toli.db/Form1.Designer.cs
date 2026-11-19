namespace toli.db
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
            dataGridView1 = new DataGridView();
            colNumber = new DataGridViewTextBoxColumn();
            ColEnglish = new DataGridViewTextBoxColumn();
            ColMongolian = new DataGridViewTextBoxColumn();
            ColRussian = new DataGridViewTextBoxColumn();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            textBox5 = new TextBox();
            lblDbInfo = new Label();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colNumber, ColEnglish, ColMongolian, ColRussian });
            dataGridView1.Location = new Point(0, 63);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(637, 308);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // colNumber
            // 
            colNumber.HeaderText = "№";
            colNumber.MinimumWidth = 6;
            colNumber.Name = "colNumber";
            colNumber.Width = 125;
            // 
            // ColEnglish
            // 
            ColEnglish.HeaderText = " Англи";
            ColEnglish.MinimumWidth = 6;
            ColEnglish.Name = "ColEnglish";
            ColEnglish.Width = 125;
            // 
            // ColMongolian
            // 
            ColMongolian.HeaderText = "Монгол";
            ColMongolian.MinimumWidth = 6;
            ColMongolian.Name = "ColMongolian";
            ColMongolian.Width = 125;
            // 
            // ColRussian
            // 
            ColRussian.HeaderText = "Орос";
            ColRussian.MinimumWidth = 6;
            ColRussian.Name = "ColRussian";
            ColRussian.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 1;
            label1.Text = "Хайх:";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(98, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            textBox1.Text = "Хайх үг...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(255, 13);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 3;
            label2.Text = "Хэл:";
            label2.Click += label2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(346, 10);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 4;
            comboBox1.Text = "Бүгд";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 421);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 5;
            label3.Text = "Англи";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(228, 421);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 6;
            label4.Text = "Монгол";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(439, 421);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 7;
            label5.Text = "Орос";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(85, 418);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(297, 414);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(508, 414);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(0, 483);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 11;
            button1.Text = "+ Нэмэх";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(129, 483);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 12;
            button2.Text = "📝 Засах";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(264, 483);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 13;
            button3.Text = "🗑 Устгах";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(390, 483);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 14;
            button4.Text = "↻Цэвэрлэх";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(539, 483);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 15;
            button5.Text = "💾 Санах";
            button5.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(0, 549);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(253, 27);
            textBox5.TabIndex = 16;
            textBox5.Text = "Нийт: 10 үг • Санасан: 0";
            // 
            // lblDbInfo
            // 
            lblDbInfo.AutoSize = true;
            lblDbInfo.ForeColor = Color.Black;
            lblDbInfo.Location = new Point(725, 81);
            lblDbInfo.Name = "lblDbInfo";
            lblDbInfo.Size = new Size(163, 20);
            lblDbInfo.TabIndex = 17;
            lblDbInfo.Text = "saved.db · saved_words";
            lblDbInfo.Click += lblDbInfo_Click;
            // 
            // textBox6
            // 
            textBox6.ForeColor = Color.Green;
            textBox6.Location = new Point(725, 104);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 19;
            textBox6.Text = "Санасан үгс";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(725, 137);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(125, 27);
            textBox7.TabIndex = 20;
            textBox7.Text = "Хоосон";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 570);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(lblDbInfo);
            Controls.Add(textBox5);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "\tГурван хэлний толь бичиг";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private TextBox textBox5;
        private DataGridViewTextBoxColumn colNumber;
        private DataGridViewTextBoxColumn ColEnglish;
        private DataGridViewTextBoxColumn ColMongolian;
        private DataGridViewTextBoxColumn ColRussian;
        private Label lblDbInfo;
        private TextBox textBox6;
        private TextBox textBox7;
    }
}
