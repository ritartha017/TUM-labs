namespace MultipleConServUI;

partial class Server
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
            this.listClients = new System.Windows.Forms.ListView();
            this.EndPointColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.IdColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.MessageColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.TimeReceivedColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listClients
            // 
            this.listClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EndPointColumnHeader,
            this.IdColumnHeader,
            this.MessageColumnHeader,
            this.TimeReceivedColumnHeader});
            this.listClients.Location = new System.Drawing.Point(10, 9);
            this.listClients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listClients.Name = "listClients";
            this.listClients.Size = new System.Drawing.Size(769, 320);
            this.listClients.TabIndex = 0;
            this.listClients.UseCompatibleStateImageBehavior = false;
            this.listClients.View = System.Windows.Forms.View.Details;
            this.listClients.SelectedIndexChanged += new System.EventHandler(this.listClients_SelectedIndexChanged);
            // 
            // EndPointColumnHeader
            // 
            this.EndPointColumnHeader.Text = "EndPoint";
            this.EndPointColumnHeader.Width = 160;
            // 
            // IdColumnHeader
            // 
            this.IdColumnHeader.Text = "Id";
            this.IdColumnHeader.Width = 150;
            // 
            // MessageColumnHeader
            // 
            this.MessageColumnHeader.Text = "Message";
            this.MessageColumnHeader.Width = 300;
            // 
            // TimeReceivedColumnHeader
            // 
            this.TimeReceivedColumnHeader.Text = "TimeReceived";
            this.TimeReceivedColumnHeader.Width = 160;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 338);
            this.Controls.Add(this.listClients);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);

    }

    #endregion

    private ListView listClients;
    private ColumnHeader EndPointColumnHeader;
    private ColumnHeader IdColumnHeader;
    private ColumnHeader MessageColumnHeader;
    private ColumnHeader TimeReceivedColumnHeader;
}