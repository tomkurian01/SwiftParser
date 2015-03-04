using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace MessagingStandards.SWIFT
{
    public class MTParser
    {
        private bool _isTag;
        private List<string> _swiftTags = new List<string>();

        public List<string> Block4ToList(string message)
        {
            List<string> listOfTags = new List<string>();
            _isTag = false;

            int index = 0;
            var totalStringSize = message.Length;

            while (index < totalStringSize)
            {
                var newIndex = message.GetSwiftTag(index);

                if (newIndex > 0)
                {
                    var result = CheckTag(index + newIndex, totalStringSize, message);

                    if (_isTag == true)
                    {
                        var newTag = message.Substring(index, newIndex);
                        listOfTags.Add(newTag.Trim());
                        index = index + newIndex;
                        _isTag = false;
                    }

                    else
                    {
                        var newTag = message.Substring(index, result);
                        listOfTags.Add(newTag.TrimAllNewLines());
                        index = result;
                        _isTag = false;
                    }
                }

                else
                {
                    var newTag = message.Substring(index, (totalStringSize - index));
                    listOfTags.Add(newTag.TrimEndOfSwift().Trim());
                    index = totalStringSize + 1;

                }

            }

            return listOfTags;

        }

        private int CheckTag(int index, int size, string message)
        {
            int result = 0;

            if (index + 3 >= size || index + 4 >= size)
            {
                result = 0;
            }

            else if (message.Substring(index + 3, 1) == ":" || message.Substring(index + 4, 1) == ":")
            {
                if (CheckValidTag(index, message) == true)
                {
                    result = index;
                    _isTag = true;
                    return result;
                }

                else
                {
                    var displacement = message.GetSwiftTag(index);
                    result = index + displacement;
                    result = CheckTag(result, size, message);
                    _isTag = false;
                }
            }

            else
            {
                var displacement = message.GetSwiftTag(index);
                result = index + displacement;
                result = CheckTag(result, size, message);
                _isTag = false;
            }

            return result;
        }

        private bool CheckValidTag(int index, string message)
        {
            var result = false;

            foreach (var validTag in _swiftTags)
            {
                if (validTag == message.Substring(index + 1, 2) || validTag == message.Substring(index + 1, 3))
                {
                    result = true;
                    return result;
                }
            }

            return result;
        }

        public Dictionary<string, string> SeperateSWIFTFile(string message)
        {
            Dictionary<string, string> swiftMessage = new Dictionary<string, string>();

            if (message.Contains("{1:"))
            {
                string Block1 = message.Between("{1:", "}");
                swiftMessage.Add("BasicHeader", Block1);
            }
            if (message.Contains("{2:"))
            {
                string Block2 = message.Between("{2:", "}");
                swiftMessage.Add("ApplicationHeader", Block2);
            }
            if (message.Contains("{3:"))
            {
                string Block3 = message.Between(":{", "}");
                swiftMessage.Add("UserHeader", Block3);

            }
            if (message.Contains("{4:"))
            {
                string Block4 = message.Between("{4:", "}");
                swiftMessage.Add("TextBlock", Block4);
            }

            if (message.Contains("{5:"))
            {
                string Block5 = message.Between("{5:", "}");
                swiftMessage.Add("Trailer", Block5);

            }

            return swiftMessage;
        }

        private void LoadSwiftTags()
        {
            _swiftTags.Add("11A");
            _swiftTags.Add("11R");
            _swiftTags.Add("11S");
            _swiftTags.Add("12");
            _swiftTags.Add("12A");
            _swiftTags.Add("12B");
            _swiftTags.Add("12C");
            _swiftTags.Add("12E");
            _swiftTags.Add("12F");
            _swiftTags.Add("13A");
            _swiftTags.Add("13B");
            _swiftTags.Add("13C");
            _swiftTags.Add("13D");
            _swiftTags.Add("13E");
            _swiftTags.Add("13J");
            _swiftTags.Add("13K");
            _swiftTags.Add("14A");
            _swiftTags.Add("14C");
            _swiftTags.Add("14D");
            _swiftTags.Add("14F");
            _swiftTags.Add("14G");
            _swiftTags.Add("14J");
            _swiftTags.Add("14S");
            _swiftTags.Add("15A");
            _swiftTags.Add("15B");
            _swiftTags.Add("15C");
            _swiftTags.Add("15D");
            _swiftTags.Add("15E");
            _swiftTags.Add("15F");
            _swiftTags.Add("15G");
            _swiftTags.Add("15H");
            _swiftTags.Add("15I");
            _swiftTags.Add("15J");
            _swiftTags.Add("15K");
            _swiftTags.Add("15L");
            _swiftTags.Add("15M");
            _swiftTags.Add("15N");
            _swiftTags.Add("16A");
            _swiftTags.Add("16R");
            _swiftTags.Add("16S");
            _swiftTags.Add("17A");
            _swiftTags.Add("17B");
            _swiftTags.Add("17F");
            _swiftTags.Add("17G");
            _swiftTags.Add("17N");
            _swiftTags.Add("17O");
            _swiftTags.Add("17R");
            _swiftTags.Add("17T");
            _swiftTags.Add("17U");
            _swiftTags.Add("17V");
            _swiftTags.Add("18A");
            _swiftTags.Add("19");
            _swiftTags.Add("19A");
            _swiftTags.Add("19B");
            _swiftTags.Add("20");
            _swiftTags.Add("20C");
            _swiftTags.Add("20D");
            _swiftTags.Add("21");
            _swiftTags.Add("21A");
            _swiftTags.Add("21B");
            _swiftTags.Add("21C");
            _swiftTags.Add("21D");
            _swiftTags.Add("21E");
            _swiftTags.Add("21F");
            _swiftTags.Add("21G");
            _swiftTags.Add("21N");
            _swiftTags.Add("21P");
            _swiftTags.Add("21R");
            _swiftTags.Add("22");
            _swiftTags.Add("22A");
            _swiftTags.Add("22B");
            _swiftTags.Add("22C");
            _swiftTags.Add("22D");
            _swiftTags.Add("22E");
            _swiftTags.Add("22F");
            _swiftTags.Add("22G");
            _swiftTags.Add("22H");
            _swiftTags.Add("22J");
            _swiftTags.Add("22K");
            _swiftTags.Add("22X");
            _swiftTags.Add("23");
            _swiftTags.Add("23A");
            _swiftTags.Add("23B");
            _swiftTags.Add("23C");
            _swiftTags.Add("23D");
            _swiftTags.Add("23E");
            _swiftTags.Add("23F");
            _swiftTags.Add("23G");
            _swiftTags.Add("24B");
            _swiftTags.Add("24D");
            _swiftTags.Add("25");
            _swiftTags.Add("25A");
            _swiftTags.Add("25D");
            _swiftTags.Add("26A");
            _swiftTags.Add("26B");
            _swiftTags.Add("26C");
            _swiftTags.Add("26D");
            _swiftTags.Add("26E");
            _swiftTags.Add("26F");
            _swiftTags.Add("26H");
            _swiftTags.Add("26N");
            _swiftTags.Add("26P");
            _swiftTags.Add("26T");
            _swiftTags.Add("27");
            _swiftTags.Add("28");
            _swiftTags.Add("28C");
            _swiftTags.Add("28D");
            _swiftTags.Add("28E");
            _swiftTags.Add("29A");
            _swiftTags.Add("29B");
            _swiftTags.Add("29C");
            _swiftTags.Add("29E");
            _swiftTags.Add("29F");
            _swiftTags.Add("29G");
            _swiftTags.Add("29H");
            _swiftTags.Add("29J");
            _swiftTags.Add("29K");
            _swiftTags.Add("30");
            _swiftTags.Add("30F");
            _swiftTags.Add("30G");
            _swiftTags.Add("30H");
            _swiftTags.Add("30P");
            _swiftTags.Add("30Q");
            _swiftTags.Add("30T");
            _swiftTags.Add("30U");
            _swiftTags.Add("30V");
            _swiftTags.Add("30X");
            _swiftTags.Add("31C");
            _swiftTags.Add("31D");
            _swiftTags.Add("31E");
            _swiftTags.Add("31F");
            _swiftTags.Add("31G");
            _swiftTags.Add("31L");
            _swiftTags.Add("31P");
            _swiftTags.Add("31R");
            _swiftTags.Add("31S");
            _swiftTags.Add("31X");
            _swiftTags.Add("32A");
            _swiftTags.Add("32B");
            _swiftTags.Add("32C");
            _swiftTags.Add("32D");
            _swiftTags.Add("32E");
            _swiftTags.Add("32F");
            _swiftTags.Add("32G");
            _swiftTags.Add("32H");
            _swiftTags.Add("32J");
            _swiftTags.Add("32K");
            _swiftTags.Add("32M");
            _swiftTags.Add("32N");
            _swiftTags.Add("32P");
            _swiftTags.Add("32Q");
            _swiftTags.Add("32U");
            _swiftTags.Add("33A");
            _swiftTags.Add("33B");
            _swiftTags.Add("33C");
            _swiftTags.Add("33D");
            _swiftTags.Add("33E");
            _swiftTags.Add("33F");
            _swiftTags.Add("33G");
            _swiftTags.Add("33K");
            _swiftTags.Add("33N");
            _swiftTags.Add("33P");
            _swiftTags.Add("33R");
            _swiftTags.Add("33S");
            _swiftTags.Add("33T");
            _swiftTags.Add("34A");
            _swiftTags.Add("34B");
            _swiftTags.Add("34E");
            _swiftTags.Add("34F");
            _swiftTags.Add("34N");
            _swiftTags.Add("34P");
            _swiftTags.Add("34R");
            _swiftTags.Add("35A");
            _swiftTags.Add("35B");
            _swiftTags.Add("35C");
            _swiftTags.Add("35D");
            _swiftTags.Add("35E");
            _swiftTags.Add("35F");
            _swiftTags.Add("35H");
            _swiftTags.Add("35L");
            _swiftTags.Add("35N");
            _swiftTags.Add("35S");
            _swiftTags.Add("35U");
            _swiftTags.Add("36");
            _swiftTags.Add("36A");
            _swiftTags.Add("36B");
            _swiftTags.Add("36C");
            _swiftTags.Add("36E");
            _swiftTags.Add("37A");
            _swiftTags.Add("37B");
            _swiftTags.Add("37C");
            _swiftTags.Add("37D");
            _swiftTags.Add("37E");
            _swiftTags.Add("37F");
            _swiftTags.Add("37G");
            _swiftTags.Add("37H");
            _swiftTags.Add("37J");
            _swiftTags.Add("37K");
            _swiftTags.Add("37L");
            _swiftTags.Add("37M");
            _swiftTags.Add("37N");
            _swiftTags.Add("37P");
            _swiftTags.Add("37R");
            _swiftTags.Add("37U");
            _swiftTags.Add("38A");
            _swiftTags.Add("38B");
            _swiftTags.Add("38D");
            _swiftTags.Add("38E");
            _swiftTags.Add("38G");
            _swiftTags.Add("38H");
            _swiftTags.Add("38J");
            _swiftTags.Add("39A");
            _swiftTags.Add("39B");
            _swiftTags.Add("39C");
            _swiftTags.Add("39P");
            _swiftTags.Add("40A");
            _swiftTags.Add("40B");
            _swiftTags.Add("40C");
            _swiftTags.Add("40E");
            _swiftTags.Add("40F");
            _swiftTags.Add("41A");
            _swiftTags.Add("41D");
            _swiftTags.Add("42A");
            _swiftTags.Add("42C");
            _swiftTags.Add("42D");
            _swiftTags.Add("42M");
            _swiftTags.Add("42P");
            _swiftTags.Add("43P");
            _swiftTags.Add("43T");
            _swiftTags.Add("44A");
            _swiftTags.Add("44B");
            _swiftTags.Add("44C");
            _swiftTags.Add("44D");
            _swiftTags.Add("44E");
            _swiftTags.Add("44F");
            _swiftTags.Add("45A");
            _swiftTags.Add("45B");
            _swiftTags.Add("46A");
            _swiftTags.Add("46B");
            _swiftTags.Add("47A");
            _swiftTags.Add("47B");
            _swiftTags.Add("48");
            _swiftTags.Add("49");
            _swiftTags.Add("50");
            _swiftTags.Add("50A");
            _swiftTags.Add("50B");
            _swiftTags.Add("50C");
            _swiftTags.Add("50D");
            _swiftTags.Add("50F");
            _swiftTags.Add("50G");
            _swiftTags.Add("50H");
            _swiftTags.Add("50K");
            _swiftTags.Add("50L");
            _swiftTags.Add("51A");
            _swiftTags.Add("51C");
            _swiftTags.Add("51D");
            _swiftTags.Add("52A");
            _swiftTags.Add("52B");
            _swiftTags.Add("52C");
            _swiftTags.Add("52D");
            _swiftTags.Add("52G");
            _swiftTags.Add("53A");
            _swiftTags.Add("53B");
            _swiftTags.Add("53C");
            _swiftTags.Add("53D");
            _swiftTags.Add("53J");
            _swiftTags.Add("54A");
            _swiftTags.Add("54B");
            _swiftTags.Add("54D");
            _swiftTags.Add("55A");
            _swiftTags.Add("55B");
            _swiftTags.Add("55D");
            _swiftTags.Add("56A");
            _swiftTags.Add("56B");
            _swiftTags.Add("56C");
            _swiftTags.Add("56D");
            _swiftTags.Add("56J");
            _swiftTags.Add("57A");
            _swiftTags.Add("57B");
            _swiftTags.Add("57C");
            _swiftTags.Add("57D");
            _swiftTags.Add("57J");
            _swiftTags.Add("58A");
            _swiftTags.Add("58B");
            _swiftTags.Add("58C");
            _swiftTags.Add("58D");
            _swiftTags.Add("58J");
            _swiftTags.Add("59");
            _swiftTags.Add("59A");
            _swiftTags.Add("60F");
            _swiftTags.Add("60M");
            _swiftTags.Add("61");
            _swiftTags.Add("62F");
            _swiftTags.Add("62M");
            _swiftTags.Add("64");
            _swiftTags.Add("65");
            _swiftTags.Add("67A");
            _swiftTags.Add("68A");
            _swiftTags.Add("68B");
            _swiftTags.Add("68C");
            _swiftTags.Add("69A");
            _swiftTags.Add("69B");
            _swiftTags.Add("69C");
            _swiftTags.Add("69D");
            _swiftTags.Add("69E");
            _swiftTags.Add("69F");
            _swiftTags.Add("69J");
            _swiftTags.Add("70");
            _swiftTags.Add("70C");
            _swiftTags.Add("70D");
            _swiftTags.Add("70E");
            _swiftTags.Add("70F");
            _swiftTags.Add("70G");
            _swiftTags.Add("71A");
            _swiftTags.Add("71B");
            _swiftTags.Add("71C");
            _swiftTags.Add("71F");
            _swiftTags.Add("71G");
            _swiftTags.Add("71H");
            _swiftTags.Add("71J");
            _swiftTags.Add("71K");
            _swiftTags.Add("71L");
            _swiftTags.Add("72");
            _swiftTags.Add("73");
            _swiftTags.Add("74");
            _swiftTags.Add("75");
            _swiftTags.Add("76");
            _swiftTags.Add("77A");
            _swiftTags.Add("77D");
            _swiftTags.Add("77E");
            _swiftTags.Add("77F");
            _swiftTags.Add("77G");
            _swiftTags.Add("77H");
            _swiftTags.Add("77J");
            _swiftTags.Add("77T");
            _swiftTags.Add("78");
            _swiftTags.Add("79");
            _swiftTags.Add("80C");
            _swiftTags.Add("82A");
            _swiftTags.Add("82B");
            _swiftTags.Add("82D");
            _swiftTags.Add("82J");
            _swiftTags.Add("82S");
            _swiftTags.Add("83A");
            _swiftTags.Add("83C");
            _swiftTags.Add("83D");
            _swiftTags.Add("83J");
            _swiftTags.Add("84A");
            _swiftTags.Add("84B");
            _swiftTags.Add("84D");
            _swiftTags.Add("84J");
            _swiftTags.Add("85A");
            _swiftTags.Add("85B");
            _swiftTags.Add("85D");
            _swiftTags.Add("85J");
            _swiftTags.Add("86");
            _swiftTags.Add("86A");
            _swiftTags.Add("86B");
            _swiftTags.Add("86D");
            _swiftTags.Add("86J");
            _swiftTags.Add("87A");
            _swiftTags.Add("87B");
            _swiftTags.Add("87D");
            _swiftTags.Add("87J");
            _swiftTags.Add("90A");
            _swiftTags.Add("90B");
            _swiftTags.Add("90C");
            _swiftTags.Add("90D");
            _swiftTags.Add("90E");
            _swiftTags.Add("90F");
            _swiftTags.Add("90J");
            _swiftTags.Add("91A");
            _swiftTags.Add("91B");
            _swiftTags.Add("91C");
            _swiftTags.Add("91D");
            _swiftTags.Add("91E");
            _swiftTags.Add("91F");
            _swiftTags.Add("91G");
            _swiftTags.Add("91H");
            _swiftTags.Add("92A");
            _swiftTags.Add("92B");
            _swiftTags.Add("92C");
            _swiftTags.Add("92D");
            _swiftTags.Add("92E");
            _swiftTags.Add("92F");
            _swiftTags.Add("92J");
            _swiftTags.Add("92K");
            _swiftTags.Add("92L");
            _swiftTags.Add("92M");
            _swiftTags.Add("92N");
            _swiftTags.Add("93A");
            _swiftTags.Add("93B");
            _swiftTags.Add("93C");
            _swiftTags.Add("93D");
            _swiftTags.Add("94A");
            _swiftTags.Add("94B");
            _swiftTags.Add("94C");
            _swiftTags.Add("94D");
            _swiftTags.Add("94F");
            _swiftTags.Add("94G");
            _swiftTags.Add("95C");
            _swiftTags.Add("95P");
            _swiftTags.Add("95Q");
            _swiftTags.Add("95R");
            _swiftTags.Add("95S");
            _swiftTags.Add("95T");
            _swiftTags.Add("95U");
            _swiftTags.Add("95V");
            _swiftTags.Add("97A");
            _swiftTags.Add("97B");
            _swiftTags.Add("97C");
            _swiftTags.Add("98A");
            _swiftTags.Add("98B");
            _swiftTags.Add("98C");
            _swiftTags.Add("98D");
            _swiftTags.Add("98E");
            _swiftTags.Add("99A");
            _swiftTags.Add("99B");
        }

        public MTParser()
        {
            LoadSwiftTags();
        }

    }
}

