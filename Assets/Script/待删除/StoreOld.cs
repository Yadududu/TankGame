using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace complete1 {
    public class StoreOld : MonoBehaviour {

     //   public UIControl UIControl;
        public Text TotalScoreValue;

        public int Value100 = 100;
        public int Value200 = 200;
        public int Value300 = 300;
        public int Value400 = 400;
        public GameObject PlayerPrefab;

        private GameObject[] Values100;
        private GameObject[] Values200;
        private GameObject[] Values300;
        private GameObject[] Values400;

        [SerializeField]
        private TankMode[] list1;

        

        // Use this for initialization
        void Start() {
            Values100 = GameObject.FindGameObjectsWithTag("Value100");
            Values200 = GameObject.FindGameObjectsWithTag("Value200");
            Values300 = GameObject.FindGameObjectsWithTag("Value300");
            Values400 = GameObject.FindGameObjectsWithTag("Value400");

        }

        // Update is called once per frame
        void Update() {
            if (int.Parse(TotalScoreValue.text) < Value100) {
                if (Values100 != null) {
                    foreach (GameObject Value in Values100)
                        Value.GetComponent<Button>().interactable = false;
                }
            } else {
                if (Values100 != null) {
                    foreach (GameObject Value in Values100)
                        Value.GetComponent<Button>().interactable = true;
                }
            }

            if (int.Parse(TotalScoreValue.text) < Value200) {
                if (Values200 != null) {
                    foreach (GameObject Value in Values200)
                        Value.GetComponent<Button>().interactable = false;
                }
            } else {
                if (Values200 != null) {
                    foreach (GameObject Value in Values200)
                        Value.GetComponent<Button>().interactable = true;
                }
            }

            if (int.Parse(TotalScoreValue.text) < Value300) {
                if (Values300 != null) {
                    foreach (GameObject Value in Values300)
                        Value.GetComponent<Button>().interactable = false;
                }
            } else {
                if (Values300 != null) {
                    foreach (GameObject Value in Values300)
                        Value.GetComponent<Button>().interactable = true;
                }
            }

            if (int.Parse(TotalScoreValue.text) < Value400) {
                if (Values400 != null) {
                    foreach (GameObject Value in Values400)
                        Value.GetComponent<Button>().interactable = false;
                }
            } else {
                if (Values400 != null) {
                    foreach (GameObject Value in Values400)
                        Value.GetComponent<Button>().interactable = true;
                }
            }
        }

        public void SendEvent(string s) {
            if (s == "GameOver") {
     //           TotalScoreValue.text = int.Parse(TotalScoreValue.text) + int.Parse(UIControl.GetNewScore()) + "";
            }
            if (s == "Buy100") {
                TotalScoreValue.text = int.Parse(TotalScoreValue.text) - Value100 + "";
            }
            if (s == "Buy200") {
                TotalScoreValue.text = int.Parse(TotalScoreValue.text) - Value200 + "";
            }
            if (s == "Buy300") {
                TotalScoreValue.text = int.Parse(TotalScoreValue.text) - Value300 + "";
            }
            if (s == "Buy400") {
                TotalScoreValue.text = int.Parse(TotalScoreValue.text) - Value400 + "";
            }
            if (s == "Start") {
                Start();
            }
            if (s == "S1") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[0].Tank.SetActive(true);
                list1[0].But.interactable = false;
                list1[0].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;

            }
            if (s == "S2") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[1].Tank.SetActive(true);
                list1[1].But.interactable = false;
                list1[1].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S3") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[2].Tank.SetActive(true);
                list1[2].But.interactable = false;
                list1[2].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S4") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[3].Tank.SetActive(true);
                list1[3].But.interactable = false;
                list1[3].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S5") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[4].Tank.SetActive(true);
                list1[4].But.interactable = false;
                list1[4].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S6") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[5].Tank.SetActive(true);
                list1[5].But.interactable = false;
                list1[5].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S7") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[6].Tank.SetActive(true);
                list1[6].But.interactable = false;
                list1[6].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S8") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[7].Tank.SetActive(true);
                list1[7].But.interactable = false;
                list1[7].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S9") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[8].Tank.SetActive(true);
                list1[8].But.interactable = false;
                list1[8].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S10") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[9].Tank.SetActive(true);
                list1[9].But.interactable = false;
                list1[9].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S11") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[10].Tank.SetActive(true);
                list1[10].But.interactable = false;
                list1[10].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S12") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[11].Tank.SetActive(true);
                list1[11].But.interactable = false;
                list1[11].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S13") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[12].Tank.SetActive(true);
                list1[12].But.interactable = false;
                list1[12].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S14") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[13].Tank.SetActive(true);
                list1[13].But.interactable = false;
                list1[13].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S15") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[14].Tank.SetActive(true);
                list1[14].But.interactable = false;
                list1[14].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = false;
            }
            if (s == "S16") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[15].Tank.SetActive(true);
                list1[15].But.interactable = false;
                list1[15].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = true;
            }
            if (s == "S17") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[16].Tank.SetActive(true);
                list1[16].But.interactable = false;
                list1[16].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = true;
            }
            if (s == "S18") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[17].Tank.SetActive(true);
                list1[17].But.interactable = false;
                list1[17].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = true;
            }
            if (s == "S19") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[18].Tank.SetActive(true);
                list1[18].But.interactable = false;
                list1[18].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = true;
            }
            if (s == "S20") {
                foreach (TankMode t in list1) {
                    t.Tank.SetActive(false);
                    t.But.interactable = true;
                    t.HeadUI.SetActive(false);
                }
                list1[19].Tank.SetActive(true);
                list1[19].But.interactable = false;
                list1[19].HeadUI.SetActive(true);
                PlayerPrefab.GetComponent<Player>().DoubleBullet = true;
            }
        }
    }

    [System.Serializable]
    class TankMode {
        public GameObject Tank;
        public Button But;
        public GameObject HeadUI;
    }
}

