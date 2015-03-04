using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternDoubleSlashTypeQuantity: Tag, ITag
    {
        // :4c//4!c/15d	 (Qualifier) (Type) (Quantity)

        public ITag GetTagValues(string resultText)
        {
            base.GetTagName(resultText);

            if (resultText.Contains("::"))
            {
                this.Qualifier = resultText.Between(this.TagName + "::", "/");
                this.Type = resultText.ParseFromString(this.Qualifier + "//", "/");
                this.Value = resultText.ToEndOfString(this.Type + "/").TrimAllNewLines();
            }
            else
            {
                this.Qualifier = resultText.Between(this.TagName + ":", "/");
                this.Type = resultText.ParseFromString(this.Qualifier + "//", "/");
                this.Value = resultText.ToEndOfString(this.Type + "/").TrimAllNewLines();
            }

            return this;
        }
    }
}
