namespace WindowsFormsApp1
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
            this.RadioMnozenie = new System.Windows.Forms.RadioButton();
            this.RadioDzielenie = new System.Windows.Forms.RadioButton();
            this.RAdioPotegowanie = new System.Windows.Forms.RadioButton();
            this.RadioOdejmowanie = new System.Windows.Forms.RadioButton();
            this.OperationCount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RadioMnozenie
            // 
            this.RadioMnozenie.AutoSize = true;
            this.RadioMnozenie.Location = new System.Drawing.Point(111, 20);
            this.RadioMnozenie.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RadioMnozenie.Name = "RadioMnozenie";
            this.RadioMnozenie.Size = new System.Drawing.Size(71, 17);
            this.RadioMnozenie.TabIndex = 0;
            this.RadioMnozenie.TabStop = true;
            this.RadioMnozenie.Text = "Mnożenie";
            this.RadioMnozenie.UseVisualStyleBackColor = true;
            this.RadioMnozenie.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // RadioDzielenie
            // 
            this.RadioDzielenie.AutoSize = true;
            this.RadioDzielenie.Location = new System.Drawing.Point(111, 42);
            this.RadioDzielenie.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RadioDzielenie.Name = "RadioDzielenie";
            this.RadioDzielenie.Size = new System.Drawing.Size(68, 17);
            this.RadioDzielenie.TabIndex = 1;
            this.RadioDzielenie.TabStop = true;
            this.RadioDzielenie.Text = "Dzielenie";
            this.RadioDzielenie.UseVisualStyleBackColor = true;
            this.RadioDzielenie.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // RAdioPotegowanie
            // 
            this.RAdioPotegowanie.AutoSize = true;
            this.RAdioPotegowanie.Location = new System.Drawing.Point(111, 65);
            this.RAdioPotegowanie.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RAdioPotegowanie.Name = "RAdioPotegowanie";
            this.RAdioPotegowanie.Size = new System.Drawing.Size(87, 17);
            this.RAdioPotegowanie.TabIndex = 2;
            this.RAdioPotegowanie.TabStop = true;
            this.RAdioPotegowanie.Text = "Potęgowanie";
            this.RAdioPotegowanie.UseVisualStyleBackColor = true;
            this.RAdioPotegowanie.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // RadioOdejmowanie
            // 
            this.RadioOdejmowanie.AutoSize = true;
            this.RadioOdejmowanie.Location = new System.Drawing.Point(111, 87);
            this.RadioOdejmowanie.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RadioOdejmowanie.Name = "RadioOdejmowanie";
            this.RadioOdejmowanie.Size = new System.Drawing.Size(87, 17);
            this.RadioOdejmowanie.TabIndex = 3;
            this.RadioOdejmowanie.TabStop = true;
            this.RadioOdejmowanie.Text = "odejmowanie";
            this.RadioOdejmowanie.UseVisualStyleBackColor = true;
            this.RadioOdejmowanie.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // OperationCount
            // 
            this.OperationCount.Location = new System.Drawing.Point(22, 43);
            this.OperationCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OperationCount.Name = "OperationCount";
            this.OperationCount.Size = new System.Drawing.Size(57, 20);
            this.OperationCount.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 20);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OperationCount);
            this.Controls.Add(this.RadioOdejmowanie);
            this.Controls.Add(this.RAdioPotegowanie);
            this.Controls.Add(this.RadioDzielenie);
            this.Controls.Add(this.RadioMnozenie);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RadioMnozenie;
        private System.Windows.Forms.RadioButton RadioDzielenie;
        private System.Windows.Forms.RadioButton RAdioPotegowanie;
        private System.Windows.Forms.RadioButton RadioOdejmowanie;
        private System.Windows.Forms.TextBox OperationCount;
        private System.Windows.Forms.Button button1;
    }
}

