namespace JPPSVN {
    partial class SourceFolderSelectionForm {
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
            System.Windows.Forms.GroupBox groupBox2;
            this.createNewRadioButton = new System.Windows.Forms.RadioButton();
            this.createNewTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.targetFolderSelectionComponent = new JPPSVN.FolderSelectionComponent();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.useExistingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.useExistingFolderSelectionComponent = new JPPSVN.FolderSelectionComponent();
            this.useExistingRadioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nextButton = new System.Windows.Forms.Button();
            this.keepUpdatedCheckBox = new System.Windows.Forms.CheckBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox2.SuspendLayout();
            this.createNewTableLayoutPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.useExistingTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(this.createNewRadioButton);
            groupBox2.Controls.Add(this.createNewTableLayoutPanel);
            groupBox2.Location = new System.Drawing.Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(483, 95);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // createNewRadioButton
            // 
            this.createNewRadioButton.AutoSize = true;
            this.createNewRadioButton.Location = new System.Drawing.Point(10, -2);
            this.createNewRadioButton.Name = "createNewRadioButton";
            this.createNewRadioButton.Size = new System.Drawing.Size(187, 17);
            this.createNewRadioButton.TabIndex = 0;
            this.createNewRadioButton.TabStop = true;
            this.createNewRadioButton.Text = "Neuen Repository-Ordner erstellen";
            this.createNewRadioButton.UseVisualStyleBackColor = true;
            this.createNewRadioButton.CheckedChanged += new System.EventHandler(this.createNewRadioButton_CheckedChanged);
            // 
            // createNewTableLayoutPanel
            // 
            this.createNewTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createNewTableLayoutPanel.AutoSize = true;
            this.createNewTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createNewTableLayoutPanel.ColumnCount = 2;
            this.createNewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.createNewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.createNewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.createNewTableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.createNewTableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.createNewTableLayoutPanel.Controls.Add(this.targetFolderSelectionComponent, 1, 1);
            this.createNewTableLayoutPanel.Controls.Add(this.urlTextBox, 1, 0);
            this.createNewTableLayoutPanel.Location = new System.Drawing.Point(6, 21);
            this.createNewTableLayoutPanel.Name = "createNewTableLayoutPanel";
            this.createNewTableLayoutPanel.RowCount = 2;
            this.createNewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.createNewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.createNewTableLayoutPanel.Size = new System.Drawing.Size(472, 55);
            this.createNewTableLayoutPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Repository-URL";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Repository-Ordner";
            // 
            // targetFolderSelectionComponent
            // 
            this.targetFolderSelectionComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.targetFolderSelectionComponent.AutoSize = true;
            this.targetFolderSelectionComponent.ColumnCount = 2;
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.targetFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.targetFolderSelectionComponent.Location = new System.Drawing.Point(98, 26);
            this.targetFolderSelectionComponent.Margin = new System.Windows.Forms.Padding(0);
            this.targetFolderSelectionComponent.Name = "targetFolderSelectionComponent";
            this.targetFolderSelectionComponent.Path = "";
            this.targetFolderSelectionComponent.RowCount = 2;
            this.targetFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.targetFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.targetFolderSelectionComponent.Size = new System.Drawing.Size(374, 29);
            this.targetFolderSelectionComponent.TabIndex = 2;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.Location = new System.Drawing.Point(101, 3);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(368, 20);
            this.urlTextBox.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.useExistingTableLayoutPanel);
            this.groupBox1.Controls.Add(this.useExistingRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // useExistingTableLayoutPanel
            // 
            this.useExistingTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.useExistingTableLayoutPanel.AutoSize = true;
            this.useExistingTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.useExistingTableLayoutPanel.ColumnCount = 2;
            this.useExistingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.useExistingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.useExistingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.useExistingTableLayoutPanel.Controls.Add(this.label3, 0, 0);
            this.useExistingTableLayoutPanel.Controls.Add(this.useExistingFolderSelectionComponent, 1, 0);
            this.useExistingTableLayoutPanel.Location = new System.Drawing.Point(6, 15);
            this.useExistingTableLayoutPanel.Name = "useExistingTableLayoutPanel";
            this.useExistingTableLayoutPanel.RowCount = 1;
            this.useExistingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.useExistingTableLayoutPanel.Size = new System.Drawing.Size(472, 29);
            this.useExistingTableLayoutPanel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Repository-Ordner";
            // 
            // useExistingFolderSelectionComponent
            // 
            this.useExistingFolderSelectionComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.useExistingFolderSelectionComponent.AutoSize = true;
            this.useExistingFolderSelectionComponent.ColumnCount = 2;
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.useExistingFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.useExistingFolderSelectionComponent.Location = new System.Drawing.Point(98, 0);
            this.useExistingFolderSelectionComponent.Margin = new System.Windows.Forms.Padding(0);
            this.useExistingFolderSelectionComponent.Name = "useExistingFolderSelectionComponent";
            this.useExistingFolderSelectionComponent.Path = "";
            this.useExistingFolderSelectionComponent.RowCount = 2;
            this.useExistingFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.useExistingFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.useExistingFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.useExistingFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.useExistingFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.useExistingFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.useExistingFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.useExistingFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.useExistingFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.useExistingFolderSelectionComponent.Size = new System.Drawing.Size(374, 29);
            this.useExistingFolderSelectionComponent.TabIndex = 1;
            // 
            // useExistingRadioButton
            // 
            this.useExistingRadioButton.AutoSize = true;
            this.useExistingRadioButton.Location = new System.Drawing.Point(10, -2);
            this.useExistingRadioButton.Name = "useExistingRadioButton";
            this.useExistingRadioButton.Size = new System.Drawing.Size(232, 17);
            this.useExistingRadioButton.TabIndex = 0;
            this.useExistingRadioButton.TabStop = true;
            this.useExistingRadioButton.Text = "Bestehenden Repository-Ordner verwenden";
            this.useExistingRadioButton.UseVisualStyleBackColor = true;
            this.useExistingRadioButton.CheckedChanged += new System.EventHandler(this.useExistingRadioButton_CheckedChanged);
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
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nextButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.keepUpdatedCheckBox, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(489, 240);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Location = new System.Drawing.Point(411, 196);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 41);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "Weiter";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // keepUpdatedCheckBox
            // 
            this.keepUpdatedCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.keepUpdatedCheckBox.AutoSize = true;
            this.keepUpdatedCheckBox.Location = new System.Drawing.Point(288, 173);
            this.keepUpdatedCheckBox.Name = "keepUpdatedCheckBox";
            this.keepUpdatedCheckBox.Size = new System.Drawing.Size(198, 17);
            this.keepUpdatedCheckBox.TabIndex = 3;
            this.keepUpdatedCheckBox.Text = "Repository automatisch aktualisieren";
            this.keepUpdatedCheckBox.UseVisualStyleBackColor = true;
            // 
            // SourceFolderSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 264);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SourceFolderSelectionForm";
            this.Text = "SourceFolderSelectionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SourceFolderSelectionForm_FormClosing);
            this.Load += new System.EventHandler(this.SourceFolderSelectionForm_Load);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            this.createNewTableLayoutPanel.ResumeLayout(false);
            this.createNewTableLayoutPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.useExistingTableLayoutPanel.ResumeLayout(false);
            this.useExistingTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel createNewTableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton createNewRadioButton;
        private System.Windows.Forms.RadioButton useExistingRadioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel useExistingTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FolderSelectionComponent targetFolderSelectionComponent;
        private FolderSelectionComponent useExistingFolderSelectionComponent;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.CheckBox keepUpdatedCheckBox;
    }
}