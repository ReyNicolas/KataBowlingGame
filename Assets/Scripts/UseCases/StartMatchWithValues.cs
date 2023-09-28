using System.Collections.Generic;
using Entities;

namespace UseCases
{
    public class StartMatchWithValues
    {
        public Match Create(int numberOfFrames, int numberOfPinsToHitDownPerFrame, int numberOfShotsPerFrame)
        {
            List<Frame> frames = new List<Frame>();
            for (int i = 0; i < numberOfFrames; i++)
            {
                frames.Add(new Frame(numberOfPinsToHitDownPerFrame, numberOfShotsPerFrame));
            }
            return new Match(frames);
        }
    }
}


