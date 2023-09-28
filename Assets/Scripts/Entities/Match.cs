using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Entities
{
    public class Match
    {
        public List<Frame> Frames { get; }

        int currentFrameIndex;
        public int CurrentFrameIndex { get { return currentFrameIndex; } }

        public Match(List<Frame> frames)
        {
            Frames = frames;
            currentFrameIndex = 0;
        }

        public Frame CurrentFrame()
        {
            return Frames[currentFrameIndex];
        }

        public void MoveToNextFrame()
        {
            if (currentFrameIndex < Frames.Count - 1) currentFrameIndex = currentFrameIndex + 1;
        }

        public bool IsLastFrame()
        {
            return currentFrameIndex == Frames.Count - 1;
        }
        public List<int> GetTheNextNumberOfRollsAfterThisFrame(int number, Frame frame)
        {
            return GetTheRollsAfterThisFrame(frame).Take(number).ToList();
        }

        private List<int> GetTheRollsAfterThisFrame(Frame frame)
        {
            return GetTheFramesAfterThisFrame(frame).Aggregate(new List<int>(), (AccList, actualFrame) => AccList.Concat(actualFrame.Rolls).ToList());
        }

        private List<Frame> GetTheFramesAfterThisFrame(Frame frame)
        {
            return Frames.TakeLast(Frames.Count - (Frames.IndexOf(frame) + 1)).ToList();
        }
    }
}


