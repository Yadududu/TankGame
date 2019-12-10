using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class PlaneAttack : BaseAttack {

        // public GameObject ModelTank_3;
        // public GameObject FireTransform;
        // public GameObject FireTransform2;
        // public GameObject FireTransform3;
        // public GameObject Bullet;
        // public GameObject FireEffect;

        [SerializeField]
        private bool DoubleBullet;

        void Start() {

        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                AttackControl(DoubleBullet);
                ActiveAudio();
            }
        }

        public void SetDoubleBullet(bool b) {
            DoubleBullet = b;
        }
    }
}

