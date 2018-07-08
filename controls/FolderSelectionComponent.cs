using System;
using System.Windows.Forms;

namespace JPPSVN {
	internal class FolderSelectionComponent : TableLayoutPanel {
        private readonly Button button;
        private readonly TextBox textBox;

        public TextBox TextBox => textBox;

        public string Path {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public Button Button => button;

        public FolderSelectionComponent() {
            button = new Button();
            textBox = new TextBox();
            button.Click += Button_Click;
            ColumnCount = 2;
            RowCount = 1;
            RowStyles.Add(new System.Windows.Forms.RowStyle());
            ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            Controls.Add(textBox, 0, 0);
            Controls.Add(button, 1, 0);
            Margin = new System.Windows.Forms.Padding(0);
            
            button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            button.TabIndex = 0;
            button.Text = "...";
            button.UseVisualStyleBackColor = true;
            button.AutoSize = true;
            button.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            textBox.TabIndex = 1;
            //textBox.ReadOnly = true;
        }

        private void Button_Click(object sender, EventArgs e) {
            using(var fbd = new FolderBrowserDialog()) {
                fbd.SelectedPath = textBox.Text;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                    textBox.Text = fbd.SelectedPath;
                }
            }
        }
    }
}
