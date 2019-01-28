using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA
{
    public class GameMode
    {
        public GameMode()
        {
            PauseBeforeText = true;
            IgnoreSpecialSymbols = true;
            IgnoreUpperCase = true;
            IgnoreSpaces = false;
        }

        public GameMode(bool inp_PauseBeforeText, bool inp_IgnoreSpecialSymbols, bool inp_IgnoreUpperCase, bool inp_IgnoreSpaces)
        {
            PauseBeforeText = inp_PauseBeforeText;
            IgnoreSpecialSymbols = inp_IgnoreSpecialSymbols;
            IgnoreUpperCase = inp_IgnoreUpperCase;
            IgnoreSpaces = inp_IgnoreSpaces;
        }

        public bool this[int i]
        {
            get
            {
                switch(i)
                {
                    case 0: return PauseBeforeText;
                    case 1: return IgnoreSpecialSymbols;
                    case 2: return IgnoreUpperCase;
                    case 3: return IgnoreSpaces;
                }
                return false;
            }
            set
            {
                switch (i)
                {
                    case 0: PauseBeforeText = value; break;
                    case 1: IgnoreSpecialSymbols = value; break;
                    case 2: IgnoreUpperCase = value; break;
                    case 3: IgnoreSpaces = value; break;
                }
            }
        }

        public bool PauseBeforeText;
        public bool IgnoreSpecialSymbols;
        public bool IgnoreUpperCase;
        public bool IgnoreSpaces;
    }
}
