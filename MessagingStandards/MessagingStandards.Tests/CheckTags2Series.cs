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
    public class CheckTags2Series
    {
        string sample202 = @"C:\Personal\Parser\Sample202.txt";
        
        [TestMethod]
        public void Check_Tag20()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(sample202))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "20")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.AreEqual("1098:009:0352", value);
        }


        [TestMethod]
        public void Check_Tag21()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(sample202))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "21")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.AreEqual("MARG", value);
        }

        [TestMethod]
        public void Check_Tag32A()
        {

            string str;
            string value = "";
            string currency = "";
            string swiftDate = "";

            using (StreamReader sr = File.OpenText(sample202))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "32A")
                {
                    value = block.Value;
                    currency = block.Code;
                    swiftDate = block.Qualifier;
                }
            }

            Assert.AreEqual("USD", currency);
            Assert.AreEqual("150000,", value);
            Assert.AreEqual("090203", swiftDate);
        }

        [TestMethod]
        public void Check_Tag53B()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(sample202))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "53B")
                {
                    value = block.Value;
                }
            }

            Assert.AreEqual("47896325", value);
            
        }

        [TestMethod]
        public void Check_Tag57D()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(sample202))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "57D")
                {
                    value = block.Value;
                }
            }
            Assert.AreEqual("FW021000ABA", value);
        }
    }
}
