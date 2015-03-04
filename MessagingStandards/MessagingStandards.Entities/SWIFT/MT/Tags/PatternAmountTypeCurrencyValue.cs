using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternAmountTypeCurrencyValue : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            // :4c//4!c/3!a15d	(Qualifier) (Amount Type) (Currency) (Price)

            base.GetTagName(resultText);

            if (resultText.Contains("::"))
            {
                this.Qualifier = resultText.Between(this.TagName + "::", "/");
                this.Type = resultText.ParseFromString(this.Qualifier + "//", "/");
                this.Code = resultText.ParseWithStringAndIndex(this.Type + "/", 3);
                this.Value = resultText.ToEndOfString(this.Code).TrimAllNewLines();
            }
            else
            {
                this.Qualifier = resultText.Between(this.TagName + ":", "/");
                this.Type = resultText.ParseFromString(this.Qualifier + "//", "/");
                this.Code = resultText.ParseWithStringAndIndex(this.Type + "/", 3);
                this.Value = resultText.ToEndOfString(this.Code).TrimAllNewLines();
            }
            return this;

        }
    }
}
