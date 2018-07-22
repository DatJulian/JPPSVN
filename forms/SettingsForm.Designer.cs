namespace JPPSVN.forms {
    partial class SettingsForm {
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
         this.components = new System.ComponentModel.Container();
         System.Windows.Forms.Label label1;
         System.Windows.Forms.Label label2;
         System.Windows.Forms.Label label3;
         System.Windows.Forms.Label label4;
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.repositoryURLTextBox = new System.Windows.Forms.TextBox();
         this.ideaFindAutomaticCheckBox = new System.Windows.Forms.CheckBox();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.okButton = new System.Windows.Forms.Button();
         this.cancelButton = new System.Windows.Forms.Button();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.outputFolderSelectionComponent = new JPPSVN.FolderSelectionComponent();
         this.repositoryFolderSelectionComponent = new JPPSVN.FolderSelectionComponent();
         this.ideaFolderSelectionComponent = new JPPSVN.FolderSelectionComponent();
         label1 = new System.Windows.Forms.Label();
         label2 = new System.Windows.Forms.Label();
         label3 = new System.Windows.Forms.Label();
         label4 = new System.Windows.Forms.Label();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.tableLayoutPanel2.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         label1.AutoSize = true;
         label1.Location = new System.Drawing.Point(3, 8);
         label1.Name = "label1";
         label1.Size = new System.Drawing.Size(92, 13);
         label1.TabIndex = 1;
         label1.Text = "Zielordner";
         // 
         // label2
         // 
         label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         label2.AutoSize = true;
         label2.Location = new System.Drawing.Point(3, 37);
         label2.Name = "label2";
         label2.Size = new System.Drawing.Size(92, 13);
         label2.TabIndex = 1;
         label2.Text = "Repository-Ordner";
         // 
         // label3
         // 
         label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         label3.AutoSize = true;
         label3.Location = new System.Drawing.Point(3, 66);
         label3.Name = "label3";
         label3.Size = new System.Drawing.Size(92, 13);
         label3.TabIndex = 1;
         label3.Text = "IntelliJ-Pfad";
         // 
         // label4
         // 
         label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         label4.AutoSize = true;
         label4.Location = new System.Drawing.Point(3, 107);
         label4.Name = "label4";
         label4.Size = new System.Drawing.Size(92, 13);
         label4.TabIndex = 1;
         label4.Text = "Repository-URL";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.AutoSize = true;
         this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Controls.Add(this.outputFolderSelectionComponent, 1, 0);
         this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(label2, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.repositoryFolderSelectionComponent, 1, 1);
         this.tableLayoutPanel1.Controls.Add(label3, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.ideaFolderSelectionComponent, 1, 2);
         this.tableLayoutPanel1.Controls.Add(label4, 0, 4);
         this.tableLayoutPanel1.Controls.Add(this.repositoryURLTextBox, 1, 4);
         this.tableLayoutPanel1.Controls.Add(this.ideaFindAutomaticCheckBox, 1, 3);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 5;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(439, 124);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // repositoryURLTextBox
         // 
         this.repositoryURLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.repositoryURLTextBox.Location = new System.Drawing.Point(98, 104);
         this.repositoryURLTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
         this.repositoryURLTextBox.Name = "repositoryURLTextBox";
         this.repositoryURLTextBox.Size = new System.Drawing.Size(325, 20);
         this.repositoryURLTextBox.TabIndex = 6;
         // 
         // ideaFindAutomaticCheckBox
         // 
         this.ideaFindAutomaticCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.ideaFindAutomaticCheckBox.AutoSize = true;
         this.ideaFindAutomaticCheckBox.Location = new System.Drawing.Point(286, 87);
         this.ideaFindAutomaticCheckBox.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
         this.ideaFindAutomaticCheckBox.Name = "ideaFindAutomaticCheckBox";
         this.ideaFindAutomaticCheckBox.Size = new System.Drawing.Size(137, 17);
         this.ideaFindAutomaticCheckBox.TabIndex = 5;
         this.ideaFindAutomaticCheckBox.Text = "Automatisch bestimmen";
         this.ideaFindAutomaticCheckBox.UseVisualStyleBackColor = true;
         this.ideaFindAutomaticCheckBox.CheckedChanged += new System.EventHandler(this.ideaFindAutomaticCheckBox_CheckedChanged);
         // 
         // errorProvider
         // 
         this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProvider.ContainerControl = this;
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel2.AutoSize = true;
         this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.tableLayoutPanel2.ColumnCount = 2;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.Controls.Add(this.okButton, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.cancelButton, 1, 0);
         this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 130);
         this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 1;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.Size = new System.Drawing.Size(445, 29);
         this.tableLayoutPanel2.TabIndex = 6;
         // 
         // okButton
         // 
         this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.okButton.Location = new System.Drawing.Point(286, 3);
         this.okButton.Name = "okButton";
         this.okButton.Size = new System.Drawing.Size(75, 23);
         this.okButton.TabIndex = 5;
         this.okButton.Text = "Ok";
         this.okButton.UseVisualStyleBackColor = true;
         this.okButton.Click += new System.EventHandler(this.okButton_Click);
         // 
         // cancelButton
         // 
         this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.cancelButton.Location = new System.Drawing.Point(367, 3);
         this.cancelButton.Name = "cancelButton";
         this.cancelButton.Size = new System.Drawing.Size(75, 23);
         this.cancelButton.TabIndex = 6;
         this.cancelButton.Text = "Abbrechen";
         this.cancelButton.UseVisualStyleBackColor = true;
         this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel3.AutoSize = true;
         this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.tableLayoutPanel3.ColumnCount = 1;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 1);
         this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 12);
         this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 2;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.Size = new System.Drawing.Size(445, 159);
         this.tableLayoutPanel3.TabIndex = 2;
         // 
         // outputFolderSelectionComponent
         // 
         this.outputFolderSelectionComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.outputFolderSelectionComponent.AutoSize = true;
         this.outputFolderSelectionComponent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.outputFolderSelectionComponent.ColumnCount = 2;
         this.outputFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.outputFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.outputFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.outputFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.outputFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.outputFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.outputFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.outputFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.outputFolderSelectionComponent.Location = new System.Drawing.Point(98, 0);
         this.outputFolderSelectionComponent.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
         this.outputFolderSelectionComponent.Name = "outputFolderSelectionComponent";
         this.outputFolderSelectionComponent.Path = "";
         this.outputFolderSelectionComponent.RowCount = 1;
         this.outputFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.outputFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.outputFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.outputFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.outputFolderSelectionComponent.Size = new System.Drawing.Size(325, 29);
         this.outputFolderSelectionComponent.TabIndex = 0;
         // 
         // repositoryFolderSelectionComponent
         // 
         this.repositoryFolderSelectionComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.repositoryFolderSelectionComponent.AutoSize = true;
         this.repositoryFolderSelectionComponent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.repositoryFolderSelectionComponent.ColumnCount = 2;
         this.repositoryFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.repositoryFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.repositoryFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.repositoryFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.repositoryFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.repositoryFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.repositoryFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.repositoryFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.repositoryFolderSelectionComponent.Location = new System.Drawing.Point(98, 29);
         this.repositoryFolderSelectionComponent.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
         this.repositoryFolderSelectionComponent.Name = "repositoryFolderSelectionComponent";
         this.repositoryFolderSelectionComponent.Path = "";
         this.repositoryFolderSelectionComponent.RowCount = 1;
         this.repositoryFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.repositoryFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.repositoryFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.repositoryFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.repositoryFolderSelectionComponent.Size = new System.Drawing.Size(325, 29);
         this.repositoryFolderSelectionComponent.TabIndex = 0;
         // 
         // ideaFolderSelectionComponent
         // 
         this.ideaFolderSelectionComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.ideaFolderSelectionComponent.AutoSize = true;
         this.ideaFolderSelectionComponent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.ideaFolderSelectionComponent.ColumnCount = 2;
         this.ideaFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.ideaFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.ideaFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.ideaFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.ideaFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.ideaFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.ideaFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.ideaFolderSelectionComponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.ideaFolderSelectionComponent.Location = new System.Drawing.Point(98, 58);
         this.ideaFolderSelectionComponent.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
         this.ideaFolderSelectionComponent.Name = "ideaFolderSelectionComponent";
         this.ideaFolderSelectionComponent.Path = "";
         this.ideaFolderSelectionComponent.RowCount = 1;
         this.ideaFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.ideaFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.ideaFolderSelectionComponent.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.ideaFolderSelectionComponent.Size = new System.Drawing.Size(325, 29);
         this.ideaFolderSelectionComponent.TabIndex = 0;
         this.ideaFolderSelectionComponent.Paint += new System.Windows.Forms.PaintEventHandler(this.ideaFolderSelectionComponent_Paint);
         // 
         // SettingsForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(469, 193);
         this.Controls.Add(this.tableLayoutPanel3);
         this.Icon = global::JPPSVN.Properties.Resources.Icon32;
         this.MaximumSize = new System.Drawing.Size(10000, 232);
         this.MinimumSize = new System.Drawing.Size(360, 232);
         this.Name = "SettingsForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Einstellungen";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FolderSelectionComponent outputFolderSelectionComponent;
        private FolderSelectionComponent repositoryFolderSelectionComponent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private FolderSelectionComponent ideaFolderSelectionComponent;
        private System.Windows.Forms.CheckBox ideaFindAutomaticCheckBox;
      private System.Windows.Forms.TextBox repositoryURLTextBox;
      private System.Windows.Forms.ErrorProvider errorProvider;
   }
}