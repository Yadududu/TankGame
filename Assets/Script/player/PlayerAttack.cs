using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class PlayerAttack : BaseAttack {
        
        [SerializeField]
        private bool _DoubleBullet;

        void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                AttackControl(_DoubleBullet);
                ActiveAudio();
            }
        }

        public void SetDoubleBullet(bool b) {
            _DoubleBullet = b;
        }
    }
}

