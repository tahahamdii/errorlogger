using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public enum ErrorSeverity
    {
        Critical,
        NonCritical
    }
    public class Error
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; } // Critical / Non-critical
        public DateTime Timestamp { get; set; }
        public string Category { get; set; } // UI, Backend, etc.
    }
}

