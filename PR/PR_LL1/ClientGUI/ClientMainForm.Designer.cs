namespace ClientGUI;

partial class ClientMainForm
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
            this.connectBtn = new System.Windows.Forms.Button();
            this.connectTextBox = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.sendBackTextBox = new System.Windows.Forms.TextBox();
            this.sendBackBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(319, 33);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(94, 27);
            this.connectBtn.TabIndex = 0;
            this.connectBtn.Text = "Connect";
            this.connectBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // connectTextBox
            // 
            this.connectTextBox.Location = new System.Drawing.Point(12, 33);
            this.connectTextBox.Name = "connectTextBox";
            this.connectTextBox.Size = new System.Drawing.Size(292, 27);
            this.connectTextBox.TabIndex = 1;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(12, 84);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(401, 124);
            this.listBox.TabIndex = 2;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // sendBackTextBox
            // 
            this.sendBackTextBox.Location = new System.Drawing.Point(12, 231);
            this.sendBackTextBox.Name = "sendBackTextBox";
            this.sendBackTextBox.Size = new System.Drawing.Size(292, 27);
            this.sendBackTextBox.TabIndex = 4;
            // 
            // sendBackBtn
            // 
            this.sendBackBtn.Location = new System.Drawing.Point(319, 231);
            this.sendBackBtn.Name = "sendBackBtn";
            this.sendBackBtn.Size = new System.Drawing.Size(94, 27);
            this.sendBackBtn.TabIndex = 3;
            this.sendBackBtn.Text = "Send";
            this.sendBackBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.sendBackBtn.UseVisualStyleBackColor = true;
            this.sendBackBtn.Click += new System.EventHandler(this.SendBackBtn_Click);
            // 
            // ClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 285);
            this.Controls.Add(this.sendBackTextBox);
            this.Controls.Add(this.sendBackBtn);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.connectTextBox);
            this.Controls.Add(this.connectBtn);
            this.Name = "ClientMainForm";
            this.Text = "ClientMainForm";
            this.Load += new System.EventHandler(this.ClientMainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Button connectBtn;
    private TextBox connectTextBox;
    private ListBox listBox;
    private TextBox sendBackTextBox;
    private Button sendBackBtn;
}