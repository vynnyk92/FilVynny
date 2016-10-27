using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TestApp.Models
{
    public class Page
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string PageName { get; set; }
        public string PageContent { get; set; }
        
    }
}