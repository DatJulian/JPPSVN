namespace JPPSVN.forms {
	sealed partial class ProjectForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
         System.Windows.Forms.Label label1;
         System.Windows.Forms.Label label2;
         System.Windows.Forms.Label label3;
         System.Windows.Forms.Label label4;
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.openIntelliJButton = new System.Windows.Forms.Button();
         this.cleanupButton = new System.Windows.Forms.Button();
         this.openExplorerButton = new System.Windows.Forms.Button();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.projectTextBox = new System.Windows.Forms.TextBox();
         this.userTextBox = new System.Windows.Forms.TextBox();
         this.userNameTextBox = new System.Windows.Forms.TextBox();
         this.revisionTextBox = new System.Windows.Forms.TextBox();
         label1 = new System.Windows.Forms.Label();
         label2 = new System.Windows.Forms.Label();
         label3 = new System.Windows.Forms.Label();
         label4 = new System.Windows.Forms.Label();
         this.tableLayoutPanel1.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
         label1.AutoSize = true;
         label1.Location = new System.Drawing.Point(41, 58);
         label1.Name = "label1";
         label1.Size = new System.Drawing.Size(35, 13);
         label1.TabIndex = 0;
         label1.Text = "Name";
         // 
         // label2
         // 
         label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
         label2.AutoSize = true;
         label2.Location = new System.Drawing.Point(3, 32);
         label2.Name = "label2";
         label2.Size = new System.Drawing.Size(73, 13);
         label2.TabIndex = 0;
         label2.Text = "RZ-Username";
         // 
         // label3
         // 
         label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
         label3.AutoSize = true;
         label3.Location = new System.Drawing.Point(36, 6);
         label3.Name = "label3";
         label3.Size = new System.Drawing.Size(40, 13);
         label3.TabIndex = 0;
         label3.Text = "Projekt";
         // 
         // label4
         // 
         label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
         label4.AutoSize = true;
         label4.Location = new System.Drawing.Point(28, 84);
         label4.Name = "label4";
         label4.Size = new System.Drawing.Size(48, 13);
         label4.TabIndex = 0;
         label4.Text = "Revision";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.AutoSize = true;
         this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.tableLayoutPanel1.ColumnCount = 1;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 145);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel2.AutoSize = true;
         this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.tableLayoutPanel2.ColumnCount = 3;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.Controls.Add(this.openIntelliJButton, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.cleanupButton, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.openExplorerButton, 2, 0);
         this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 113);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 1;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.Size = new System.Drawing.Size(254, 29);
         this.tableLayoutPanel2.TabIndex = 1;
         // 
         // openIntelliJButton
         // 
         this.openIntelliJButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.openIntelliJButton.AutoSize = true;
         this.openIntelliJButton.Location = new System.Drawing.Point(86, 3);
         this.openIntelliJButton.Name = "openIntelliJButton";
         this.openIntelliJButton.Size = new System.Drawing.Size(75, 23);
         this.openIntelliJButton.TabIndex = 0;
         this.openIntelliJButton.Text = "Öffne IntelliJ";
         this.openIntelliJButton.UseVisualStyleBackColor = true;
         this.openIntelliJButton.Click += new System.EventHandler(this.openIntelliJButton_Click);
         // 
         // cleanupButton
         // 
         this.cleanupButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.cleanupButton.Location = new System.Drawing.Point(5, 3);
         this.cleanupButton.Name = "cleanupButton";
         this.cleanupButton.Size = new System.Drawing.Size(75, 23);
         this.cleanupButton.TabIndex = 1;
         this.cleanupButton.Text = "Aufräumen";
         this.cleanupButton.UseVisualStyleBackColor = true;
         this.cleanupButton.Click += new System.EventHandler(this.cleanupButton_Click);
         // 
         // openExplorerButton
         // 
         this.openExplorerButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.openExplorerButton.AutoSize = true;
         this.openExplorerButton.Location = new System.Drawing.Point(167, 3);
         this.openExplorerButton.Name = "openExplorerButton";
         this.openExplorerButton.Size = new System.Drawing.Size(84, 23);
         this.openExplorerButton.TabIndex = 0;
         this.openExplorerButton.Text = "Öffne Explorer";
         this.openExplorerButton.UseVisualStyleBackColor = true;
         this.openExplorerButton.Click += new System.EventHandler(this.openExplorerButton_Click);
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel3.AutoSize = true;
         this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.tableLayoutPanel3.ColumnCount = 2;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel3.Controls.Add(this.projectTextBox, 1, 0);
         this.tableLayoutPanel3.Controls.Add(label1, 0, 2);
         this.tableLayoutPanel3.Controls.Add(label2, 0, 1);
         this.tableLayoutPanel3.Controls.Add(label4, 0, 3);
         this.tableLayoutPanel3.Controls.Add(this.revisionTextBox, 1, 3);
         this.tableLayoutPanel3.Controls.Add(this.userTextBox, 1, 1);
         this.tableLayoutPanel3.Controls.Add(this.userNameTextBox, 1, 2);
         this.tableLayoutPanel3.Controls.Add(label3, 0, 0);
         this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 4;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.Size = new System.Drawing.Size(254, 104);
         this.tableLayoutPanel3.TabIndex = 2;
         // 
         // projectTextBox
         // 
         this.projectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.projectTextBox.Location = new System.Drawing.Point(82, 3);
         this.projectTextBox.Name = "projectTextBox";
         this.projectTextBox.ReadOnly = true;
         this.projectTextBox.Size = new System.Drawing.Size(169, 20);
         this.projectTextBox.TabIndex = 1;
         // 
         // userTextBox
         // 
         this.userTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.userTextBox.Location = new System.Drawing.Point(82, 29);
         this.userTextBox.Name = "userTextBox";
         this.userTextBox.ReadOnly = true;
         this.userTextBox.Size = new System.Drawing.Size(169, 20);
         this.userTextBox.TabIndex = 1;
         // 
         // userNameTextBox
         // 
         this.userNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.userNameTextBox.Location = new System.Drawing.Point(82, 55);
         this.userNameTextBox.Name = "userNameTextBox";
         this.userNameTextBox.ReadOnly = true;
         this.userNameTextBox.Size = new System.Drawing.Size(169, 20);
         this.userNameTextBox.TabIndex = 1;
         // 
         // revisionTextBox
         // 
         this.revisionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.revisionTextBox.Location = new System.Drawing.Point(82, 81);
         this.revisionTextBox.Name = "revisionTextBox";
         this.revisionTextBox.ReadOnly = true;
         this.revisionTextBox.Size = new System.Drawing.Size(169, 20);
         this.revisionTextBox.TabIndex = 1;
         // 
         // ProjectForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 166);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Icon = global::JPPSVN.Properties.Resources.Icon32;
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(3000, 205);
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(300, 205);
         this.Name = "ProjectForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "ProjectForm";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectForm_FormClosing);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Button openIntelliJButton;
      private System.Windows.Forms.Button cleanupButton;
      private System.Windows.Forms.Button openExplorerButton;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private System.Windows.Forms.TextBox userNameTextBox;
      private System.Windows.Forms.TextBox userTextBox;
      private System.Windows.Forms.TextBox projectTextBox;
      private System.Windows.Forms.TextBox revisionTextBox;
   }
}