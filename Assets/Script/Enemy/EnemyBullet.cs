using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class EnemyBullet : BaseBullet {
        protected override void Start() {
            _BulletSpeed = systemData.enemyBulletSpeed;
            _ObjectInfo = GetComponent<ObjectInfo>();
        }
    }
}