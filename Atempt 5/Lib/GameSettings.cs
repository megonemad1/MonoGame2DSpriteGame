using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Atempt_5
{
    [Serializable]
    public class GameSettings
    {
        public static string ContentPath = "Content";
        public static Point VirtualResilution = new Point(1024, 768);
        public static Point CurrentResolution = new Point(1080, 720);
        public static bool IsFullscreen;
        public static void SetInstanceToStatic(GameSettings G)
        {
                    GameSettings.ContentPath = G._contentPath;
                    GameSettings.IsFullscreen = G._isFullscreen;
                    GameSettings.VirtualResilution = G._virtualResilution;
        }
        public static Vector3 ResolutionRescale { get { return new Vector3((float)CurrentResolution.X / (float)VirtualResilution.X, (float)CurrentResolution.Y / (float)VirtualResilution.Y, 1f); } }
       
        public string _contentPath;
        public Point _virtualResilution;
        public bool _isFullscreen;
        
    }
}
