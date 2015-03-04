using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternYYMMDDCurrencyAmount : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            // 6!n3!a15d	(Date) (Currency) (Amount)

            base.GetTagName(resultText);
            this.Qualifier = resultText.Substring(5, 6);
            this.Code = resultText.Substring(11, 3);
            this.Value = resultText.ToEndOfString(this.Code).Trim();

            return this;
        }

        public PatternYYMMDDCurrencyAmount() { }
    }
}
