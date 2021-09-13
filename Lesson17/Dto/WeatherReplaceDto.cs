using System.Collections.Generic;

namespace Lesson17.Dto
{
    public class WeatherReplaceDto
    {
        public bool Append { get; set; }
        public List<string> ReplaceList { get; set; } = new List<string>();
    }
}
