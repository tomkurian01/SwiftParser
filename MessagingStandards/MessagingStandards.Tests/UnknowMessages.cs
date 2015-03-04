using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using MessagingStandards.Entities.SWIFT;

namespace MessagingStandards.Tests
{
    [TestClass]
    public class UnknowMessages
    {
        string mockedSwiftMessage = @"C:\Personal\Parser\MockSwiftTest.txt";

        [TestMethod]
        public void Check_Tag33S()
        {
            string str;
             string qualifier = "";

            using (StreamReader sr = File.OpenText(mockedSwiftMessage))
            {
                str = sr.ReadToEnd();
            }


            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "33S")
                {
                    qualifier = block.Qualifier;
                }
            }


            Assert.AreEqual("GBP", qualifier);
        }


    }
}
