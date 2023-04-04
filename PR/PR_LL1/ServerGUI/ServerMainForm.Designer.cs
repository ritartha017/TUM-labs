namespace ServerGUI;

using System;

partial class ServerMainForm
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
            this.listeningTextBox = new System.Windows.Forms.ListBox();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listenBtn
            // 
            this.listenBtn.Location = new System.Drawing.Point(26, 67);
            this.listenBtn.Name = "listenBtn";
            this.listenBtn.Size = new System.Drawing.Size(81, 31);
            this.listenBtn.TabIndex = 0;
            this.listenBtn.Text = "Listen";
            this.listenBtn.UseVisualStyleBackColor = true;
            this.listenBtn.Click += new System.EventHandler(this.ListenBtn_Click);
            // 
            // listeningTextBox
            // 
            this.listeningTextBox.FormattingEnabled = true;
            this.listeningTextBox.ItemHeight = 20;
            this.listeningTextBox.Location = new System.Drawing.Point(123, 67);
            this.listeningTextBox.Name = "listeningTextBox";
            this.listeningTextBox.Size = new System.Drawing.Size(380, 124);
            this.listeningTextBox.TabIndex = 1;
            this.listeningTextBox.SelectedIndexChanged += new System.EventHandler(this.ListeningTextBox_SelectedIndexChanged);
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(26, 211);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(340, 27);
            this.sendTextBox.TabIndex = 2;
            this.sendTextBox.TextChanged += new System.EventHandler(this.SendTextBox_TextChanged);
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(398, 211);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(105, 27);
            this.sendBtn.TabIndex = 3;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.SendBtn_Click);
        // 
        // ServerMainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 285);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.listeningTextBox);
            this.Controls.Add(this.listenBtn);
            this.Name = "ServerMainForm";
            this.Text = "ServerMainForm";
            this.Load += new System.EventHandler(this.ServerMainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Button listenBtn;
    private ListBox listeningTextBox;
    private TextBox sendTextBox;
    private Button sendBtn;
}