using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    class MapsDB : IMapStorage
    {
        [Table("ORA_Table_Map")]
        public class MapRepresentation
        {
            public MapRepresentation() { }

            public MapRepresentation(IMap map)
            {
                Name = map.Name;
                VideoURL = map.VideoURL;
                startPos = map.startPos;
                finishPos = map.finishPos;
                subtitles = new List<Subtitle>();
                foreach(var keyValuePair in map.dict)
                {
                    subtitles.Add(new Subtitle(keyValuePair.Key, keyValuePair.Value));
                }
            }
            
            [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
            public string Name { get; set; }
            public string VideoURL { get; set; }
            public int startPos { get; set; }
            public int finishPos { get; set; }

            public virtual ICollection<Subtitle> subtitles { get; set; }
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

            public MapRepresentation map { get; set; }
            public int MapID { get; set; }
        }

        private Map getMap(MapRepresentation dbMap)
        {
            Map map = new Map(dbMap.Name, dbMap.VideoURL, dbMap.startPos, dbMap.finishPos);
            foreach (var s in dbMap.subtitles)
            {
                map.AddSubtitle(s.pos, s.text);
            }
            return map;
        }

        public List<Map> GetListOfMaps()
        {
            List<Map> res = new List<Map>();
            using (var db = new TMapContext())
            {
                var maps = db.Maps.Include(s => s.subtitles);
                foreach(var map in maps)
                {
                    res.Add(getMap(map));
                }
            }
            return res;
        }

        public Map Load(string inp)
        {
            try
            {
                using (var db = new TMapContext())
                {
                    var maps = db.Maps.Include(s => s.subtitles).ToList();
                    var mapRepresentation = maps.Where(o => o.Name == inp).FirstOrDefault();
                    var map = getMap(mapRepresentation);
                    return map;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public bool Delete(string inp)
        {
            try
            {
                using (var db = new TMapContext())
                {
                    db.Maps.Remove(db.Maps.Where(o => o.Name == inp).FirstOrDefault());
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(IMap inp_map)
        {
            try
            {
                using (var db = new TMapContext())
                {
                    var mapRepresentation = new MapRepresentation(inp_map);
                    db.Maps.Add(mapRepresentation);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
