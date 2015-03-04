using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternOptionalSubFunction : Tag, ITag
    {
        // :4!c[/4!c]	(Function) (SubFuction)

        public ITag GetTagValues(string resultText)
        {
            base.GetTagName(resultText);

            if (resultText.Contains("/"))
            {
                this.Value = resultText.Between(this.TagName + ":", "/");
                this.Code = resultText.ParseWithStringAndIndex(this.Value + "/", 4).Trim();
            }

            else
            {
                this.Value = resultText.ToEndOfString(this.TagName + ":").TrimColon().Trim();
            }

            return this;
        }
    }
}
