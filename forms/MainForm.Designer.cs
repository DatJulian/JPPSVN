namespace JPPSVN.forms {
    partial class MainForm {
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
         System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
         System.Windows.Forms.Label label2;
         System.Windows.Forms.Label label1;
         System.Windows.Forms.Label label5;
         System.Windows.Forms.Label label3;
         System.Windows.Forms.MenuStrip menuStrip1;
         System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
         System.Windows.Forms.ToolStripMenuItem ordnerToolStripMenuItem;
         System.Windows.Forms.ToolStripMenuItem projektToolStripMenuItem;
         System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
         System.Windows.Forms.ToolStripMenuItem codeToolStripMenuItem;
         System.Windows.Forms.ToolStripMenuItem codeTestsToolStripMenuItem;
         System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
         this.userTextBox = new System.Windows.Forms.TextBox();
         this.nameTextBox = new System.Windows.Forms.TextBox();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.projektordnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.updateProjektordnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.ordnerToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
         this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this.projectComboBox = new System.Windows.Forms.ComboBox();
         this.revisionTextBox = new JPPSVN.NumberTextBox();
         tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         label2 = new System.Windows.Forms.Label();
         label1 = new System.Windows.Forms.Label();
         label5 = new System.Windows.Forms.Label();
         label3 = new System.Windows.Forms.Label();
         menuStrip1 = new System.Windows.Forms.MenuStrip();
         studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         ordnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         projektToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         codeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         codeTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         tableLayoutPanel1.SuspendLayout();
         menuStrip1.SuspendLayout();
         this.statusStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         tableLayoutPanel1.AutoSize = true;
         tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         tableLayoutPanel1.ColumnCount = 2;
         tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         tableLayoutPanel1.Controls.Add(this.projectComboBox, 1, 0);
         tableLayoutPanel1.Controls.Add(label2, 0, 3);
         tableLayoutPanel1.Controls.Add(this.revisionTextBox, 1, 3);
         tableLayoutPanel1.Controls.Add(this.userTextBox, 1, 1);
         tableLayoutPanel1.Controls.Add(label1, 0, 1);
         tableLayoutPanel1.Controls.Add(label5, 0, 0);
         tableLayoutPanel1.Controls.Add(label3, 0, 2);
         tableLayoutPanel1.Controls.Add(this.nameTextBox, 1, 2);
         tableLayoutPanel1.Location = new System.Drawing.Point(12, 30);
         tableLayoutPanel1.Name = "tableLayoutPanel1";
         tableLayoutPanel1.RowCount = 4;
         tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         tableLayoutPanel1.Size = new System.Drawing.Size(363, 105);
         tableLayoutPanel1.TabIndex = 7;
         // 
         // label2
         // 
         label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
         label2.AutoSize = true;
         label2.Location = new System.Drawing.Point(28, 85);
         label2.Name = "label2";
         label2.Size = new System.Drawing.Size(48, 13);
         label2.TabIndex = 2;
         label2.Text = "Revision";
         // 
         // userTextBox
         // 
         this.userTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.userTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
         this.userTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
         this.userTextBox.Location = new System.Drawing.Point(82, 30);
         this.userTextBox.Name = "userTextBox";
         this.userTextBox.Size = new System.Drawing.Size(278, 20);
         this.userTextBox.TabIndex = 0;
         this.userTextBox.TextChanged += new System.EventHandler(this.userTextBox_TextChanged);
         // 
         // label1
         // 
         label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
         label1.AutoSize = true;
         label1.Location = new System.Drawing.Point(3, 33);
         label1.Name = "label1";
         label1.Size = new System.Drawing.Size(73, 13);
         label1.TabIndex = 1;
         label1.Text = "RZ-Username";
         // 
         // label5
         // 
         label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
         label5.AutoSize = true;
         label5.Location = new System.Drawing.Point(36, 7);
         label5.Name = "label5";
         label5.Size = new System.Drawing.Size(40, 13);
         label5.TabIndex = 11;
         label5.Text = "Projekt";
         // 
         // label3
         // 
         label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
         label3.AutoSize = true;
         label3.Location = new System.Drawing.Point(41, 59);
         label3.Name = "label3";
         label3.Size = new System.Drawing.Size(35, 13);
         label3.TabIndex = 1;
         label3.Text = "Name";
         // 
         // nameTextBox
         // 
         this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.nameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
         this.nameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
         this.nameTextBox.Location = new System.Drawing.Point(82, 56);
         this.nameTextBox.Name = "nameTextBox";
         this.nameTextBox.Size = new System.Drawing.Size(278, 20);
         this.nameTextBox.TabIndex = 0;
         this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
         // 
         // menuStrip1
         // 
         menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            studentToolStripMenuItem,
            projektToolStripMenuItem,
            debugToolStripMenuItem,
            einstellungenToolStripMenuItem});
         menuStrip1.Location = new System.Drawing.Point(0, 0);
         menuStrip1.Name = "menuStrip1";
         menuStrip1.Size = new System.Drawing.Size(387, 24);
         menuStrip1.TabIndex = 9;
         menuStrip1.Text = "menuStrip1";
         // 
         // studentToolStripMenuItem
         // 
         studentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ordnerToolStripMenuItem,
            this.toolStripSeparator1,
            this.projektordnerToolStripMenuItem,
            this.updateProjektordnerToolStripMenuItem});
         studentToolStripMenuItem.Name = "studentToolStripMenuItem";
         studentToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
         studentToolStripMenuItem.Text = "Student";
         // 
         // ordnerToolStripMenuItem
         // 
         ordnerToolStripMenuItem.Name = "ordnerToolStripMenuItem";
         ordnerToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
         ordnerToolStripMenuItem.Text = "Öffne Ordner";
         ordnerToolStripMenuItem.Click += new System.EventHandler(this.ordnerToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
         // 
         // projektordnerToolStripMenuItem
         // 
         this.projektordnerToolStripMenuItem.Name = "projektordnerToolStripMenuItem";
         this.projektordnerToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
         this.projektordnerToolStripMenuItem.Text = "Öffne Projektordner";
         this.projektordnerToolStripMenuItem.Click += new System.EventHandler(this.projektordnerToolStripMenuItem_Click);
         // 
         // updateProjektordnerToolStripMenuItem
         // 
         this.updateProjektordnerToolStripMenuItem.Name = "updateProjektordnerToolStripMenuItem";
         this.updateProjektordnerToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
         this.updateProjektordnerToolStripMenuItem.Text = "Update Projektordner";
         this.updateProjektordnerToolStripMenuItem.Click += new System.EventHandler(this.updateProjektordnerToolStripMenuItem_Click);
         // 
         // projektToolStripMenuItem
         // 
         projektToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordnerToolStripMenuItem2,
            this.updateToolStripMenuItem});
         projektToolStripMenuItem.Name = "projektToolStripMenuItem";
         projektToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
         projektToolStripMenuItem.Text = "Projekt";
         // 
         // ordnerToolStripMenuItem2
         // 
         this.ordnerToolStripMenuItem2.Name = "ordnerToolStripMenuItem2";
         this.ordnerToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
         this.ordnerToolStripMenuItem2.Text = "Öffne Ordner";
         this.ordnerToolStripMenuItem2.Click += new System.EventHandler(this.ordnerToolStripMenuItem2_Click);
         // 
         // updateToolStripMenuItem
         // 
         this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
         this.updateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
         this.updateToolStripMenuItem.Text = "Update";
         this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
         // 
         // debugToolStripMenuItem
         // 
         debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            codeToolStripMenuItem,
            codeTestsToolStripMenuItem});
         debugToolStripMenuItem.Name = "debugToolStripMenuItem";
         debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
         debugToolStripMenuItem.Text = "Debug";
         // 
         // codeToolStripMenuItem
         // 
         codeToolStripMenuItem.Name = "codeToolStripMenuItem";
         codeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
         codeToolStripMenuItem.Text = "Code";
         codeToolStripMenuItem.Click += new System.EventHandler(this.codeToolStripMenuItem_Click);
         // 
         // codeTestsToolStripMenuItem
         // 
         codeTestsToolStripMenuItem.Name = "codeTestsToolStripMenuItem";
         codeTestsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
         codeTestsToolStripMenuItem.Text = "Code + Tests";
         codeTestsToolStripMenuItem.Click += new System.EventHandler(this.codeTestsToolStripMenuItem_Click);
         // 
         // einstellungenToolStripMenuItem
         // 
         einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
         einstellungenToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
         einstellungenToolStripMenuItem.Text = "Einstellungen";
         einstellungenToolStripMenuItem.Click += new System.EventHandler(this.einstellungenToolStripMenuItem_Click);
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel});
         this.statusStrip1.Location = new System.Drawing.Point(0, 139);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this.statusStrip1.Size = new System.Drawing.Size(387, 22);
         this.statusStrip1.TabIndex = 10;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // toolStripStatusLabel1
         // 
         this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
         this.toolStripStatusLabel1.Size = new System.Drawing.Size(372, 17);
         this.toolStripStatusLabel1.Spring = true;
         // 
         // toolStripStatusLabel
         // 
         this.toolStripStatusLabel.Name = "toolStripStatusLabel";
         this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
         this.toolStripStatusLabel.Visible = false;
         // 
         // projectComboBox
         // 
         this.projectComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.projectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.projectComboBox.FormattingEnabled = true;
         this.projectComboBox.Location = new System.Drawing.Point(82, 3);
         this.projectComboBox.Name = "projectComboBox";
         this.projectComboBox.Size = new System.Drawing.Size(278, 21);
         this.projectComboBox.Sorted = true;
         this.projectComboBox.TabIndex = 11;
         this.projectComboBox.SelectedIndexChanged += new System.EventHandler(this.projectComboBox_SelectedIndexChanged);
         // 
         // revisionTextBox
         // 
         this.revisionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.revisionTextBox.Location = new System.Drawing.Point(82, 82);
         this.revisionTextBox.Name = "revisionTextBox";
         this.revisionTextBox.Size = new System.Drawing.Size(278, 20);
         this.revisionTextBox.TabIndex = 3;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(387, 161);
         this.Controls.Add(this.statusStrip1);
         this.Controls.Add(menuStrip1);
         this.Controls.Add(tableLayoutPanel1);
         this.Icon = global::JPPSVN.Properties.Resources.Icon32;
         this.MainMenuStrip = menuStrip1;
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(1000000, 200);
         this.MinimumSize = new System.Drawing.Size(350, 200);
         this.Name = "MainForm";
         this.Text = "JPP SVN";
         tableLayoutPanel1.ResumeLayout(false);
         tableLayoutPanel1.PerformLayout();
         menuStrip1.ResumeLayout(false);
         menuStrip1.PerformLayout();
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox userTextBox;
//        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private NumberTextBox revisionTextBox;
      private System.Windows.Forms.TextBox nameTextBox;
      private System.Windows.Forms.ComboBox projectComboBox;
      private System.Windows.Forms.ToolStripMenuItem ordnerToolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem projektordnerToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem updateProjektordnerToolStripMenuItem;
   }
}

