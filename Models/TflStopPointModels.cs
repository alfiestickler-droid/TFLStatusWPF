using System;
using System.Collections.Generic;
using System.Text;

namespace TFLStatusWPF.Models
{
    public class TflStopPointResponse
    {
        public List<StopPointDto> StopPoints { get; set; } = new();
    }

    public class StopPointDto
    {
        public string NaptanId { get; set; } = string.Empty;
        public string CommonName { get; set; } = string.Empty;
        public string StopType { get; set; } = string.Empty;
    }
}
