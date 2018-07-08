using System;
using System.Windows.Forms;

namespace JPPSVN {
	internal class NumberTextBox : TextBox {
        private bool isTextChanging = false;

        protected override void OnTextChanged(EventArgs e) {
            base.OnTextChanged(e);

            if(isTextChanging) return;
            string text = Text;
            int cursor = SelectionStart;
            char[] arr = new char[text.Length];
            int index = 0;
            int newCursor = cursor;
            for(int i = 0; i<text.Length; ++i) {
                char c = text[i];
                if(char.IsDigit(c)) {
                    arr[index++] = c;
                } else {
                    if(i <= cursor) --newCursor;
                }
            }
            isTextChanging = true;
            Text = new string(arr, 0, index);
            SelectionStart = newCursor;
            isTextChanging = false;
        }
    }
}
