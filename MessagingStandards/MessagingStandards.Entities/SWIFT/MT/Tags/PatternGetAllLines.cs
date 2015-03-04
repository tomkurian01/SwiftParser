using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternGetAllLines: Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            base.GetTagName(resultText);
            this.Value = resultText.ToEndOfString(this.TagName + ":").TrimAllNewLines();
            return this;
        }
    }
}
