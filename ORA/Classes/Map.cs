using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA
{
    public class Map : IMap
    {
        public Map() { }

        public Map(string inp_Name, string inp_videoURL, int pos1, int pos2)
        {
            Name = inp_Name;
            VideoURL = inp_videoURL;
            startPos = pos1;
            finishPos = pos2;
            dict = new Dictionary<int, string>();
        }

        public Dictionary<int, string> dict { get; set; }
        public string Name { get; set; }
        public string VideoURL { get; set; }
        public int startPos { get; set; }
        public int finishPos { get; set; }

        public IMap AddSubtitle(int inp_pos, string inp_text)
        {
            this.dict.Add(inp_pos, inp_text);
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name + " (" + VideoURL + " : [" + startPos + "-" + finishPos + "])");
            foreach(var keyValuePair in dict)
            {
                sb.AppendLine("   " + keyValuePair.Key + " : " + keyValuePair.Value);
            }
            return sb.ToString();
        }
    }
}
