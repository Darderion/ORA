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
            IgnoreSpaces = false;
            IgnoreUpperCase = true;
        }

        public GameMode(bool inp_PauseBeforeText, bool inp_IgnoreSpecialSymbols, bool inp_IgnoreUpperCase, bool inp_IgnoreSpaces)
        {
            PauseBeforeText = inp_PauseBeforeText;
            IgnoreSpecialSymbols = inp_IgnoreSpecialSymbols;
            IgnoreUpperCase = inp_IgnoreUpperCase;
            IgnoreSpaces = inp_IgnoreSpaces;
        }

        public bool PauseBeforeText;
        public bool IgnoreSpecialSymbols;
        public bool IgnoreUpperCase;
        public bool IgnoreSpaces;
    }
}
