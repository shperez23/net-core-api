using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Article
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public DateTime PublishedAt { get; set; }


    }
}
