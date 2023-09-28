using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Views
{
    public class FrameScorerView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI[] scorersText;

        public void SetScoreWithIndex(int index, int score)
        {
            if(score == 10)
            {
                scorersText[index].text = "X";
                return;
            }
            scorersText[index].text = score.ToString();
        }

        internal void SetScoreLast(int score)
        {
            scorersText.Last().text = score.ToString();
        }
    }
}

