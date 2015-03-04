using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternOptionalSingleSlashSeperator : Tag, ITag
    {
        // 4!c[/x] Optional Slash Seperator

        public ITag GetTagValues(string resultText)
        {
            base.GetTagName(resultText);

            if(resultText.Contains("/"))
            {
                this.Qualifier = resultText.ParseFromString(this.TagName + ":", "/");
                this.Value = resultText.ToEndOfString(this.Qualifier + "/");
            }

            else
            {
                this.Value = resultText.ToEndOfString(this.TagName + ":");
            }

            return this;
        }
    }
}
