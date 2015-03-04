using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using MessagingStandards.Entities.SWIFT;
using MessagingStandards.Entities.SWIFT.MT.Tags;

namespace MessagingStandards.Tests
{
    [TestClass]
    public class CheckTags5Series
    {
        string sample22HAlternatelocation = @"C:\Personal\Parser\Sample_548_22F.txt";
        string samplemessagelocationlongstring = @"C:\Personal\Parser\Sample_548_LongString.txt";
        string sample548 = @"c:\Personal\Parser\Sample_548_negative.txt";
        string sample548_23G = @"C:\Personal\Parser\Sample_548_23G.txt";
        string sample515 = @"C:\Personal\Parser\Sample_515.txt";
        string sample515_90B = @"C:\Personal\Parser\Sample_515_90B.txt";

        [TestMethod]
        public void Check_Tag13A()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());


            foreach (var block in message.Block4)
            {
                if (block.TagName == "13A")
                {
                    value = block.Value;
                }
            }

            Assert.AreEqual("541", value);
        }

        [TestMethod]
        public void Check_Tag19A()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(sample548))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "19A")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.AreEqual("-25858462,",  value);
            Assert.AreEqual("SETT", valueType);
        }

        [TestMethod]
        public void Check_Tag22F()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(sample22HAlternatelocation))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "22F")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.AreEqual("TRAD", value);
            Assert.AreEqual("REDI", valueType);
        }


        [TestMethod]
        public void Check_Tag22H()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "22H")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.AreEqual("APMT", value);
            Assert.AreEqual("PAYM", valueType);
        }

        [TestMethod]
        public void Check_Tag20C_SEME()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "20C" && block.Qualifier == "SEME")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.AreEqual("3640190172704", value);
        }

        [TestMethod]
        public void Check_Tag23G()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(sample548_23G))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "23G")
                {
                    value = block.Value;
                    valueType = block.Code;
                }
            }


            Assert.AreEqual("INST", value);
            Assert.AreEqual("DUPL", valueType);
        }

        [TestMethod]
        public void Check_Tag25D()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "25D")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.AreEqual("MACH", value);
        }


        [TestMethod]
        public void Check_Tag36B()
        {

            string str;
            string value = "";
            string valueType = "";
            string qualifier = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "36B")
                {
                    value = block.Value;
                    valueType = block.Type;
                    qualifier = block.Qualifier;
                }
            }


            Assert.AreEqual("13300,", value);
            Assert.AreEqual("UNIT", valueType);
            Assert.AreEqual("SETT", qualifier);
        }

        [TestMethod]
        public void Check_Tag35B()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "35B")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.AreEqual("JP3843250006", value);
            Assert.AreEqual("ISIN", valueType);
        }

        [TestMethod]
        public void Check_Tag35B_CountryCode()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(sample515_90B))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "35B")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.AreEqual("78764HAD6", value);
            Assert.AreEqual("US", valueType);
        }

        [TestMethod]
        public void Check_Tag70C()
        {

            string str;
            string value = "";
            string qualifier = "";

            using (StreamReader sr = File.OpenText(sample515))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "70C")
                {
                    qualifier = block.Qualifier;
                    value = block.Value;
                }
            }


             Assert.AreEqual("PACO", qualifier);
             Assert.AreEqual("GSCC/TDIDAJ101", value);
         }

        [TestMethod]
        public void Check_Tag70E()
        {

            string str;
            string value = "";
            string qualifier = "";

            using (StreamReader sr = File.OpenText(sample515_90B))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "70E")
                {
                    qualifier = block.Qualifier;
                    value = block.Value;
                }
            }


            Assert.AreEqual("TPRO", qualifier);
            Assert.AreEqual("GSCC/DEST01/DEST02/YIEL5,6 and MSRB / Yield", value);
        }


        [TestMethod]
        public void Check_Tag90A()
        {

            string str;
            string value = "";
            string valueType = "";
            string qualifier = "";

            using (StreamReader sr = File.OpenText(sample515))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "90A")
                {
                    qualifier = block.Qualifier;
                    valueType = block.Type;
                    value = block.Value;
                }
            }


            Assert.AreEqual("0,", value);
            Assert.AreEqual("DEAL", qualifier);
            Assert.AreEqual("PRCT", valueType);
        }

        [TestMethod]
        public void Check_Tag90B()
        {

            string str;
            string value = "";
            string valueType = "";
            string qualifier = "";
            string currency = "";

            using (StreamReader sr = File.OpenText(sample515_90B))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "90B")
                {
                    qualifier = block.Qualifier;
                    valueType = block.Type;
                    value = block.Value;
                    currency = block.Code;
                }
            }


            Assert.AreEqual("10206,89", value);
            Assert.AreEqual("DEAL", qualifier);
            Assert.AreEqual("ACTU", valueType);
            Assert.AreEqual("USD", currency);
        }

        [TestMethod]
        public void Check_Tag94B()
        {

            string str;
            string value = "";
            string valueType = "";
            string qualifier = "";

            using (StreamReader sr = File.OpenText(sample515))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "94B")
                {
                    qualifier = block.Qualifier;
                    valueType = block.Code;
                    value = block.Value;
                }
            }


            
            Assert.AreEqual("TRAD", qualifier);
            Assert.AreEqual("GSCC", valueType);
            Assert.AreEqual("OTMU", value);
        }

        [TestMethod]
        public void Check_Tag95P()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "95P")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.AreEqual("JJSDJPJT", value);
            Assert.AreEqual("PSET", valueType);
        }

        [TestMethod]
        public void Check_Tag95Q()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(sample515_90B))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "95Q")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }

            Assert.AreEqual("SELL", valueType);
            Assert.AreEqual("Goldman Sachs Treasury", value);
        }

        [TestMethod]
        public void Check_Tag95R()
        {

            string str;
            string value = "";
            string code = "";
            string qualifier = "";

            using (StreamReader sr = File.OpenText(sample515))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "95R")
                {
                    value = block.Value;
                    qualifier = block.Qualifier;
                    code = block.Code;
                }
            }


            Assert.AreEqual("SELL", qualifier);
            Assert.AreEqual("GSCC", code);
            Assert.AreEqual("PART1563", value);
        }

        [TestMethod]
        public void Check_Tag97A()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "97A")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.AreEqual("009-043068-313", value);
            Assert.AreEqual("SAFE", valueType);
        }

        [TestMethod]
        public void Check_Tag98A_SettlementDate()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "98A" && block.Qualifier == "SETT")
                {
                    value = block.Value;
                }
            }


            Assert.AreEqual("20140115", value);
        }

        [TestMethod]
        public void Check_Tag98C()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "98C")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.AreEqual("20140114133539", value);
        }
    }


}
