using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternSequenceSeperator : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            base.GetTagName(resultText);
            return this;
        }
    }
}
