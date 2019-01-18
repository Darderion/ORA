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
                    if (maps[x, y] == null)
                    {
                        maps[x, y] = new MenuMap(ctrl);
                    }
                    SetMenuMap(ref maps[x, y], CL.LockedMap, max_x, max_y, x, y);
                }
            }
        }

        public static bool SetMenuMap(ref MenuMap menuMap, string mapName, int horizontalAmount, int verticalAmount, int x, int y)
        {
            return SetMenuMap(ref menuMap, mapName,
                horizontalAmount, verticalAmount,
                x, y, 10, 50);
        }

        public static bool SetMenuMap(ref MenuMap menuMap, string mapName, int horizontalAmount, int verticalAmount, int x, int y, int horizontalIndent, int verticalIndent)
        {
            Image img = getThumbnail(mapName);
            if (img == null) return false;
            menuMap.label.Text = mapName;
            menuMap.pic.Image = img;
            ThumbnailSize size = getThumbnailSize(
                menuMap.pic.Parent.Width, menuMap.pic.Parent.Height,
                horizontalAmount, verticalAmount,
                horizontalIndent, verticalIndent);
            menuMap.pic.Width = size.width;
            menuMap.pic.Height = size.height;

            menuMap.mapName = CL.NoMap;

            menuMap.pic.Left = horizontalIndent * (x + 1) + size.width * x;
            menuMap.pic.Top = verticalIndent * (y + 1) + size.height * y;

            menuMap.label.Left = menuMap.pic.Left;
            menuMap.label.Top = menuMap.pic.Top + menuMap.pic.Height;
            menuMap.label.Width = menuMap.pic.Width;
            menuMap.label.Height = verticalIndent;
            menuMap.label.Text = getLabelText(CL.NoMap,
                menuMap.label.Font, menuMap.label.Width, menuMap.label.Height,
                TextRenderer.MeasureText("...",menuMap.label.Font).Width);
            return true;
        }

        public static void UpdateMapsPage(IMapStorage storage, ref MenuMap[,] menuMaps, int inp)
        {
            int width = menuMaps.GetLength(0);
            int size = menuMaps.Length;
            List<Map> maps = storage.GetListOfMaps();
            int tailCount = maps.Count - size * inp;
            if (tailCount > 0)
            {
                maps = maps.GetRange(size * inp, Math.Min(size, tailCount));
            }
            int x = 0;
            int y = 0;
            int max = Math.Min(size, maps.Count);
            for (int i = 0; i < max; i++)
            {
                y = i / width;
                x = i % width;
                menuMaps[x, y].mapName = maps[i].Name;
                menuMaps[x, y].pic.Image = getThumbnail(maps[i].Name);
                menuMaps[x, y].label.Text = setLabelText(menuMaps[x, y]);
            }
            UpdateVisibility(ref menuMaps);
        }

        public static void UpdateVisibility(ref MenuMap[,] menuMaps)
        {
            foreach(var map in menuMaps)
            {
                if (map.mapName == CL.NoMap)
                    map.Visible = false;
                else
                    map.Visible = true;
            }
        }

        private static string setLabelText(MenuMap menuMap)
        {
            return getLabelText(menuMap.mapName,
                menuMap.label.Font, menuMap.label.Width, menuMap.label.Height,
                TextRenderer.MeasureText("...", menuMap.label.Font).Width);
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
