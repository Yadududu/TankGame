using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace LMJ {
    public class ScoreSystem : MonoBehaviour {
        public static ScoreSystem Get { get; private set; }

        public Text txtScore;
        public Text txtTotalScore;
        public UnityEvent onTotalScoreChange;

        public int score { get; private set; }
        public int totalScore { get; private set; }

        ScoreSystem() {
            Get = this;
        }
        private void Awake() {
            onTotalScoreChange.AddListener(display);
        }
        public void Init() {
            score = 0;
            txtScore.text = "0";
        }
        public void Gain() {
            score += 1;
            txtScore.text = score.ToString();
        }
        public void Sub(int num) {
            totalScore = totalScore - num;
            onTotalScoreChange.Invoke();
        }
        public void Add(int num) {
            totalScore = totalScore + num;
            onTotalScoreChange.Invoke();
        }
        //public int GetScore() {
        //    return _totalScore;
        //}
        private void display() {
            txtTotalScore.text = totalScore.ToString();
        }
    }
}

