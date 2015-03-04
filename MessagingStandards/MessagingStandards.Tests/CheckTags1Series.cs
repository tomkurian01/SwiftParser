using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using MessagingStandards.Entities.SWIFT;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Tests
{
    [TestClass]
    public class CheckTags1Series
    {
        string sample103 = @"C:\Personal\Parser\Sample_103.txt";
        string sample101 = @"C:\Personal\Parser\BEL_UBSCH10.fin";

        [TestMethod]
        public void Check_Tag23B()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "23B")
                {
                    value = block.Value;
                }
            }


            Assert.AreEqual("CRED", value);
        }


        [TestMethod]
        public void Check_Tag28D()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(sample101))
            {
                str = sr.ReadToEnd();
            }

            str = str.ConvertFromUnix();
            

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "28D")
                {
                    value = block.Value;
                }
            }

            
            Assert.AreEqual("1", value);
        }

        [TestMethod]
        public void Check_Tag33B()
        {

            string str;
            string value = "";
            string valuetype = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "33B")
                {
                    valuetype = block.Code;
                    value = block.Value;
                }
            }


            Assert.AreEqual("3520000,", value);
            Assert.AreEqual("JPY", valuetype);
        }

        [TestMethod]
        public void Check_Tag50K()
        {

            string str;
            string value = "";
            string description = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "50K")
                {
                    value = block.Value;
                    description = block.Description;
                }
            }

            Assert.AreEqual("EUROXXXEI", value);
        }

        [TestMethod]
        public void Check_Tag52A()
        {

            string str;
            string value = "";
            string description = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "52A")
                {
                    value = block.Value;
                    description = block.Description;
                }
            }

            Assert.AreEqual("FEBXXXM1", value);
        }

        [TestMethod]
        public void Check_Tag53A()
        {

            string str;
            string value = "";
            string description = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "53A")
                {
                    value = block.Value;
                    description = block.Description;
                }
            }

            Assert.AreEqual("MHCXXXJT", value);
        }

        [TestMethod]
        public void Check_Tag54A()
        {

            string str;
            string value = "";
            string description = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "54A")
                {
                    value = block.Value;
                    description = block.Description;
                }
            }

            Assert.AreEqual("FOOBICXX", value);
        }

        [TestMethod]
        public void Check_Tag59()
        {

            string str;
            string value = "";
            string description = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "59")
                {
                    value = block.Value;
                    description = block.Description;
                }
            }

            Assert.AreEqual("13212312", value);
            Assert.AreEqual("RECEIVER NAME S.A", description);
        }

        [TestMethod]
        public void Check_Tag70()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "70")
                {
                    value = block.Value;
                }
            }


            Assert.AreEqual("FUTURES", value);
        }

        [TestMethod]
        public void Check_Tag71A()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "71A")
                {
                    value = block.Value;
                }
            }


            Assert.AreEqual("SHA", value);
        }

        [TestMethod]
        public void Check_Tag71F()
        {

            string str;
            string value = "";
            string currency = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "71F")
                {
                    value = block.Value;
                    currency = block.Code;
                }
            }


            Assert.AreEqual("2,34", value);
            Assert.AreEqual("EUR", currency);
        }

        [TestMethod]
        public void Check_Tag71G()
        {

            string str;
            string value = "";
            string currency = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "71G")
                {
                    value = block.Value;
                    currency = block.Code;
                }
            }


            Assert.AreEqual("12,00", value);
            Assert.AreEqual("EUR", currency);
        }
    }
}
