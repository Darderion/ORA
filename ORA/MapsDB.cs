using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    class MapsDB
    {
        public static Map Load(string inp)
        {
            Map loaded_map = new Map();
            try
            {
                using (var db = new TMapContext())
                {
                    var maps = db.Maps.ToList();
                    loaded_map = maps.Where(o => o.Name == inp).FirstOrDefault();
                    if (loaded_map != null)
                    {
                        loaded_map.dict = new Dictionary<int, string>();
                        foreach (var line in loaded_map.subtitles)
                        {
                            loaded_map.dict.Add(line.pos, line.text);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return loaded_map;
        }

        public static bool Delete(string inp)
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
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public static bool Save(Map map)
        {
            try
            {
                using (var db = new TMapContext())
                {
                    map.subtitles.Clear();
                    foreach (var line in map.dict)
                    {
                        map.subtitles.Add(new Subtitle(line.Key, line.Value));
                    }
                    db.Maps.Add(map);
                    db.SaveChanges();
                    MessageBox.Show("Saved successfully");
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
    }
}
