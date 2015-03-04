using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public interface ITag
    {
        string TagName { get; set; }
        string Qualifier { get; set; }
        string Type { get; set; }
        string Code { get; set; }
        string Value { get; set; }
        string Description { get; set; }


        ITag GetTagValues(string resultText);
    }
}
