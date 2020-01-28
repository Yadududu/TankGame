using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LMJ {
    public class GameOver : MonoBehaviour {
        public static GameOver Get{ get; private set; }

        public Button restartBtn;

        GameOver() {
            Get = this;
        }

        public void SetRestartBtn(State state,GameController gameController) {
            switch (state) {
                case State.TankMode:
                    restartBtn.onClick.AddListener(gameController.PlayTank);
                    break;
                case State.PlaneMode:
                    restartBtn.onClick.AddListener(gameController.PlayPlane);
                    break;
                case State.TurretMode:
                    restartBtn.onClick.AddListener(gameController.PlayTurret);
                    break;
            }
        }

        private void OnDisable() {
            restartBtn.onClick.RemoveAllListeners();
        }
    }
}
