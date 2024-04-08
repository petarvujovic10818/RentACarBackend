using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.helpers
{
    public class QueryObject
    {
        public string? marka { get; set; } = null;
        public string? karoserija { get; set; } = null;
        public string? model { get; set; } = null;
        public string? gorivo { get; set; } = null;
        public string? zapreminaMotoraRange { get; set; } = null;
        public string? jacinaMotoraRange { get; set; } = null;
        public string? cijenaRange {get; set;} = null;
        public string? sortBy {get; set;} = null;
        public bool isDescending {get; set;} = false;
        public int pageNumber {get; set;} = 1;
        public int pageSize {get; set;} = 10;
        
    }
}