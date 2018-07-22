using System;
using System.Windows.Forms;

namespace JPPSVN {
	internal class FolderSelectionComponent : TableLayoutPanel {
      public string Path { get => TextBox.Text; set => TextBox.Text = value; }

      public Button Button { get; }

		public TextBox TextBox { get; }

      public FolderSelectionComponent() {
			Button = new Button();
			TextBox = new TextBox();
			Button.Click += Button_Click;

			ColumnCount = 2;
			RowCount = 1;
			RowStyles.Add(new RowStyle());
			ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			ColumnStyles.Add(new ColumnStyle());
			Controls.Add(TextBox, 0, 0);
			Controls.Add(Button, 1, 0);
			Margin = new Padding(0);

			Button.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			Button.TabIndex = 0;
			Button.Text = "...";
			Button.UseVisualStyleBackColor = true;
			Button.AutoSize = true;
			Button.AutoSizeMode = AutoSizeMode.GrowAndShrink;

			TextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			TextBox.TabIndex = 1;
			//textBox.ReadOnly = true;
		}

		private void Button_Click(object sender, EventArgs e) {
			using(var fbd = new FolderBrowserDialog()) {
				fbd.SelectedPath = TextBox.Text;
				DialogResult result = fbd.ShowDialog();

				if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
					TextBox.Text = fbd.SelectedPath;
				}
			}
		}
	}
}
