using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA
{
    [Table("ORA_Table_Map")]
    public class Map
    {
        public Map()
        {
        }

        public Map(string inp_Name, string inp_videoURL, int pos1, int pos2)
        {
            Name = inp_Name;
            VideoURL = inp_videoURL;
            startPos = pos1;
            finishPos = pos2;
            subtitles = new HashSet<Subtitle>();
            dict = new Dictionary<int, string>();
        }

        [NotMapped]
        public Dictionary<int, string> dict;
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string VideoURL { get; set; }
        public int startPos { get; set; }
        public int finishPos { get; set; }

        public virtual ICollection<Subtitle> subtitles { get; set; }

        public Map AddSubtitle(int inp_pos, string inp_text)
        {
            this.subtitles.Add(new Subtitle(inp_pos, inp_text));
            return this;
        }
    }

    [Table("ORA_Table_Subtitle")]
    public class Subtitle
    {
        public Subtitle(int inp_pos, string inp_text)
        {
            pos = inp_pos;
            text = inp_text;
        }

        public Subtitle() { }

        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int pos { get; set; }
        public string text { get; set; }

        public Map map { get; set; }
        public int MapID { get; set; }
    }
}
