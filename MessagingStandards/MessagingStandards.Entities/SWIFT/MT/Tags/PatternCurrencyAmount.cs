using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternCurrencyAmount : Tag, ITag
    {
        // 3!a15d	(Price or Currency) (Amount)
        public ITag GetTagValues(string resultText)
        {
            base.GetTagName(resultText);
            this.Code = resultText.ParseWithStringAndIndex(this.TagName + ":", 3);
            this.Value = resultText.ToEndOfString(this.Code).Trim();
            return this;
        }
    }
}
