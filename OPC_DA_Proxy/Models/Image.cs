using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPC_DA_Proxy.Models
{
    
    public class Image
    {
        public string title, content;

        public Image() { }

        public Image(string title, string content)
        {
            this.title = title;
            this.content = content;
        }
    }
}