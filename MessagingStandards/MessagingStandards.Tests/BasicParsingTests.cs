using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MessagingStandards.Entities.SWIFT.MT.Tags;
using NUnit.Framework;

namespace MessagingStandards.Tests
{
    [TestFixture]
    public class BasicParsingTests
    {
        [Test]
        public void GetTagName()
        {
            string Tag25D = ":25D::MTCH//MACH";
            PatternOptionalCode result = new PatternOptionalCode();

            result.GetTagValues(Tag25D);

            Assert.That("25D", Is.EqualTo(result.TagName));

        }
    }
}
