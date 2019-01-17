using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    class MenuService
    {
        private struct ThumbnailSize
        {
            public ThumbnailSize(int w, int h)
            {
                width = w;
                height = h;
            }

            public int width;
            public int height;
        }

        public static void SetMenuMaps(ref MenuMap[,] maps, Control ctrl)
        {
            int max_x = maps.GetLength(0);
            int max_y = maps.GetLength(1);
            for(int x = 0; x < max_x; x++)
            {
                for(int y = 0; y < max_y; y++)
                {
                    maps[x, y] = new MenuMap(ctrl);
                    SetMenuMap(ref maps[x, y], CL.LockedMap, max_x, max_y, x, y);
                }
            }
        }

        public static bool SetMenuMap(ref MenuMap menuMap, string inp, int horizontalAmount, int verticalAmount, int x, int y)
        {
            return SetMenuMap(ref menuMap, inp,
                horizontalAmount, verticalAmount,
                x, y, 10, 50);
        }

        public static bool SetMenuMap(ref MenuMap menuMap, string inp, int horizontalAmount, int verticalAmount, int x, int y, int horizontalIndent, int verticalIndent)
        {
            Image img = getThumbnail(inp);
            if (img == null) return false;
            menuMap.label.Text = inp;
            menuMap.pic.Image = img;
            ThumbnailSize size = getThumbnailSize(
                menuMap.pic.Parent.Width, menuMap.pic.Parent.Height,
                horizontalAmount, verticalAmount,
                horizontalIndent, verticalIndent);
            menuMap.pic.Width = size.width;
            menuMap.pic.Height = size.height;

            menuMap.pic.Left = horizontalIndent * (x + 1) + size.width * x;
            menuMap.pic.Top = verticalIndent * (y + 1) + size.height * y;

            menuMap.label.Left = menuMap.pic.Left;
            menuMap.label.Top = menuMap.pic.Top + menuMap.pic.Height;
            menuMap.label.Width = menuMap.pic.Width;
            menuMap.label.Height = verticalIndent;
            menuMap.label.Text = getLabelText("Locked",
                menuMap.label.Font, menuMap.label.Width, menuMap.label.Height,TextRenderer.MeasureText("...",menuMap.label.Font).Width);
            return true;
        }

        private static string getLabelText(string text, Font font, int width, int height, int addedWidth)
        {
            return getLabelText(true, text, font, width, height, addedWidth);
        }

        private static string getLabelText(bool isFirstCall, string text, Font font, int width, int height, int addedWidth)
        {
            Size size = TextRenderer.MeasureText(text, font);
            if (size.Width > width * (height / size.Height))
            {
                return getLabelText(false, text.Remove(text.Length - 1), font, width, height, addedWidth);
            }
            if (isFirstCall == true)
                return text;
            return text + "...";
        }

        public static Image getThumbnail(string inp)
        {
            Image img = null;
            if (inp.Contains(CL.ThumbnailFolder) == false)
                inp = CL.ThumbnailFolder + inp;
            inp = inp + ".png";
            if (File.Exists(inp))
            {
                img = Image.FromFile(inp);
            }
            return img;
        }

        private static ThumbnailSize getThumbnailSize(int width, int height, int horizontalAmount, int verticalAmount, int horizontalIndent, int verticalIndent)
        {
            width -= horizontalIndent * (horizontalAmount + 1);
            height -= verticalIndent * (verticalAmount + 1);
            return new ThumbnailSize(width / horizontalAmount, height / verticalAmount);
        }
    }
}
