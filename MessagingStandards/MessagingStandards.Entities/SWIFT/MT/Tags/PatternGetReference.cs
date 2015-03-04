using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternGetReference : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            // :16X

            base.GetTagName(resultText);

            if (resultText.Contains("::"))
            {
                this.Value = resultText.ToEndOfString(this.TagName + "::").Trim();
            }
            else
            {
                this.Value = resultText.ToEndOfString(this.TagName + ":").Trim();
            }

            return this;
        }
    }
}
