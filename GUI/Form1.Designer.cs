namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabController1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.MD5_Output = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MD5_Input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RSA_TextCheck = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RSA_E = new System.Windows.Forms.TextBox();
            this.RSA_Q = new System.Windows.Forms.TextBox();
            this.RSA_P = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RSA_Output = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RSA_Input = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.AESDecryptionButton = new System.Windows.Forms.Button();
            this.AESEncryptionButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.AESOutputTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AESKeyTextBox = new System.Windows.Forms.TextBox();
            this.AESInputTextBox = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.ExtendedResult = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ExtendedBase = new System.Windows.Forms.TextBox();
            this.ExtendedNumber = new System.Windows.Forms.TextBox();
            this.tabController1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabController1
            // 
            this.tabController1.Controls.Add(this.tabPage1);
            this.tabController1.Controls.Add(this.tabPage2);
            this.tabController1.Controls.Add(this.tabPage3);
            this.tabController1.Controls.Add(this.tabPage4);
            this.tabController1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabController1.Location = new System.Drawing.Point(0, 0);
            this.tabController1.Name = "tabController1";
            this.tabController1.SelectedIndex = 0;
            this.tabController1.Size = new System.Drawing.Size(998, 521);
            this.tabController1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.MD5_Output);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(990, 495);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MD5";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(850, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Hash";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MD5_Output
            // 
            this.MD5_Output.Dock = System.Windows.Forms.DockStyle.Left;
            this.MD5_Output.Enabled = false;
            this.MD5_Output.Location = new System.Drawing.Point(3, 214);
            this.MD5_Output.Name = "MD5_Output";
            this.MD5_Output.Size = new System.Drawing.Size(841, 20);
            this.MD5_Output.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MD5_Input);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 211);
            this.panel1.TabIndex = 0;
            // 
            // MD5_Input
            // 
            this.MD5_Input.Location = new System.Drawing.Point(8, 25);
            this.MD5_Input.Multiline = true;
            this.MD5_Input.Name = "MD5_Input";
            this.MD5_Input.Size = new System.Drawing.Size(971, 183);
            this.MD5_Input.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RSA_TextCheck);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.RSA_E);
            this.tabPage2.Controls.Add(this.RSA_Q);
            this.tabPage2.Controls.Add(this.RSA_P);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.RSA_Output);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.RSA_Input);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(990, 495);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RSA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RSA_TextCheck
            // 
            this.RSA_TextCheck.AutoSize = true;
            this.RSA_TextCheck.Checked = true;
            this.RSA_TextCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RSA_TextCheck.Location = new System.Drawing.Point(932, 6);
            this.RSA_TextCheck.Name = "RSA_TextCheck";
            this.RSA_TextCheck.Size = new System.Drawing.Size(47, 17);
            this.RSA_TextCheck.TabIndex = 13;
            this.RSA_TextCheck.Text = "Text";
            this.RSA_TextCheck.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(667, 344);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 92);
            this.button3.TabIndex = 12;
            this.button3.Text = "Decrypt";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(817, 344);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 92);
            this.button2.TabIndex = 11;
            this.button2.Text = "Encrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "E:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Q:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "P:";
            // 
            // RSA_E
            // 
            this.RSA_E.Location = new System.Drawing.Point(61, 398);
            this.RSA_E.Name = "RSA_E";
            this.RSA_E.Size = new System.Drawing.Size(100, 20);
            this.RSA_E.TabIndex = 7;
            this.RSA_E.Text = "7";
            // 
            // RSA_Q
            // 
            this.RSA_Q.Location = new System.Drawing.Point(61, 372);
            this.RSA_Q.Name = "RSA_Q";
            this.RSA_Q.Size = new System.Drawing.Size(100, 20);
            this.RSA_Q.TabIndex = 6;
            this.RSA_Q.Text = "53";
            // 
            // RSA_P
            // 
            this.RSA_P.Location = new System.Drawing.Point(61, 346);
            this.RSA_P.Name = "RSA_P";
            this.RSA_P.Size = new System.Drawing.Size(100, 20);
            this.RSA_P.TabIndex = 5;
            this.RSA_P.Text = "61";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output:";
            // 
            // RSA_Output
            // 
            this.RSA_Output.Location = new System.Drawing.Point(8, 189);
            this.RSA_Output.Multiline = true;
            this.RSA_Output.Name = "RSA_Output";
            this.RSA_Output.Size = new System.Drawing.Size(974, 133);
            this.RSA_Output.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Input:";
            // 
            // RSA_Input
            // 
            this.RSA_Input.Location = new System.Drawing.Point(6, 26);
            this.RSA_Input.Multiline = true;
            this.RSA_Input.Name = "RSA_Input";
            this.RSA_Input.Size = new System.Drawing.Size(974, 133);
            this.RSA_Input.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.AESDecryptionButton);
            this.tabPage3.Controls.Add(this.AESEncryptionButton);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.AESOutputTextBox);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.AESKeyTextBox);
            this.tabPage3.Controls.Add(this.AESInputTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(990, 495);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "AES";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // AESDecryptionButton
            // 
            this.AESDecryptionButton.Location = new System.Drawing.Point(593, 377);
            this.AESDecryptionButton.Name = "AESDecryptionButton";
            this.AESDecryptionButton.Size = new System.Drawing.Size(99, 57);
            this.AESDecryptionButton.TabIndex = 7;
            this.AESDecryptionButton.Text = "Decrypt";
            this.AESDecryptionButton.UseVisualStyleBackColor = true;
            this.AESDecryptionButton.Click += new System.EventHandler(this.AESDecryptionButton_Click);
            // 
            // AESEncryptionButton
            // 
            this.AESEncryptionButton.Location = new System.Drawing.Point(413, 377);
            this.AESEncryptionButton.Name = "AESEncryptionButton";
            this.AESEncryptionButton.Size = new System.Drawing.Size(99, 57);
            this.AESEncryptionButton.TabIndex = 6;
            this.AESEncryptionButton.Text = "Encrypt";
            this.AESEncryptionButton.UseVisualStyleBackColor = true;
            this.AESEncryptionButton.Click += new System.EventHandler(this.EncryptionButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Output:";
            // 
            // AESOutputTextBox
            // 
            this.AESOutputTextBox.Location = new System.Drawing.Point(108, 289);
            this.AESOutputTextBox.Multiline = true;
            this.AESOutputTextBox.Name = "AESOutputTextBox";
            this.AESOutputTextBox.Size = new System.Drawing.Size(828, 50);
            this.AESOutputTextBox.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Key:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Input:";
            // 
            // AESKeyTextBox
            // 
            this.AESKeyTextBox.Location = new System.Drawing.Point(108, 119);
            this.AESKeyTextBox.Multiline = true;
            this.AESKeyTextBox.Name = "AESKeyTextBox";
            this.AESKeyTextBox.Size = new System.Drawing.Size(828, 50);
            this.AESKeyTextBox.TabIndex = 1;
            // 
            // AESInputTextBox
            // 
            this.AESInputTextBox.Location = new System.Drawing.Point(108, 43);
            this.AESInputTextBox.Multiline = true;
            this.AESInputTextBox.Name = "AESInputTextBox";
            this.AESInputTextBox.Size = new System.Drawing.Size(828, 50);
            this.AESInputTextBox.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.ExtendedResult);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.ExtendedBase);
            this.tabPage4.Controls.Add(this.ExtendedNumber);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(990, 495);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "ExtendedEuclidean";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(373, 368);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 57);
            this.button4.TabIndex = 6;
            this.button4.Text = "Calculate";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(273, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Result";
            // 
            // ExtendedResult
            // 
            this.ExtendedResult.Location = new System.Drawing.Point(393, 224);
            this.ExtendedResult.Name = "ExtendedResult";
            this.ExtendedResult.Size = new System.Drawing.Size(100, 20);
            this.ExtendedResult.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(127, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Number:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(459, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Base:";
            // 
            // ExtendedBase
            // 
            this.ExtendedBase.Location = new System.Drawing.Point(548, 85);
            this.ExtendedBase.Name = "ExtendedBase";
            this.ExtendedBase.Size = new System.Drawing.Size(100, 20);
            this.ExtendedBase.TabIndex = 1;
            // 
            // ExtendedNumber
            // 
            this.ExtendedNumber.Location = new System.Drawing.Point(225, 81);
            this.ExtendedNumber.Name = "ExtendedNumber";
            this.ExtendedNumber.Size = new System.Drawing.Size(100, 20);
            this.ExtendedNumber.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 521);
            this.Controls.Add(this.tabController1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabController1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabController1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox MD5_Output;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox MD5_Input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RSA_Output;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RSA_Input;
        private System.Windows.Forms.TextBox RSA_P;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RSA_E;
        private System.Windows.Forms.TextBox RSA_Q;
        private System.Windows.Forms.CheckBox RSA_TextCheck;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button AESDecryptionButton;
        private System.Windows.Forms.Button AESEncryptionButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox AESOutputTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AESKeyTextBox;
        private System.Windows.Forms.TextBox AESInputTextBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox ExtendedResult;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ExtendedBase;
        private System.Windows.Forms.TextBox ExtendedNumber;
    }
}

