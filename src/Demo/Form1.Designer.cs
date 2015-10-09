namespace Demo
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
            this.components = new System.ComponentModel.Container();
            this.hintTextBox1 = new Windows.Forms.HintTextBox(this.components);
            this.SuspendLayout();
            // 
            // hintTextBox1
            // 
            this.hintTextBox1.EnterToTab = false;
            this.hintTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.hintTextBox1.HintColor = System.Drawing.Color.Gray;
            this.hintTextBox1.HintValue = "Hint Text";
            this.hintTextBox1.Location = new System.Drawing.Point(24, 30);
            this.hintTextBox1.Name = "hintTextBox1";
            this.hintTextBox1.Size = new System.Drawing.Size(231, 22);
            this.hintTextBox1.TabIndex = 0;
            this.hintTextBox1.Text = "Hint Text";
            this.hintTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hintTextBox1.TextForeColor = System.Drawing.Color.Black;
            this.hintTextBox1.Value = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.hintTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.HintTextBox hintTextBox1;
    }
}

