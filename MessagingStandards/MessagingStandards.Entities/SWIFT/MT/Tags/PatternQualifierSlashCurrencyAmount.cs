using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternQualifierSlashCurrencyAmount : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            base.GetTagName(resultText);

            if (resultText.Contains("//"))
            {
                
                this.Qualifier = resultText.ParseFromString(this.TagName + ":", "/");
                this.Code = resultText.ParseWithStringAndIndex(this.Qualifier + "//", 3);
                this.Value = resultText.ToEndOfString(this.Code);
            }

            else
            {
                
                this.Qualifier = resultText.ParseFromString(this.TagName + ":", "/");
                this.Code = resultText.ParseWithStringAndIndex(this.Qualifier + "/", 3);
                this.Value = resultText.ToEndOfString(this.Code);
            }

            return this;
        }
    }
}
