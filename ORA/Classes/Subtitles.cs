using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    class Subtitles
    {
        public Subtitles()
        {
            letters = new List<Letter>();
            Letter.Init(Color.Green, Color.Black, new Font("Splash", 24), 20);
            dividerWidth = -5;
            dividerHeight = 5;

            lineLength = 22;
            numberOfLines = 3;

            startX = 20;
            startY = 870;

            for (int i = 0; i < Length; i++)
            {
                letters.Add(new Letter());
                letters[i].SetPosition(
                    startX + (letters[i].Width + dividerWidth) * (i % lineLength),
                    startY + (letters[i].Height + dividerHeight) * (i / lineLength));
                //letters[i].SetValue(Char.ConvertFromUtf32(i)[0]);
                letters[i].SetValue(' ');
            }
            curSelected = 0;
            maxPosition = 0;
        }

        int curSelected;
        int maxPosition;
        int lineLength;
        int numberOfLines;

        int startX;
        int startY;

        public int Length
        {
            get
            {
                return lineLength * numberOfLines;
            }
        }

        public List<Letter> letters;
        public int dividerWidth;
        public int dividerHeight;

        public char CurrentlySelected
        {
            get
            {
                return letters[curSelected].value;
            }
        }

        public void SetText(string inp)
        {
            for(int i = 0; i < inp.Length; i++)
            {
                letters[i].SetValue(inp[i]);
                letters[i].Visible = true;
            }
            for(int i = inp.Length; i < Length; i++)
            {
                letters[i].Visible = false;
            }
            curSelected = 0;
            maxPosition = inp.Length;
        }

        public void MoveToNextSymbol()
        {
            if (curSelected == maxPosition)
                return;
            letters[curSelected].Activate();
            curSelected++;
        }

        public void SetParents(Control control)
        {
            foreach(var letter in letters)
            {
                letter.Parent = control;
            }
        }
    }
}
