﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LMJ;

namespace complete {
    public class TankBullet : BaseBullet {
        
        protected override void OnCollisionEnter(Collision collision) {
            
            string s = collision.gameObject.tag;
            if (s == "Enemy") {
                ScoreSystem.Get.Gain();
            }
            base.OnCollisionEnter(collision);
        }
    }
}

