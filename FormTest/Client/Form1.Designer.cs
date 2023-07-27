namespace Client
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
            listView1 = new ListView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(355, 155);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 24);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 1;
            label1.Text = "접속할 서버 주소:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 69);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 2;
            label2.Text = "int형 데이터:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 104);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 3;
            label3.Text = "float형 데이터:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 135);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 4;
            label4.Text = "문자열 데이터:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(134, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(145, 23);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(117, 66);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(145, 23);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(117, 101);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(145, 23);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(117, 130);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(145, 23);
            textBox4.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(295, 26);
            button1.Name = "button1";
            button1.Size = new Size(56, 21);
            button1.TabIndex = 9;
            button1.Text = "접속";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(268, 132);
            button2.Name = "button2";
            button2.Size = new Size(83, 21);
            button2.TabIndex = 10;
            button2.Text = "전송 및 수신";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
    }
}