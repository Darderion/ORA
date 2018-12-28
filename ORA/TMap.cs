using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA
{
    /// <summary>
    /// This class consists of subtitles along with some info regarding video
    /// </summary>
    class TMap
    {
        public TMap(string inp_Scene, string inp_Video, int inp_Pos)
        {
            subtitles = new Dictionary<int, string>();
            sceneName = inp_Scene;
            videoName = inp_Video;
            maxPos = inp_Pos;
        }

        //Key is the subtitle's starting time in seconds
        public Dictionary<int, string> subtitles;
        public string sceneName;
        public string videoName;
        //Duration of a playable part of the video "VideoName" in seconds
        public int maxPos;

        public List<string> GetEditorList()
        {
            List<string> res = new List<string>();
            foreach(var s in subtitles)
            {
                res.Add("["+s.Key+"] "+s.Value);
            }
            return res;
        }
    }
}
