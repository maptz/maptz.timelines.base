//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace Maptz.Timelines
//{
//    public static class TimelineHelpers
//    {

//        private static string CleanTcString(string tc)
//        {
//            var retval = tc.Replace('.', ':');

//            retval = retval.Split(new char[] { ':', ';' }).Length == 3 ? retval += ":00" : retval;
//            return retval;
//        }


//        public static IEnumerable<ITimelineContentItem> ParseTimelineSpans<T, S>(string content, SmpteFrameRate frameRate) where T : ITimelineContentItem, new()
//            where S : ITimelineContentSpan<T>, new()

//        {

//            if (content == null) return new ITimelineContentItem[0];
//            var retval = new List<ITimelineContentItem>();
//            var lines = content.Split(new string[] { Environment.NewLine, "\n", "\r" }, StringSplitOptions.None);
//            ITimelineContentItem currentItem = null;

//            for (int i = 0; i < lines.Length; i++)
//            {

//                var line = lines[i];
//                var lineTrim = line.Trim();
//                var tcMatchPattern = "^[0-9]+[\\:\\.\\;][0-9]+[\\:\\.\\;][0-9]+([\\:\\.\\;][0-9]+)*";
//                var regexMatch = Regex.Match(lineTrim, tcMatchPattern);
//                if (regexMatch.Success)
//                {

//                    var startStr = CleanTcString(lineTrim.Substring(0, regexMatch.Length));

//                    ITimeCode startTC;
//                    try
//                    {
//                        startTC = new TimeCode(startStr, frameRate);
//                    }
//                    catch (Exception)
//                    {
//                        //Skip over an exception parsing a line
//                        continue;
//                    }

//                    var remainder = lineTrim.Length > regexMatch.Length ? lineTrim.Substring(regexMatch.Length).Trim() : string.Empty;
//                    var remainderIsTCMatch = Regex.Match(remainder, tcMatchPattern);
//                    if (remainderIsTCMatch.Success)
//                    {
//                        var endStr = CleanTcString(remainder.Substring(0, remainderIsTCMatch.Length));

//                        ITimeCode endTC;
//                        try
//                        {
//                            endTC = new TimeCode(endStr, frameRate);
//                        }
//                        catch (Exception)
//                        {
//                            //Skip over an exception parsing a line
//                            continue;
//                        }

//                        if (currentItem != null) { retval.Add(currentItem); }

//                        var s = new S();
//                        s.Start = startTC;
//                        s.End = endTC;
//                        currentItem = s;


//                    }
//                    else
//                    {
//                        if (currentItem != null) { retval.Add(currentItem); }
//                        currentItem = new T();
//                        currentItem.Start = startTC;
//                    }

//                }
//                else
//                {
//                    if (currentItem == null) { continue; }
//                    if (!string.IsNullOrEmpty(currentItem.Content))
//                    { currentItem.Content += Environment.NewLine; }
//                    currentItem.Content += line;
//                }
//            }

//            if (currentItem != null && currentItem.Content != null && currentItem.Start != null)
//            {
//                retval.Add(currentItem);
//            }
//            return retval;
//        }
//    }
//}
