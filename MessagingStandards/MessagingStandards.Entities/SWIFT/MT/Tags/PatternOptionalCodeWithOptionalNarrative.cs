using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternOptionalCodeWithOptionalNarrative : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            // :4c/[8c]/4!c[/30x]	(Qualifier) (Issuer Code) (Place) (Narrative)

            base.GetTagName(resultText);

            if (resultText.Contains("//"))
            {
                this.Qualifier = resultText.Between("::", "/");
                this.Value = resultText.ParseWithStringAndIndex(this.Qualifier + "//", 4);
                this.Description = resultText.ToEndOfString(this.Value);
            }

            else
            {
                this.Qualifier = resultText.Between("::", "/");
                this.Code = resultText.ParseFromString(this.Qualifier + "/", "/");
                this.Value = resultText.ToEndOfString(this.Code + "/");
                this.Description = resultText.ToEndOfString(this.Value);
            }

            return this;
        }
    }
}
