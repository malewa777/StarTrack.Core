using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrack.Core.Models
{
    public class News
    {
        public int Id { get; set; }
        
        public string NewsName { get; set; }
        
        public DateTime DateEdit { get; set; }
        
        public string NewsText { get; set; }

        public int IdUser { get; set; }
    
    }
}
