using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagingStandards.Entities.SWIFT
{
    public class ApplicationHeader 
    {
        public string SwiftDirection { get; set; }
        public string MessageType { get; set; }
        public string ReceiverBIC { get; set; }
        public string BranchCode { get; set; }

        public ApplicationHeader() { }

        public ApplicationHeader(Dictionary<string, string> parsedSwiftMessage)
        {
            string swiftSection = parsedSwiftMessage["ApplicationHeader"];
            SwiftDirection = swiftSection.Substring(0, 1);
            MessageType = swiftSection.Substring(1, 3);
            if (swiftSection.Length < 24)
            {
                ReceiverBIC = swiftSection.Substring(4, 8);
            }

            else
            {

                ReceiverBIC = swiftSection.Substring(14, 8);
            }
        }

    }
}
