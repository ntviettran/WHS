using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Utils
{
    public class GridViewUtils
    {
        public static void SetBuffer(DataGridView gridView)
        {
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null,
                gridView,
                new object[] { true }
            );
        }
    }
}
