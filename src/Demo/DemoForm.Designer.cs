namespace Demo
{
    partial class DemoForm
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
            this.btnShow = new System.Windows.Forms.Button();
            this.txtNum = new Windows.Forms.HintTextBox(this.components);
            this.txtText = new Windows.Forms.HintTextBox(this.components);
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShow.Location = new System.Drawing.Point(67, 171);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "&Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // txtNum
            // 
            this.txtNum.AcceptMathChars = true;
            this.txtNum.AcceptsReturn = true;
            this.txtNum.EnterToTab = false;
            this.txtNum.ForeColor = System.Drawing.Color.DarkKhaki;
            this.txtNum.HintColor = System.Drawing.Color.DarkKhaki;
            this.txtNum.HintValue = "Math & Numerical + - / * ( )";
            this.txtNum.IsNumerical = true;
            this.txtNum.Location = new System.Drawing.Point(18, 73);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(174, 20);
            this.txtNum.TabIndex = 1;
            this.txtNum.Text = "Math & Numerical + - / * ( )";
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNum.TextForeColor = System.Drawing.Color.Black;
            this.txtNum.Value = "";
            // 
            // txtText
            // 
            this.txtText.EnterToTab = false;
            this.txtText.ForeColor = System.Drawing.Color.Gray;
            this.txtText.HintColor = System.Drawing.Color.Gray;
            this.txtText.HintValue = "Hint Text";
            this.txtText.Location = new System.Drawing.Point(18, 24);
            this.txtText.Margin = new System.Windows.Forms.Padding(2);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(174, 20);
            this.txtText.TabIndex = 0;
            this.txtText.Text = "Hint Text";
            this.txtText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtText.TextForeColor = System.Drawing.Color.Black;
            this.txtText.Value = "";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(15, 96);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(44, 13);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "result:   ";
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 206);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.txtText);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DemoForm";
            this.Text = "Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.HintTextBox txtText;
        private Windows.Forms.HintTextBox txtNum;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblResult;
    }
}

