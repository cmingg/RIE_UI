namespace RIE_UI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SI = new System.Windows.Forms.RadioButton();
            this.SiO2 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Si3N4 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(73, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "박막 종류";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(73, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "목표 두께 :";
            // 
            // SI
            // 
            this.SI.AutoSize = true;
            this.SI.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SI.Location = new System.Drawing.Point(113, 147);
            this.SI.Name = "SI";
            this.SI.Size = new System.Drawing.Size(48, 29);
            this.SI.TabIndex = 2;
            this.SI.TabStop = true;
            this.SI.Text = "SI";
            this.SI.UseVisualStyleBackColor = true;
            // 
            // SiO2
            // 
            this.SiO2.AutoSize = true;
            this.SiO2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SiO2.Location = new System.Drawing.Point(242, 147);
            this.SiO2.Name = "SiO2";
            this.SiO2.Size = new System.Drawing.Size(73, 29);
            this.SiO2.TabIndex = 3;
            this.SiO2.TabStop = true;
            this.SiO2.Text = "SiO2";
            this.SiO2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(285, 265);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 27);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(576, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 47);
            this.button1.TabIndex = 5;
            this.button1.Text = "실행";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Si3N4
            // 
            this.Si3N4.AutoSize = true;
            this.Si3N4.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Si3N4.Location = new System.Drawing.Point(392, 147);
            this.Si3N4.Name = "Si3N4";
            this.Si3N4.Size = new System.Drawing.Size(83, 29);
            this.Si3N4.TabIndex = 6;
            this.Si3N4.TabStop = true;
            this.Si3N4.Text = "Si3N4";
            this.Si3N4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Si3N4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SiO2);
            this.Controls.Add(this.SI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "실행";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        public RadioButton SI;
        public RadioButton SiO2;
        public RadioButton Si3N4;
        public TextBox textBox1;
    }
}