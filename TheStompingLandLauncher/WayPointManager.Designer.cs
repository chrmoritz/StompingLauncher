namespace TheStompingLandLauncher
{
    partial class WayPointManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WayPointManager));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BWayPointAdd = new System.Windows.Forms.Button();
            this.TBwayPointYaw = new System.Windows.Forms.TextBox();
            this.TBwayPointZ = new System.Windows.Forms.TextBox();
            this.TBwayPointY = new System.Windows.Forms.TextBox();
            this.TBwayPointX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBwayPointName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGVwayPoints = new System.Windows.Forms.DataGridView();
            this.BwayPointRemove = new System.Windows.Forms.Button();
            this.BwayPointsRestore = new System.Windows.Forms.Button();
            this.BwayPointClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVwayPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.BWayPointAdd);
            this.groupBox1.Controls.Add(this.TBwayPointYaw);
            this.groupBox1.Controls.Add(this.TBwayPointZ);
            this.groupBox1.Controls.Add(this.TBwayPointY);
            this.groupBox1.Controls.Add(this.TBwayPointX);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TBwayPointName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // BWayPointAdd
            // 
            resources.ApplyResources(this.BWayPointAdd, "BWayPointAdd");
            this.BWayPointAdd.Name = "BWayPointAdd";
            this.BWayPointAdd.UseVisualStyleBackColor = true;
            this.BWayPointAdd.Click += new System.EventHandler(this.BWayPointAdd_Click);
            // 
            // TBwayPointYaw
            // 
            resources.ApplyResources(this.TBwayPointYaw, "TBwayPointYaw");
            this.TBwayPointYaw.Name = "TBwayPointYaw";
            this.TBwayPointYaw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateNegNumberInput);
            // 
            // TBwayPointZ
            // 
            resources.ApplyResources(this.TBwayPointZ, "TBwayPointZ");
            this.TBwayPointZ.Name = "TBwayPointZ";
            this.TBwayPointZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateDouble);
            // 
            // TBwayPointY
            // 
            resources.ApplyResources(this.TBwayPointY, "TBwayPointY");
            this.TBwayPointY.Name = "TBwayPointY";
            this.TBwayPointY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateDouble);
            // 
            // TBwayPointX
            // 
            resources.ApplyResources(this.TBwayPointX, "TBwayPointX");
            this.TBwayPointX.Name = "TBwayPointX";
            this.TBwayPointX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateDouble);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TBwayPointName
            // 
            resources.ApplyResources(this.TBwayPointName, "TBwayPointName");
            this.TBwayPointName.Name = "TBwayPointName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.DGVwayPoints);
            this.groupBox2.Controls.Add(this.BwayPointRemove);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // DGVwayPoints
            // 
            resources.ApplyResources(this.DGVwayPoints, "DGVwayPoints");
            this.DGVwayPoints.AllowUserToAddRows = false;
            this.DGVwayPoints.AllowUserToDeleteRows = false;
            this.DGVwayPoints.AllowUserToResizeRows = false;
            this.DGVwayPoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVwayPoints.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVwayPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVwayPoints.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGVwayPoints.MultiSelect = false;
            this.DGVwayPoints.Name = "DGVwayPoints";
            // 
            // BwayPointRemove
            // 
            resources.ApplyResources(this.BwayPointRemove, "BwayPointRemove");
            this.BwayPointRemove.Name = "BwayPointRemove";
            this.BwayPointRemove.UseVisualStyleBackColor = true;
            this.BwayPointRemove.Click += new System.EventHandler(this.BwayPointRemove_Click);
            // 
            // BwayPointsRestore
            // 
            resources.ApplyResources(this.BwayPointsRestore, "BwayPointsRestore");
            this.BwayPointsRestore.Name = "BwayPointsRestore";
            this.BwayPointsRestore.UseVisualStyleBackColor = true;
            this.BwayPointsRestore.Click += new System.EventHandler(this.BwayPointsRestore_Click);
            // 
            // BwayPointClose
            // 
            resources.ApplyResources(this.BwayPointClose, "BwayPointClose");
            this.BwayPointClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BwayPointClose.Name = "BwayPointClose";
            this.BwayPointClose.UseVisualStyleBackColor = true;
            // 
            // WayPointManager
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BwayPointClose);
            this.Controls.Add(this.BwayPointsRestore);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WayPointManager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVwayPoints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBwayPointName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TBwayPointX;
        private System.Windows.Forms.Button BWayPointAdd;
        public System.Windows.Forms.TextBox TBwayPointYaw;
        public System.Windows.Forms.TextBox TBwayPointZ;
        public System.Windows.Forms.TextBox TBwayPointY;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BwayPointRemove;
        private System.Windows.Forms.Button BwayPointsRestore;
        private System.Windows.Forms.Button BwayPointClose;
        public System.Windows.Forms.DataGridView DGVwayPoints;
    }
}