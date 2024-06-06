using System;
using System.Collections.Generic;
using System.Linq;

namespace org.ReStudios.utitlitium
{
    public class FPSCalculator
    {
        private int fps = 0;
        private readonly List<float> history = new List<float>();
        private long lastTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        private int frames = 0;

        public int CurrentFPS()
        {
            return fps;
        }

        public int AverageFPS()
        {
            if (history.Count == 0)
            {
                return 0;
            }
            else
            {
                return (int)Math.Round(history.Average());
            }
        }


        public void UpdateFPS()
        {
            long currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            frames++;
            if (currentTime - lastTime >= 50)
            {
                float framesPerSecond = (float)(frames / ((currentTime - lastTime) / 1000.0));
                history.Add(framesPerSecond);
                if (history.Count > 5)
                {
                    history.RemoveAt(0);
                }
                fps = (int)framesPerSecond;
                frames = 0;
                lastTime = currentTime;
            }
        }
    }
}
