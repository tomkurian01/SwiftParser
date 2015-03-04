using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternSingleSlashSeperator : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            base.GetTagName(resultText);
            this.Qualifier = resultText.ParseFromString(this.TagName + ":","/");
            this.Value = resultText.ToEndOfString(this.Qualifier + "/");
            return this;
        }
    }
}
