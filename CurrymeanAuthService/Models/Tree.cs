using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrymeanAuthService.Models
{
    public class Tree
    {
        public int id { get; set; }
        public string text { get; set; }
        public List<Tree> children { get; set; }
    }
}