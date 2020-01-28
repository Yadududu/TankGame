using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class TurretAttack : BaseAttack {

        public override void AttackControl(bool DoubleBullet) {
            ObjectPoolManager.Instance.GetGameObject("BulletPlayerPool", transform.TransformPoint(new Vector3(0, 1.88f, 2.96f)), transform.rotation, 0);
            ObjectPoolManager.Instance.GetGameObject("FireEffectPool", transform.TransformPoint(new Vector3(0, 1.88f, 2.96f)), Quaternion.Euler(90.0f, transform.localEulerAngles.y, 0.0f), 2);
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                AttackControl(false);
                ActiveAudio();
            }
        }

    }

}
