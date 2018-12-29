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
        public TMap(string inp_Scene, string inp_Video, int inp_startPos, int inp_maxPos)
        {
            subtitles = new Dictionary<int, string>();
            sceneName = inp_Scene;
            videoName = inp_Video;
            startPos = inp_startPos;
            maxPos = inp_maxPos;
        }

        //Key is the subtitle's starting time in seconds
        public Dictionary<int, string> subtitles;
        public string sceneName;
        public string videoName;
        //Starting point for playable part
        public int startPos = 0;
        //Duration of a playable part of the video "VideoName" in seconds
        public int maxPos;

        public List<string> GetEditorList()
        {
            List<string> res = new List<string>();
            for(int i = 0; i < maxPos; i++)
            {
                if (subtitles.ContainsKey(i) == true)
                {
                    res.Add("[" + i + "] " + subtitles[i]);
                }
            }
            return res;
        }
    }
}
