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
            Letter.Init(Color.Green, Color.Black, new Font("Splash", 24, FontStyle.Bold), 20);
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
                letters[i].SetValue(' ',UserSettings.Instance.gameMode.IgnoreUpperCase);
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
        public bool FinishedLine
        {
            get
            {
                return (curSelected == maxPosition);
            }
        }

        public char CurrentlySelected
        {
            get
            {
                return letters[curSelected].value;
            }
        }

        public void SetText(string inp)
        {
            curSelected = -1;
            for(int i = inp.Length - 1; i >= 0; i--)
            {
                letters[i].SetValue(inp[i], UserSettings.Instance.gameMode.IgnoreUpperCase);
                letters[i].Visible = true;
            }
            for(int i = inp.Length; i < Length; i++)
            {
                letters[i].Visible = false;
            }
            maxPosition = inp.Length;
            MoveToNextAvailableSymbol();
        }

        public int MoveToNextAvailableSymbol()
        {
            if (curSelected < maxPosition)
            {
                MoveToNextSymbol();
                while (
                    (curSelected < maxPosition) &&
                    (IsAllowed(letters[curSelected].value) == false)
                    )
                {
                    MoveToNextSymbol();
                }
            }
            return curSelected;
        }

        private void MoveToNextSymbol()
        {
            if (curSelected != -1)
                letters[curSelected].Activate();
            curSelected++;
        }

        public bool IsAllowed(char symb)
        {
            if (UserSettings.Instance.gameMode.IgnoreSpaces == true)
                if (symb == ' ')
                    return false;
            if (UserSettings.Instance.gameMode.IgnoreSpecialSymbols == true)
            {
                if (((('a' <= symb) && (symb <= 'z')) ||
                    (('A' <= symb) && (symb <= 'Z')) ||
                    (symb == ' ')) == false)
                    return false;
            }
            return true;
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
