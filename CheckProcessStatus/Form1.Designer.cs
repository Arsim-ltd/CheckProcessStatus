namespace CheckProcessStatus
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
            this.LaunchAppBTN = new System.Windows.Forms.Button();
            this.GetHandlesBTN = new System.Windows.Forms.Button();
            this.ProcessBox = new System.Windows.Forms.TextBox();
            this.PIDBox = new System.Windows.Forms.TextBox();
            this.PIDLabel = new System.Windows.Forms.Label();
            this.ProcessLabel = new System.Windows.Forms.Label();
            this.NewHandlesOnlyBox = new System.Windows.Forms.CheckBox();
            this.AutoCloseHandlesBox = new System.Windows.Forms.CheckBox();
            this.AutoCheckHandlesBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LaunchAppBTN
            // 
            this.LaunchAppBTN.Location = new System.Drawing.Point(25, 29);
            this.LaunchAppBTN.Name = "LaunchAppBTN";
            this.LaunchAppBTN.Size = new System.Drawing.Size(75, 23);
            this.LaunchAppBTN.TabIndex = 0;
            this.LaunchAppBTN.Text = "Launch";
            this.LaunchAppBTN.UseVisualStyleBackColor = true;
            this.LaunchAppBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // GetHandlesBTN
            // 
            this.GetHandlesBTN.Location = new System.Drawing.Point(25, 75);
            this.GetHandlesBTN.Name = "GetHandlesBTN";
            this.GetHandlesBTN.Size = new System.Drawing.Size(75, 23);
            this.GetHandlesBTN.TabIndex = 1;
            this.GetHandlesBTN.Text = "Get Handles";
            this.GetHandlesBTN.UseVisualStyleBackColor = true;
            this.GetHandlesBTN.Click += new System.EventHandler(this.button2_Click);
            // 
            // ProcessBox
            // 
            this.ProcessBox.Location = new System.Drawing.Point(157, 31);
            this.ProcessBox.Name = "ProcessBox";
            this.ProcessBox.Size = new System.Drawing.Size(163, 20);
            this.ProcessBox.TabIndex = 2;
            this.ProcessBox.TextChanged += new System.EventHandler(this.ProcessBox_TextChanged);
            // 
            // PIDBox
            // 
            this.PIDBox.Location = new System.Drawing.Point(157, 77);
            this.PIDBox.Name = "PIDBox";
            this.PIDBox.Size = new System.Drawing.Size(163, 20);
            this.PIDBox.TabIndex = 3;
            this.PIDBox.TextChanged += new System.EventHandler(this.PIDBox_TextChanged);
            // 
            // PIDLabel
            // 
            this.PIDLabel.AutoSize = true;
            this.PIDLabel.Location = new System.Drawing.Point(156, 61);
            this.PIDLabel.Name = "PIDLabel";
            this.PIDLabel.Size = new System.Drawing.Size(66, 13);
            this.PIDLabel.TabIndex = 4;
            this.PIDLabel.Text = "Find By PID:";
            // 
            // ProcessLabel
            // 
            this.ProcessLabel.AutoSize = true;
            this.ProcessLabel.Location = new System.Drawing.Point(156, 14);
            this.ProcessLabel.Name = "ProcessLabel";
            this.ProcessLabel.Size = new System.Drawing.Size(73, 13);
            this.ProcessLabel.TabIndex = 5;
            this.ProcessLabel.Text = "New Process:";
            // 
            // NewHandlesOnlyBox
            // 
            this.NewHandlesOnlyBox.AutoSize = true;
            this.NewHandlesOnlyBox.Checked = true;
            this.NewHandlesOnlyBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NewHandlesOnlyBox.Location = new System.Drawing.Point(25, 109);
            this.NewHandlesOnlyBox.Name = "NewHandlesOnlyBox";
            this.NewHandlesOnlyBox.Size = new System.Drawing.Size(114, 17);
            this.NewHandlesOnlyBox.TabIndex = 6;
            this.NewHandlesOnlyBox.Text = "Only New Handles";
            this.NewHandlesOnlyBox.UseVisualStyleBackColor = true;
            // 
            // AutoCloseHandlesBox
            // 
            this.AutoCloseHandlesBox.AutoSize = true;
            this.AutoCloseHandlesBox.Location = new System.Drawing.Point(25, 131);
            this.AutoCloseHandlesBox.Name = "AutoCloseHandlesBox";
            this.AutoCloseHandlesBox.Size = new System.Drawing.Size(179, 17);
            this.AutoCloseHandlesBox.TabIndex = 7;
            this.AutoCloseHandlesBox.Text = "Close new handles automatically";
            this.AutoCloseHandlesBox.UseVisualStyleBackColor = true;
            // 
            // AutoCheckHandlesBox
            // 
            this.AutoCheckHandlesBox.AutoSize = true;
            this.AutoCheckHandlesBox.Location = new System.Drawing.Point(25, 152);
            this.AutoCheckHandlesBox.Name = "AutoCheckHandlesBox";
            this.AutoCheckHandlesBox.Size = new System.Drawing.Size(159, 17);
            this.AutoCheckHandlesBox.TabIndex = 8;
            this.AutoCheckHandlesBox.Text = "Auto check for new handles";
            this.AutoCheckHandlesBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 181);
            this.Controls.Add(this.AutoCheckHandlesBox);
            this.Controls.Add(this.AutoCloseHandlesBox);
            this.Controls.Add(this.NewHandlesOnlyBox);
            this.Controls.Add(this.ProcessLabel);
            this.Controls.Add(this.PIDLabel);
            this.Controls.Add(this.PIDBox);
            this.Controls.Add(this.ProcessBox);
            this.Controls.Add(this.GetHandlesBTN);
            this.Controls.Add(this.LaunchAppBTN);
            this.Name = "Form1";
            this.Text = "FormX";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LaunchAppBTN;
        private System.Windows.Forms.Button GetHandlesBTN;
        private System.Windows.Forms.TextBox ProcessBox;
        private System.Windows.Forms.TextBox PIDBox;
        private System.Windows.Forms.Label PIDLabel;
        private System.Windows.Forms.Label ProcessLabel;
        public System.Windows.Forms.CheckBox AutoCheckHandlesBox;
        public System.Windows.Forms.CheckBox NewHandlesOnlyBox;
        public System.Windows.Forms.CheckBox AutoCloseHandlesBox;
    }
}

