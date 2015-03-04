using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternDoubleSlashSeperator : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            // :4c//4!c	(Qualifier) (Value)
            // :4c//4*35x (Qualifier) (Narrative)
            // :4c//10*35x	(Qualifier) (Narrative)

            base.GetTagName(resultText);

            if (resultText.Contains("::"))
            {
                this.Qualifier = resultText.Between(this.TagName + "::", "/").Trim();
                this.Value = resultText.ToEndOfString("//").TrimAllNewLines();
            }
            else
            {
                this.Qualifier = resultText.Between(this.TagName + ":", "/").Trim();
                this.Value = resultText.ToEndOfString("//").TrimAllNewLines();
            }

            return this;
        }
    }
}
