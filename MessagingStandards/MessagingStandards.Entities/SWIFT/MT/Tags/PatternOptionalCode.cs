using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternOptionalCode : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            // :4c/[8c]/4!c	(Qualifier) (Issuer Code) (Value)

            this.TagName = resultText.ParseFromString(":", ":");

            if (resultText.Contains("//"))
            {
                this.Qualifier = resultText.Between("::", "/");
                this.Value = resultText.ParseWithStringAndIndex(this.Qualifier + "//", 4);
            }

            else
            {
                this.Qualifier = resultText.Between("::", "/");
                this.Code = resultText.ParseFromString(this.Qualifier + "/", "/");
                this.Value = resultText.ParseWithStringAndIndex(this.Code + "/", 4);
            }

            return this;

        }

        public PatternOptionalCode()
        {

        }
    }
}
