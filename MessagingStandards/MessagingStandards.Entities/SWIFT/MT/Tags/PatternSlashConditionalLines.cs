using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Entities.SWIFT.MT.Tags
{
    public class PatternSlashConditionalLines : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            base.GetTagName(resultText);

            #region ifDebit
            if (resultText.Contains("/D/"))
            {
                this.Code = "D";

                if (resultText.Contains(Environment.NewLine))
                {
                    if (resultText.IndexOf("\n") != resultText.Length)
                    {
                        this.Value = resultText.ToEndOfString("/D/").TrimAllNewLines();
                        return this;
                    }

                    else
                    {
                        this.Value = resultText.ParseFromString("/D", Environment.NewLine).TrimAllNewLines();
                        this.Description = resultText.ToEndOfString(this.Value).TrimAllNewLines();
                        return this;
                    }
                }

                else
                {
                    this.Value = resultText.ToEndOfString("/D/");
                    return this;
                }

            }
            #endregion

            #region ifCredit
            else if (resultText.Contains("/C/"))
            {
                this.Code = "C";

                if (resultText.Contains(Environment.NewLine))
                {
                    if (resultText.IndexOf("\n") != resultText.Length)
                    {
                        this.Value = resultText.ToEndOfString("/C/").TrimAllNewLines();
                        return this;
                    }

                    else
                    {
                        this.Value = resultText.ParseFromString("/C/", Environment.NewLine).TrimAllNewLines();
                        this.Description = resultText.ToEndOfString(this.Value).TrimAllNewLines();
                        return this;
                    }
                }

                else
                {
                    this.Value = resultText.ToEndOfString("/C/");
                    return this;
                }
            }
            #endregion

            #region ifDoubleSlashes
            else if (resultText.Contains("//"))
            {
                if (resultText.IndexOf("\n") != resultText.Length)
                {
                    this.Value = resultText.ToEndOfString("//");
                    return this;
                }
                
                else
                {
                    this.Value = resultText.ParseFromString("//", Environment.NewLine);
                    this.Description = resultText.ToEndOfString(this.Value).TrimAllNewLines();
                    return this;
                }
            }
            #endregion

            else if (resultText.Contains("\n"))
            {
                if (resultText.IndexOf("\n") != resultText.Length)
                {
                    if (resultText.Contains("/"))
                    {
                        this.Value = resultText.Between("/", Environment.NewLine);
                        this.Description = resultText.ToEndOfString(this.Value).TrimAllNewLines();
                        return this;
                    }

                    else
                    {
                        this.Value = resultText.Between(this.TagName + ":", Environment.NewLine);
                        this.Description = resultText.ToEndOfString(this.Value).TrimAllNewLines();
                        return this;
                    }
                }
                else
                {
                    if (resultText.Contains("/"))
                    {
                        this.Value = resultText.Between("/", Environment.NewLine);
                        return this;
                    }

                    else
                    {
                        this.Value = resultText.Between(this.TagName + ":", Environment.NewLine);
                        return this;
                    }

                }
            }

            else
            {
                if (resultText.Contains("/"))
                {
                    this.Value = resultText.ToEndOfString("/");
                    return this;
                }

                else
                {
                    this.Value = resultText.ToEndOfString(this.TagName + ":").Trim();
                    return this;
                }
            }
        }
    }
}

