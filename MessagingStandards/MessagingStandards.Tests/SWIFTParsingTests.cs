using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using MessagingStandards.SWIFT;
using MessagingStandards.Entities.SWIFT;
using MessagingStandards.Entities.SWIFT.MT.Tags;

namespace MessagingStandards.Tests
{
    [TestClass]
    public class SWIFTParsingTests
    {
        string samplemessagelocation = @"C:\Personal\Parser\Sample_548_Updated.txt";
        string samplemessagelocationlongstring = @"C:\Personal\Parser\Sample_548_LongString.txt";
        string mockedSwiftMessage = @"C:\Personal\Parser\MockSwiftTest.txt";
        

        [TestMethod]
        public void SeperateStringIntoSWIFTBlocks()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocation))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string,string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());

            Assert.AreEqual(4, swiftBlocks.Count());
        }

        [TestMethod]
        public void FindSenderBIC()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocation))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string, string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());
            BasicHeader Sender = new BasicHeader(swiftBlocks);
            


            Assert.AreEqual("TOMSMSGS", Sender.SenderBIC);
        }

        [TestMethod]
        public void FindBranchCode()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocation))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string, string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());
            BasicHeader Sender = new BasicHeader(swiftBlocks);


            Assert.AreEqual("JPX", Sender.BranchCode);
        }

        [TestMethod]
        public void FindReceiverBIC()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocation))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string, string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());
            ApplicationHeader Receiver = new ApplicationHeader(swiftBlocks);



            Assert.AreEqual("CITIJPJT", Receiver.ReceiverBIC);
        }

        [TestMethod]
        public void FindMessageType()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocation))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string, string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());
            ApplicationHeader Receiver = new ApplicationHeader(swiftBlocks);



            Assert.AreEqual("548", Receiver.MessageType);
        }

        [TestMethod]
        public void SeperateTagsByColon()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string, string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());

            List<string> listOfTags = new List<string>();

            var Block4 = swiftBlocks["TextBlock"];
            listOfTags = message.Block4ToList(Block4);

            Assert.AreEqual(33, listOfTags.Count);
            
        }

        [TestMethod]
        public void SeperateTagsByColonFromSwiftString()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string, string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());

            List<string> listOfTags = new List<string>();

            var Block4 = swiftBlocks["TextBlock"];

            listOfTags = message.Block4ToList(Block4);

            Assert.AreEqual(33, listOfTags.Count);

        }

        [TestMethod]
        public void FormatSwiftTagsToMoneyValues()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocation))
            {
                str = sr.ReadToEnd();
            }

            List<string> listOfTags = new List<string>();

            TagFormatter formatter = new TagFormatter();
            SwiftMessage message = new SwiftMessage();

            message.ParseSwiftMessage(str.Trim());
            message.Block4 = formatter.MoneyFormatter(message.Block4);

            foreach (var swiftTag in message.Block4)
            {
                if (swiftTag.TagName == "19A")
                {
                    Assert.AreEqual("25858462.23", swiftTag.Value);
                }
            }

        }

   }

}

