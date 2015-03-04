using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class Tag35B : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            List<String> listOfSecurity = new List<string>();

            if (resultText.Substring(5, 4) == "ISIN")
            {
                this.Qualifier = resultText.Substring(5, 4);
                this.Value = resultText.ParseWithStringAndIndex("ISIN ", 12);
                this.Description = resultText.ToEndOfString(this.Value).Trim();
                this.TagName = "35B";
            }

            else
            {
                this.Qualifier = resultText.ParseWithStringAndIndex(":/", 2);
                this.Value = resultText.ToEndOfString(this.Qualifier + "/");
            }

            return this;
        }

        
        public Tag35B()
        {
            TagName = "35B";
        }
    }
}
