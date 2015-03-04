using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class TagFormatter
    {
        public List<ITag> MoneyFormatter(List<ITag> listOfTags)
        {
            foreach(var swiftTag in listOfTags)
            {
                if(swiftTag.Value.Contains(","))
                {
                    if (swiftTag.Value.IndexOf(",") == (swiftTag.Value.Length - 1))
                    {
                        var newValue = swiftTag.Value.Replace(",", ".00");
                        swiftTag.Value = newValue;
                
                    }

                    else
                    {
                        var newValue = swiftTag.Value.Replace(",", ".");
                        swiftTag.Value = newValue;
                    }
                }
            }

            return listOfTags;
        }

        public TagFormatter() { }
    }
}
