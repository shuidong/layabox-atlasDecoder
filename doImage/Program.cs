using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace doImage
{
    class Program
    {
        static void CaptureImage(string fromImagePath, string toImagePath, int offsetX, int offsetY, int width, int height)
        {
            using (var srcImage = new Bitmap(fromImagePath))
            using (var desImage = new Bitmap(width, height, srcImage.PixelFormat))
            using (var g = Graphics.FromImage(desImage))
            {
                var srcRect = new Rectangle(offsetX, offsetY, width, height);
                var desRect = new Rectangle(0, 0, desImage.Width, desImage.Height);

                g.DrawImage(srcImage, desRect, srcRect, GraphicsUnit.Pixel);
                desImage.Save(toImagePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Write("exec with two parameters, like: doImage atlas srcPng [destPath]");
                return;
            }

            string atlas = args[0];
            string srcPng = args[1];
            string destPath = @"./";
            if (args.Length == 3)
            {
                destPath = args[2];
            }
            
            if(false){
                atlas = @"D:\_git\3dJumpBall\hack\res\atlas\skin.atlas.json";
                srcPng = @"D:\_git\3dJumpBall\hack\res\atlas\skin.png";
            }
            

            string text = System.IO.File.ReadAllText(atlas);

            List<pngInfo> pngInfos = JsonInfoGetter.handleLayaJson(text);
            foreach (pngInfo tmp in pngInfos)
            {
                CaptureImage(srcPng, destPath + "/" + tmp.png, tmp.offx, tmp.offy, tmp.w, tmp.h);
            }

            //System.IO.File.WriteAllText(originJson, resultJson);

        }
    }
}
