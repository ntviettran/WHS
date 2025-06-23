using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto
{
    public class PageDto<T>
    {
        public int TotalPage { get; set; }
        public int TotalRecord { get; set; }
        public List<T> PageData { get; set; } = new List<T>();

    }
}
