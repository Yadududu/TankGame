using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace complete {
    public class HeadUI : MonoBehaviour {

        public GameData gameData;
        public Text ScoreText;
        public GameObject HealthUI;

        // private int ScoreValue = 0;

        public void AddScore(){
            gameData.CurrentScore++;
            ScoreText.text = gameData.CurrentScore.ToString();
            
        }
        public void BrushScore() {
            gameData.CurrentScore = 0;
            ScoreText.text = "0";
        }
        void ShowHealthUI() {
            HealthUI.SetActive(true);
        }
        void HideHealthUI() {
            HealthUI.SetActive(false);
        }
        public void SetHealthUIValue(float Healthvalue) {
            if (Healthvalue == 0) {
                HideHealthUI();
            } else {
                ShowHealthUI();
                HealthUI.GetComponent<Slider>().value = Healthvalue;
            }
        }
        public void SetHealthUIMaxValue(float Healthvalue) {
            if (Healthvalue != 0) {
                HealthUI.GetComponent<Slider>().maxValue = Healthvalue;
            } else {

                
            }
        }
    }
}

