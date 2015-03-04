using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using MessagingStandards.Entities.SWIFT;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class TagFactory
    {
        Dictionary<string, Type> _mappings;
        Dictionary<string, string> _swiftTagToITagMapping;
      

        public TagFactory()
        {
            LoadITagDataTypes();
            LoadTagToClassMappings();
        }

        public List<ITag> CreateInstance(string parsedSwiftTag, List<ITag> listOfITags)
        {
            string tagID = parsedSwiftTag.Substring(1, 3);
            Type t = GetITagToCreate(tagID.TrimColon());

            if (t != null)
            {
                ITag t1 = Activator.CreateInstance(t) as ITag;
                t1.GetTagValues(parsedSwiftTag);
                listOfITags.Add(t1);
            }

            return listOfITags;
        }

        private Type GetITagToCreate(string iTagToInstatiate)
        {
            foreach (var tagMapping in _swiftTagToITagMapping.OrderBy(tm => tm.Key))
            {
                if (tagMapping.Key == iTagToInstatiate)
                {
                    iTagToInstatiate = _swiftTagToITagMapping[tagMapping.Key];
                }

            }

            foreach (var mapping in _mappings.OrderBy(map => map.Key))
            {
                if (mapping.Key.Contains(iTagToInstatiate.ToUpper()))
                {
                    return _mappings[mapping.Key];
                }
            }

            return null;
        }

        private void LoadITagDataTypes()
        {
            _mappings = new Dictionary<string, Type>();

            Type[] mappingTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in mappingTypes)
            {
                if (type.GetInterface(typeof(ITag).ToString()) != null)
                {
                    _mappings.Add(type.Name.ToUpper(), type);
                }

            }
        }

        private void LoadTagToClassMappings()
        {
            _swiftTagToITagMapping = new Dictionary<string, string>();

            #region :4c//4!c	(Qualifier) (Value)
            _swiftTagToITagMapping.Add("11A", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("12C", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("13A", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("13J", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("17B", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("20C", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("20D", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("22H", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("36C", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("69J", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("70C", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("70E", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("90E", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("92A", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("92K", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("94C", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("95C", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("95P", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("95Q", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("97A", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("97C", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("98A", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("98C", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("99A", "PatternDoubleSlashSeperator");
            _swiftTagToITagMapping.Add("99B", "PatternDoubleSlashSeperator");
            #endregion

            #region :3!a15d (Price or Currency) (Amount)
            _swiftTagToITagMapping.Add("32B", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("32G", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("32M", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("32U", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("33B", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("33E", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("33F", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("34B", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("71F", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("71G", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("71H", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("71J", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("71K", "PatternCurrencyAmount");
            _swiftTagToITagMapping.Add("71L", "PatternCurrencyAmount");
            #endregion

            #region :4c/[Xc]/4!c	(Qualifier) (Issuer Code) (Value)
            _swiftTagToITagMapping.Add("12A", "PatternOptionalCode");
            _swiftTagToITagMapping.Add("12B", "PatternOptionalCode");
            _swiftTagToITagMapping.Add("13B", "PatternOptionalCode");
            _swiftTagToITagMapping.Add("25D", "PatternOptionalCode");
            _swiftTagToITagMapping.Add("22F", "PatternOptionalCode");
            _swiftTagToITagMapping.Add("24B", "PatternOptionalCode");
            _swiftTagToITagMapping.Add("38B", "PatternOptionalCode");
            _swiftTagToITagMapping.Add("92C", "PatternOptionalCode");
            _swiftTagToITagMapping.Add("93A", "PatternOptionalCode");
            _swiftTagToITagMapping.Add("94D", "PatternOptionalCode");
            _swiftTagToITagMapping.Add("94F", "PatternOptionalCode");
            _swiftTagToITagMapping.Add("98B", "PatternOptionalCode");

            #endregion

            #region :4x or :16x or <Date2> or <Date4>
            _swiftTagToITagMapping.Add("12", "PatternGetReference");
            _swiftTagToITagMapping.Add("12E", "PatternGetReference");
            _swiftTagToITagMapping.Add("12F", "PatternGetReference");
            _swiftTagToITagMapping.Add("13E", "PatternGetReference");
            _swiftTagToITagMapping.Add("14", "PatternGetReference");
            _swiftTagToITagMapping.Add("14C", "PatternGetReference");
            _swiftTagToITagMapping.Add("14D", "PatternGetReference");
            _swiftTagToITagMapping.Add("14F", "PatternGetReference");
            _swiftTagToITagMapping.Add("14J", "PatternGetReference");
            _swiftTagToITagMapping.Add("14S", "PatternGetReference");
            _swiftTagToITagMapping.Add("16A", "PatternGetReference");
            _swiftTagToITagMapping.Add("16R", "PatternGetReference");
            _swiftTagToITagMapping.Add("16S", "PatternGetReference");
            _swiftTagToITagMapping.Add("17A", "PatternGetReference");
            _swiftTagToITagMapping.Add("17F", "PatternGetReference");
            _swiftTagToITagMapping.Add("17G", "PatternGetReference");
            _swiftTagToITagMapping.Add("17N", "PatternGetReference");
            _swiftTagToITagMapping.Add("17O", "PatternGetReference");
            _swiftTagToITagMapping.Add("17R", "PatternGetReference");
            _swiftTagToITagMapping.Add("17T", "PatternGetReference");
            _swiftTagToITagMapping.Add("17U", "PatternGetReference");
            _swiftTagToITagMapping.Add("17V", "PatternGetReference");
            _swiftTagToITagMapping.Add("18A", "PatternGetReference");
            _swiftTagToITagMapping.Add("19", "PatternGetReference");
            _swiftTagToITagMapping.Add("20",  "PatternGetReference");
            _swiftTagToITagMapping.Add("21",  "PatternGetReference");
            _swiftTagToITagMapping.Add("21A", "PatternGetReference");
            _swiftTagToITagMapping.Add("21B", "PatternGetReference");
            _swiftTagToITagMapping.Add("21C", "PatternGetReference");
            _swiftTagToITagMapping.Add("21D", "PatternGetReference");
            _swiftTagToITagMapping.Add("21E", "PatternGetReference");
            _swiftTagToITagMapping.Add("21F", "PatternGetReference");
            _swiftTagToITagMapping.Add("21G", "PatternGetReference");
            _swiftTagToITagMapping.Add("21N", "PatternGetReference");
            _swiftTagToITagMapping.Add("21P", "PatternGetReference");
            _swiftTagToITagMapping.Add("21R", "PatternGetReference");
            _swiftTagToITagMapping.Add("22A", "PatternGetReference");
            _swiftTagToITagMapping.Add("22B", "PatternGetReference");
            _swiftTagToITagMapping.Add("22D", "PatternGetReference");
            _swiftTagToITagMapping.Add("22E", "PatternGetReference");
            _swiftTagToITagMapping.Add("22G", "PatternGetReference");
            _swiftTagToITagMapping.Add("22J", "PatternGetReference");
            _swiftTagToITagMapping.Add("22X", "PatternGetReference");
            _swiftTagToITagMapping.Add("23B", "PatternGetReference");
            _swiftTagToITagMapping.Add("23D", "PatternGetReference");
            _swiftTagToITagMapping.Add("25", "PatternGetReference");
            _swiftTagToITagMapping.Add("26E", "PatternGetReference");
            _swiftTagToITagMapping.Add("26F", "PatternGetReference");
            _swiftTagToITagMapping.Add("26H", "PatternGetReference");
            _swiftTagToITagMapping.Add("26T", "PatternGetReference");
            _swiftTagToITagMapping.Add("29C", "PatternGetReference");
            _swiftTagToITagMapping.Add("29H", "PatternGetReference");
            _swiftTagToITagMapping.Add("30", "PatternGetReference");
            _swiftTagToITagMapping.Add("30F", "PatternGetReference");
            _swiftTagToITagMapping.Add("30H", "PatternGetReference");
            _swiftTagToITagMapping.Add("30P", "PatternGetReference");
            _swiftTagToITagMapping.Add("30Q", "PatternGetReference");
            _swiftTagToITagMapping.Add("30T", "PatternGetReference");
            _swiftTagToITagMapping.Add("30U", "PatternGetReference");
            _swiftTagToITagMapping.Add("30V", "PatternGetReference");
            _swiftTagToITagMapping.Add("30X", "PatternGetReference");
            _swiftTagToITagMapping.Add("31C", "PatternGetReference");
            _swiftTagToITagMapping.Add("31E", "PatternGetReference");
            _swiftTagToITagMapping.Add("31L", "PatternGetReference");
            _swiftTagToITagMapping.Add("31S", "PatternGetReference");
            _swiftTagToITagMapping.Add("32E", "PatternGetReference");
            _swiftTagToITagMapping.Add("32J", "PatternGetReference");
            _swiftTagToITagMapping.Add("35",  "PatternGetReference");
            _swiftTagToITagMapping.Add("35C", "PatternGetReference");
            _swiftTagToITagMapping.Add("35D", "PatternGetReference"); //This is a date
            _swiftTagToITagMapping.Add("36", "PatternGetReference");
            _swiftTagToITagMapping.Add("36A", "PatternGetReference");
            _swiftTagToITagMapping.Add("37J", "PatternGetReference");
            _swiftTagToITagMapping.Add("37L", "PatternGetReference");
            _swiftTagToITagMapping.Add("37P", "PatternGetReference");
            _swiftTagToITagMapping.Add("37U", "PatternGetReference");
            _swiftTagToITagMapping.Add("38A", "PatternGetReference");
            _swiftTagToITagMapping.Add("38D", "PatternGetReference");
            _swiftTagToITagMapping.Add("38E", "PatternGetReference");
            _swiftTagToITagMapping.Add("39B", "PatternGetReference");
            _swiftTagToITagMapping.Add("40A", "PatternGetReference");
            _swiftTagToITagMapping.Add("40F", "PatternGetReference");
            _swiftTagToITagMapping.Add("43P", "PatternGetReference");
            _swiftTagToITagMapping.Add("43T", "PatternGetReference");
            _swiftTagToITagMapping.Add("44A", "PatternGetReference");
            _swiftTagToITagMapping.Add("44B", "PatternGetReference");
            _swiftTagToITagMapping.Add("44C", "PatternGetReference");
            _swiftTagToITagMapping.Add("44E", "PatternGetReference");
            _swiftTagToITagMapping.Add("44F", "PatternGetReference");
            _swiftTagToITagMapping.Add("49", "PatternGetReference");
            _swiftTagToITagMapping.Add("50L", "PatternGetReference");
            _swiftTagToITagMapping.Add("70",  "PatternGetReference");
            _swiftTagToITagMapping.Add("71A", "PatternGetReference");
            _swiftTagToITagMapping.Add("94A", "PatternGetReference");

            #endregion

            #region /<DC>][’/’34x][’CRLF’]<SWIFTBIC>|<NONSWIFTBIC>(*)
            _swiftTagToITagMapping.Add("50A", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("50G", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("50H", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("50K", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("52A", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("52G", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("53A", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("53B", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("53D", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("54A", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("54B", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("54D", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("55A", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("55D", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("56A", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("56D", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("57A", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("57D", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("58A", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("58D", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("59",  "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("59A", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("82A", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("82B", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("82D", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("83A", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("83D", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("84A", "PatternSlashConditionalLines");
            _swiftTagToITagMapping.Add("84D", "PatternSlashConditionalLines");
            #endregion

            #region 6!n3!a15d	(Date) (Currency) (Amount)
            _swiftTagToITagMapping.Add("32A", "PatternYYMMDDCurrencyAmount");
            _swiftTagToITagMapping.Add("32C", "PatternYYMMDDCurrencyAmount");
            _swiftTagToITagMapping.Add("32D", "PatternYYMMDDCurrencyAmount");
            _swiftTagToITagMapping.Add("32P", "PatternYYMMDDCurrencyAmount");
            _swiftTagToITagMapping.Add("33A", "PatternYYMMDDCurrencyAmount");
            _swiftTagToITagMapping.Add("33C", "PatternYYMMDDCurrencyAmount");
            _swiftTagToITagMapping.Add("33D", "PatternYYMMDDCurrencyAmount");
            _swiftTagToITagMapping.Add("33P", "PatternYYMMDDCurrencyAmount");
            _swiftTagToITagMapping.Add("33R", "PatternYYMMDDCurrencyAmount");
            _swiftTagToITagMapping.Add("34A", "PatternYYMMDDCurrencyAmount");
            _swiftTagToITagMapping.Add("34P", "PatternYYMMDDCurrencyAmount");
            _swiftTagToITagMapping.Add("34R", "PatternYYMMDDCurrencyAmount");
            #endregion

            #region :4c//4!c/15d	 (Qualifier) (Type) (Quantity)
            _swiftTagToITagMapping.Add("13K", "PatternDoubleSlashTypeQuantity");
            _swiftTagToITagMapping.Add("36B", "PatternDoubleSlashTypeQuantity");
            _swiftTagToITagMapping.Add("90A", "PatternDoubleSlashTypeQuantity");

            #endregion

            #region :4c/[8c]/4!c[/30x]	(Qualifier) (Issuer Code) (Place) (Narrative)

            _swiftTagToITagMapping.Add("94B", "PatternOptionalCodeWithOptionalNarrative");
            _swiftTagToITagMapping.Add("97B", "PatternOptionalCodeWithOptionalNarrative");
            #endregion

            #region :4c//[N]3!a15d	(Qualifier) (Sign) (Currency) (Amount)
            _swiftTagToITagMapping.Add("19A", "PatternSignCurrencyAmount");
            _swiftTagToITagMapping.Add("19B", "PatternSignCurrencyAmount");
            _swiftTagToITagMapping.Add("32H", "PatternSignCurrencyAmount");
            #endregion

            #region XX/XX (Qualifier) (Value)
            _swiftTagToITagMapping.Add("14G", "PatternSingleSlashSeperator");
            _swiftTagToITagMapping.Add("23A", "PatternSingleSlashSeperator");
            _swiftTagToITagMapping.Add("27", "PatternSingleSlashSeperator");
            _swiftTagToITagMapping.Add("28D", "PatternSingleSlashSeperator");
            _swiftTagToITagMapping.Add("28E", "PatternSingleSlashSeperator");
            _swiftTagToITagMapping.Add("29E", "PatternSingleSlashSeperator"); //Time is the value
            _swiftTagToITagMapping.Add("29K", "PatternSingleSlashSeperator"); //Time is the value
            _swiftTagToITagMapping.Add("30G", "PatternSingleSlashSeperator");
            _swiftTagToITagMapping.Add("32Q", "PatternSingleSlashSeperator");
            _swiftTagToITagMapping.Add("38G", "PatternSingleSlashSeperator");
            _swiftTagToITagMapping.Add("38H", "PatternSingleSlashSeperator");
            _swiftTagToITagMapping.Add("39A", "PatternSingleSlashSeperator");
            #endregion

            #region Sequence Seperator
            _swiftTagToITagMapping.Add("15A", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15B", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15C", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15D", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15E", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15F", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15G", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15H", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15I", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15J", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15K", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15L", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15M", "PatternSequenceSeperator");
            _swiftTagToITagMapping.Add("15N", "PatternSequenceSeperator");
            #endregion

            #region Optional Single Slash Seperator 4!c[/x]
            _swiftTagToITagMapping.Add("22K", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("23C", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("23E", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("23F", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("24D", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("25A", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("26N", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("26P", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("28", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("28C", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("29J", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("31R", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("40C", "PatternOptionalSingleSlashSeperator");
            _swiftTagToITagMapping.Add("40E", "PatternOptionalSingleSlashSeperator");
            #endregion

            #region GetAllLines
            _swiftTagToITagMapping.Add("29A", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("29B", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("29F", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("35E", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("35F", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("35L", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("37N", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("39C", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("40B", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("42C", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("42M", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("42P", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("44D", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("45A", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("45B", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("46A", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("46B", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("47A", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("47B", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("48", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("50", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("73", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("74", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("75", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("76", "PatternGetAllLines");
            _swiftTagToITagMapping.Add("80C", "PatternGetAllLines");

            #endregion

            _swiftTagToITagMapping.Add("32F", "PatternNNNValue");
            _swiftTagToITagMapping.Add("33S", "PatternNNNValue");
            _swiftTagToITagMapping.Add("33T", "PatternNNNValue");
            _swiftTagToITagMapping.Add("35A", "PatternNNNValue");
            _swiftTagToITagMapping.Add("35S", "PatternNNNValue");
            _swiftTagToITagMapping.Add("90B", "PatternAmountTypeCurrencyValue");
            _swiftTagToITagMapping.Add("95R", "PatternCodeWithNarrative");
            _swiftTagToITagMapping.Add("39P", "PatternQualifierSlashCurrencyAmount");
            _swiftTagToITagMapping.Add("51C", "PatternPrecedingSlash");
            _swiftTagToITagMapping.Add("52C", "PatternPrecedingSlash");
            _swiftTagToITagMapping.Add("53C", "PatternPrecedingSlash");
            _swiftTagToITagMapping.Add("56C", "PatternPrecedingSlash");
            _swiftTagToITagMapping.Add("57C", "PatternPrecedingSlash");
            _swiftTagToITagMapping.Add("58C", "PatternPrecedingSlash");
            _swiftTagToITagMapping.Add("83C", "PatternPrecedingSlash");
            _swiftTagToITagMapping.Add("23G", "PatternOptionalSubFunction");



        }
    }
}

