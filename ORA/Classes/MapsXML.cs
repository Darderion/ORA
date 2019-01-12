﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ORA
{
    public class MapsXML : IMapStorage
    {
        private const string Folder = "Maps/";
        private const string Extension = ".ORA";

        [Serializable]
        public class MapRepresentation
        {
            public MapRepresentation() { }

            [Serializable]
            public struct xmlSubtitle
            {
                public xmlSubtitle(int inp_pos, string inp_text)
                {
                    pos = inp_pos;
                    text = inp_text;
                }

                public int pos;
                public string text;
            }

            public MapRepresentation(IMap map)
            {
                Name = map.Name;
                VideoURL = map.VideoURL;
                startPos = map.startPos;
                finishPos = map.finishPos;

                var subs = new List<xmlSubtitle>();
                foreach(var keyValuePair in map.dict)
                {
                    subs.Add(new xmlSubtitle(keyValuePair.Key, keyValuePair.Value));
                }
                subtitles = subs.ToArray();
            }

            public int ID;
            public string Name;
            public string VideoURL;
            public int startPos;
            public int finishPos;

            public xmlSubtitle[] subtitles;
        }
        
        private Map getMap(MapRepresentation xmlMap)
        {
            Map map = new Map(xmlMap.Name, xmlMap.VideoURL, xmlMap.startPos, xmlMap.finishPos);
            foreach(var s in xmlMap.subtitles)
            {
                map.AddSubtitle(s.pos, s.text);
            }
            return map;
        }

        private string getCorrectFilePath(string inp)
        {
            if (Path.GetExtension(inp) != Extension)
            {
                inp = inp + Extension;
            }
            if (inp.Contains(Folder) == false)
            {
                inp = Folder + inp;
            }
            return inp;
        }

        public bool Delete(string inp)
        {
            inp = getCorrectFilePath(inp);
            try
            {
                File.Delete(inp);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Map Load(string inp)
        {
            inp = getCorrectFilePath(inp);
            Map map;
            try
            {
                using (var sr = new StreamReader(inp))
                {
                    var xm = new XmlSerializer(typeof(MapRepresentation));
                    map = getMap((MapRepresentation)xm.Deserialize(sr));
                    return map;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public bool Save(IMap map)
        {
            try
            {
                Directory.CreateDirectory(Folder);
                using (var sw = new StreamWriter(Folder + map.Name + Extension))
                {
                    var xm = new XmlSerializer(typeof(MapRepresentation));
                    xm.Serialize(sw, new MapRepresentation(map));
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public void Reset()
        {
            string[] files = Directory.GetFiles(Folder);
            foreach (string fileName in files)
            {
                if (Path.GetExtension(fileName) == Extension)
                {
                    File.Delete(fileName);
                }
            }
        }

        public List<Map> GetListOfMaps()
        {
            List<Map> res = new List<Map>();
            string[] files = Directory.GetFiles(Folder);
            foreach(string fileName in files)
            {
                if (Path.GetExtension(fileName) == Extension)
                {
                    res.Add(Load(fileName));
                }
            }
            return res;
        }
    }
}
