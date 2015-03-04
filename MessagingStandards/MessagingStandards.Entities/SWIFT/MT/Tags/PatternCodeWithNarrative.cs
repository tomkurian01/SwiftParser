using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternCodeWithNarrative : Tag, ITag
    {
        //:4c/8c/34x (Qualifier) (Issuer Code) (Proprietory Code)

        public ITag GetTagValues(string resultText)
        {
            base.GetTagName(resultText);

            this.Qualifier = resultText.Between("::", "/");
            this.Code = resultText.ParseFromString(this.Qualifier + "/", "/");
            this.Value = resultText.ToEndOfString(this.Code + "/");

            return this;
        }

    }
}
