namespace Server_GUI;

partial class ServerForm
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
            this.listenBtn = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listenBtn
            // 
            this.listenBtn.Location = new System.Drawing.Point(412, 9);
            this.listenBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listenBtn.Name = "listenBtn";
            this.listenBtn.Size = new System.Drawing.Size(91, 177);
            this.listenBtn.TabIndex = 0;
            this.listenBtn.Text = " Listen Client";
            this.listenBtn.UseVisualStyleBackColor = true;
            this.listenBtn.Click += new System.EventHandler(this.ListenBtn_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(10, 9);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(396, 178);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(10, 199);
            this.sendTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(396, 23);
            this.sendTextBox.TabIndex = 2;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(412, 197);
            this.sendBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(91, 22);
            this.sendBtn.TabIndex = 3;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 238);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.listenBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Button listenBtn;
    private RichTextBox richTextBox;
    private TextBox sendTextBox;
    private Button sendBtn;
}