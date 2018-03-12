namespace JPPSVN {
    partial class ProjectForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.openIntelliJButton = new System.Windows.Forms.Button();
            this.cleanupButton = new System.Windows.Forms.Button();
            this.openExplorerButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 35);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
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
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 56);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = global::JPPSVN.Properties.Resources.Icon32;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 95);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 95);
            this.Name = "ProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProjectForm";
            this.Load += new System.EventHandler(this.ProjectForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button openIntelliJButton;
        private System.Windows.Forms.Button cleanupButton;
        private System.Windows.Forms.Button openExplorerButton;
    }
}