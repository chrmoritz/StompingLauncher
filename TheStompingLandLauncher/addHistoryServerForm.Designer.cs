namespace TheStompingLandLauncher
{
    partial class addHistoryServerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TBaddServerIP = new System.Windows.Forms.TextBox();
            this.BaddServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "server address:";
            // 
            // TBaddServerIP
            // 
            this.TBaddServerIP.Location = new System.Drawing.Point(97, 12);
            this.TBaddServerIP.Name = "TBaddServerIP";
            this.TBaddServerIP.Size = new System.Drawing.Size(133, 20);
            this.TBaddServerIP.TabIndex = 1;
            this.TBaddServerIP.Text = "127.0.0.1:7777";
            this.TBaddServerIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBaddServerIP_KeyPress);
            // 
            // BaddServer
            // 
            this.BaddServer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BaddServer.Location = new System.Drawing.Point(15, 38);
            this.BaddServer.Name = "BaddServer";
            this.BaddServer.Size = new System.Drawing.Size(212, 23);
            this.BaddServer.TabIndex = 2;
            this.BaddServer.Text = "add server to server list ...";
            this.BaddServer.UseVisualStyleBackColor = true;
            // 
            // addHistoryServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 68);
            this.Controls.Add(this.BaddServer);
            this.Controls.Add(this.TBaddServerIP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(255, 106);
            this.MinimumSize = new System.Drawing.Size(255, 106);
            this.Name = "addHistoryServerForm";
            this.Text = "add server to history";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TBaddServerIP;
        private System.Windows.Forms.Button BaddServer;
    }
}