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

			curSelected = 0;
            maxPosition = 0;
        }

        int curSelected;
        int maxPosition;
        int lineLength;
        int numberOfLines;

        int startX;
        int startY;

		static Control defaultControl;

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

		public int GetHorizontalNumber(int width, int divider, Font font, int n)
		{
			if ((TextRenderer.MeasureText("S", font).Width + divider) * (n + 1) < width)
				return GetHorizontalNumber(width, divider, font, n + 1);
			return n;
		}

		public int GetVerticalNumber(int height, int divider, Font font, int n)
		{
			if ((TextRenderer.MeasureText("S", font).Height + divider) * (n + 1) < height)
				return GetHorizontalNumber(height, divider, font, n + 1);
			return n;
		}

		public void SetPosition(int x, int y, int width, int height)
		{
			letters.Clear();
			dividerWidth = -5;
			dividerHeight = 5;

			lineLength = GetHorizontalNumber(width, 5, Letter.defaultFont, 0); //22
			numberOfLines = GetVerticalNumber(height, dividerHeight, Letter.defaultFont, 0); //3

			startX = x; //20
			startY = y; //870

			for (int i = 0; i < Length; i++)
			{
				letters.Add(new Letter());
				letters[i].SetPosition(
					startX + (letters[i].Width + dividerWidth) * (i % lineLength),
					startY + (letters[i].Height + dividerHeight) * (i / lineLength));
				letters[i].Parent = defaultControl;
				letters[i].SetValue(' ', UserSettings.Instance.gameMode.IgnoreUpperCase);
			}
		}

        public void SetText(string inp)
        {
			//Handle inp.Length > max
			if (inp.Length > Length)
				inp = inp.Remove(Length);

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

        public void SetParent(Control control)
        {
			defaultControl = control;
        }
    }
}
