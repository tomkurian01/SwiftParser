using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternSignCurrencyAmount : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            // :4c//[N]3!a15d	(Qualifier) (Sign) (Currency) (Amount)

            base.GetTagName(resultText);

            if (resultText.Contains("+") || resultText.Contains("-"))
            {
                string sign = "";
                this.Qualifier = resultText.Between("::", "/");
                sign = resultText.ParseWithStringAndIndex("//", 1);
                this.Code = resultText.ParseWithStringAndIndex(sign, 3);
                this.Value = sign + resultText.ToEndOfString(this.Code);
            }

            else
            {
                this.Qualifier = resultText.Between("::", "/");
                this.Code = resultText.ParseWithStringAndIndex("//", 3);
                this.Value = resultText.ToEndOfString(this.Code);
            }

            return this;
        }

    }
}
