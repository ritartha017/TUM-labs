namespace Client_GUI
{
    partial class ClientForm
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
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.sendTextBtn = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(10, 9);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(318, 178);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(335, 9);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(82, 177);
            this.connectBtn.TabIndex = 1;
            this.connectBtn.Text = "Connect to server";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // sendTextBtn
            // 
            this.sendTextBtn.Location = new System.Drawing.Point(335, 202);
            this.sendTextBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sendTextBtn.Name = "sendTextBtn";
            this.sendTextBtn.Size = new System.Drawing.Size(82, 20);
            this.sendTextBtn.TabIndex = 2;
            this.sendTextBtn.Text = "Send Text";
            this.sendTextBtn.UseVisualStyleBackColor = true;
            this.sendTextBtn.Click += new System.EventHandler(this.SendTextBtn_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 202);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(318, 23);
            this.inputTextBox.TabIndex = 3;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 244);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.sendTextBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.richTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox richTextBox;
        private Button connectBtn;
        private Button sendTextBtn;
        private TextBox inputTextBox;
    }
}