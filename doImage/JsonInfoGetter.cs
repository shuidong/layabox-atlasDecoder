using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codeplex.Data;

namespace doImage
{
    class JsonInfoGetter
    {
        public static List<pngInfo> handleLayaJson(string jsonContent)
        {
            var json = DynamicJson.Parse(jsonContent);
            var frames = json["frames"];

            //int i = 0;
            var ret = new List<pngInfo>();
            foreach (KeyValuePair<string, dynamic> item in frames)
            {
                dynamic imgData = item.Value;

                var png = item.Key;
                var offx = imgData["frame"]["x"];
                var offy = imgData["frame"]["y"];
                var w = imgData["frame"]["w"];
                var h = imgData["frame"]["h"];

                var  ttmp = new pngInfo();
                ttmp.png = png;
                ttmp.offx = (int)offx;
                ttmp.offy = (int)offy;
                ttmp.w = (int)w;
                ttmp.h = (int)h;

                ret.Add(ttmp);

                
            }

            return ret;
        }

        
    }
}
