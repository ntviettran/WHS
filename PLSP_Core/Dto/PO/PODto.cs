using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto.PO
{
    public class POCreateDto
    {
        public string PO { get; set; } = String.Empty;
        public string MO { get; set; } = String.Empty;
        public string CountryCode { get; set; } = String.Empty;
        public int IdItem { get; set; }
    }


    public class PODto : POCreateDto
    {
        public int Id { get; set; }
    }
}