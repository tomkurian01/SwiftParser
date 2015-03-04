using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternNNNValue : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            //3!a<NUMBER>15
            base.GetTagName(resultText);
            this.Qualifier = resultText.ParseWithStringAndIndex(this.TagName + ":", 3);
            this.Value = resultText.ToEndOfString(this.Qualifier).Trim();
            return this;
        }
    }
}
