using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace complete {
    public enum Type {
        TankModelInit,
        TankModel_1,
        TankModel_2,
        TankModel_3,
        TankModel_4,
        PlaneModel,
        Turret
    }
    public class Store : MonoBehaviour {

        [HideInInspector]
        public GameData GameData;
        public Text TotalScoreValue;
        public Button InitSelectBtn;
        public GameObject[] TankModel;

        private Button PreSelectBtn;
        private UIControl UIControl;

        // Use this for initialization
        void Start() {
            UIControl = GameSystem.m_UIControl.GetComponent<UIControl>();
            // gameData = UIControl.GameData;
            PreSelectBtn = InitSelectBtn;
            
        }

        // Update is called once per frame
        void Update() {

        }

        public void BuyBtn(int Value,Button Button) {
            if (GameData.TotalScore < Value) {
                Button.interactable = false;
                
            } else {
                Button.interactable = true;
                
            }
        }

        public void Buy(int cost) {
            GameData.TotalScore -= cost;
            TotalScoreValue.text = GameData.TotalScore.ToString();
        }

        public void SelectBtn(int num,Button Button) {
            if (PreSelectBtn!=null) {
                PreSelectBtn.interactable = true;
            }
            Button.interactable = false;

            SelectTankModel(num);
            SelectHeadUIImage(num);
            
            PreSelectBtn = Button;
        }

        public void SelectTankModel(int num) {
            if(num>=0 & num<=19){
                for (int i = 0; i < 21; i++) {
                    TankModel[i].SetActive(false);
                }
                TankModel[num].SetActive(true);
                if(UIControl!=null){
                    UIControl.SetTankBtn(true);
                    UIControl.SetTurretBtn(false);  
                    UIControl.SetPlaneBtn(false);
                }
            }else if(num>=20 & num<=28){
                for (int i = 0; i < 10; i++) {
                    TankModel[i+19].SetActive(false);
                }
                TankModel[num].SetActive(true);
                UIControl.SetTankBtn(false);
                UIControl.SetTurretBtn(false);
                UIControl.SetPlaneBtn(true);
            }else if(num==29){
                TankModel[num].SetActive(true);
                UIControl.SetTankBtn(false);
                UIControl.SetTurretBtn(true);
                UIControl.SetPlaneBtn(false);
            }
            
        }

        void SelectHeadUIImage(int num) {
            int x;
            UIControl.HideAllHeadUIImage();

            if(num>=0 & num<=19){
                x = num / 5;
                Debug.Log(x);
                switch (x) {
                    case 0:
                    case 1:
                    case 2:
                        UIControl.GetHeadUIImage(x).SetActive(true); 
                        GameSystem.m_GameControl.GetComponent<GameControl>().SetTankDoubleBullet(false);
                        break;
                    case 3:
                        UIControl.GetHeadUIImage(x).SetActive(true);
                        GameSystem.m_GameControl.GetComponent<GameControl>().SetTankDoubleBullet(true);
                        break;
                }
            }else if(num>=20 & num<=28){
                x = num - 20 + 4;
                switch (x) {
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 12:
                        UIControl.GetHeadUIImage(x).SetActive(true); 
                        GameSystem.m_GameControl.GetComponent<GameControl>().SetPlaneDoubleBullet(true);
                        break;
                    case 10:
                    case 11:
                        UIControl.GetHeadUIImage(x).SetActive(true); 
                        GameSystem.m_GameControl.GetComponent<GameControl>().SetPlaneDoubleBullet(false);
                        break;
                }
            }else if(num==29){
                x = num - 20 - 9 + 4 + 9;
                UIControl.GetHeadUIImage(x).SetActive(true); 
            }
            
        }

        public void SendEvent(string s) {
            if (s == "GameOver") {
                // TotalScoreValue.text = int.Parse(TotalScoreValue.text) + int.Parse(GameSystem.m_UIControl.GetComponent<UIControl>().GetNewScore()) + "";
                GameData.TotalScore += GameData.CurrentScore; 
                TotalScoreValue.text = GameData.TotalScore.ToString();
            } 
        }

        public int ModePeice(Type m_Type){
            int Value = 0;
            if(m_Type == Type.TankModelInit){
                Value = GameData.TankModelInit;
            }else if(m_Type == Type.TankModel_1){
                Value = GameData.TankModelPrice_1;
            }else if(m_Type == Type.TankModel_2){
                Value = GameData.TankModelPrice_2;
            }else if(m_Type == Type.TankModel_3){
                Value = GameData.TankModelPrice_3;
            }else if(m_Type == Type.TankModel_4){
                Value = GameData.TankModelPrice_4;
            }else if(m_Type == Type.PlaneModel){
                Value = GameData.PlaneModePrice;
            }else if(m_Type == Type.Turret){
                Value = GameData.TurretPrice;
            }
            return Value;
        }

    }
}

