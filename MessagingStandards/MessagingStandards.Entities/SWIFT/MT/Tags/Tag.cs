using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class Tag
    {
        public string TagName { get; set; }
        public string Qualifier { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public void GetTagName(string swiftText)
        {
            this.TagName = swiftText.ParseFromString(":", ":");
        }
    }
}
