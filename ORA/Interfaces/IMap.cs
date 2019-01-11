using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA
{
    public interface IMap
    {
        Dictionary<int, string> dict { get; set; }
        string Name { get; set; }
        string VideoURL { get; set; }
        int startPos { get; set; }
        int finishPos { get; set; }

        IMap AddSubtitle(int pos, string text);
    }
}