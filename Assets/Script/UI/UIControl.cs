using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace complete {
    public class UIControl : MonoBehaviour {

        [Header("Data")]
        public GameData GameData;

        [Header("GameObject")]
        public GameObject MenuUI;
        public GameObject SettingUI;
        public GameObject GameOverUI;
        public GameObject WarningUI;
        public GameObject InputTextUI;
        public GameObject[] HeadUIImage;

        [Header("Scripts")]
        public Store StoreUI;
        public HeadUI HeadUI;

        [Header("Button")]
        public Button TankBtn;
        public Button TurretBtn;
        public Button PlaneBtn;
        

        // Use this for initialization
        void Start() {
            StoreUI.GameData = GameData;
        }

        // Update is called once per frame
        void Update() {
            
        }

        public void ShowMenuUI(){
            MenuUI.SetActive(true);
            GameSystem.m_GameControl.GetComponent<GameControl>().PlayingGameSign = false;
        }
        public void HideMenuUI() {
            MenuUI.SetActive(false);
        }

        public void ShowSettingUI() {
            SettingUI.SetActive(true);
        }
        public void HideSettingUI() {
            SettingUI.SetActive(false);
        }

        public void ShowGameOverUI() {
            GameOverUI.SetActive(true);
            GameSystem.m_GameControl.GetComponent<GameControl>().PlayingGameSign = false;
        }
        public void HideGameOverUI() {
            GameOverUI.SetActive(false);
        }

        public void ShowWarningUI() {
            WarningUI.SetActive(true);
            GameSystem.m_GameControl.GetComponent<GameControl>().PlayingGameSign = false;
        }
        public void HideWarningUI() {
            WarningUI.SetActive(false);
            GameSystem.m_GameControl.GetComponent<GameControl>().PlayingGameSign = true;
        }

        public void InitCamera(){
            GameOverUI.GetComponent<GameOver>().InitCamera();
        }
        public void AddScore() {
            HeadUI.AddScore();
        }
        public void BrushScore() {
            HeadUI.BrushScore();
        }
        public void SetHealthUIMaxValue(float Healthvalue){
            HeadUI.SetHealthUIMaxValue(Healthvalue);
        }
        public void SetHealthUIValue(float Healthvalue) {
            HeadUI.SetHealthUIValue(Healthvalue);
        }
        public void HideAllHeadUIImage(){
            for(int i=0; i<HeadUIImage.Length; i++){
                HeadUIImage[i].SetActive(false);
            }
        }
        public GameObject GetHeadUIImage(int i) {
            // return HeadUI.transform.Find("HeadUIImage").gameObject.transform.Find(i+"").gameObject;
            return HeadUIImage[i];
        }

        public void SendEvent(string s) {
            if (s == "GameOver") {

                GameSystem.m_GameControl.GetComponent<GameControl>().SendEvent(s);
                StoreUI.SendEvent(s);
            }
            if (s == "TankDemo") {
                GameSystem.m_GameControl.GetComponent<GameControl>().SendEvent(s);
            }
            if (s == "Multiplayer") {

            }
            if (s == "TurretDemo") {
                GameSystem.m_GameControl.GetComponent<GameControl>().SendEvent(s);
            }
            if (s == "PlaneDemo") {
                GameSystem.m_GameControl.GetComponent<GameControl>().SendEvent(s);
            }
            if (s == "Setting") {
                SettingUI.GetComponent<SettingUI>().SendEvent(s);
            }
            if (s == "Exit") {
                GameSystem.m_GameControl.GetComponent<GameControl>().SendEvent(s);
            }
        }

        public void SetTankBtn(bool b){
            TankBtn.interactable = b;
        }
        public void SetTurretBtn(bool b){
            TurretBtn.interactable = b;
        }
        public void SetPlaneBtn(bool b){
            PlaneBtn.interactable = b;
        }
    }
}

