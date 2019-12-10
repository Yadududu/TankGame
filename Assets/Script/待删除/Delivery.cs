using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class Delivery : MonoBehaviour {

        public PlayerMove PlayerMove;
        public PlayerHealth PlayerHealth;
        public PlayerBullet PlayerBullet;

        public void receive(GameControl GameControl) {

            //PlayerMove.GameControl = GameControl;
            //PlayerHealth.GameControl = GameControl;
            //PlayerBullet.GameControl = GameControl;

        }
    }
}

