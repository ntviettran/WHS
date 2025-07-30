using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Utils
{
    public static class ShowMessage
    {
        public static DialogResult Error(string message)
        {
            return MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Success(string message)
        {
            return MessageBox.Show(message, "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Warning(string message)
        {
            return MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
