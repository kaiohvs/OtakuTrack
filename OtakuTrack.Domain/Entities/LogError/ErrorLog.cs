using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtakuTrack.Domain.Entities.LogError
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string StakeTrace { get; set; }
        public DateTime TimesTamp { get; set; }
    }
}
