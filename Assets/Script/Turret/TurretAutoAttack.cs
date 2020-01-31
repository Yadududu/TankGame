using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete {
    public class TurretAutoAttack : AutoAttack {
        
        public GameObject gun;
        
        private Vector3 _Target;

        private void Start() {
            _FireRate = systemData.turretFireRate;
        }
        private void OnTriggerStay(Collider collider) {
            if (collider.gameObject.tag == "Enemy") {
                _Target = collider.transform.position;
                AutoAttackMethod();
            }
        }
        protected override void AutoAttackMethod() {
            if (Time.time > _NextFire) {
                _NextFire = Time.time + _FireRate;

                gun.transform.LookAt(_Target);
                //Gun.transform.rotation = Quaternion.LookRotation(Target - Gun.transform.position);
                
                //Debug.DrawLine(transform.position, Target, Color.blue);
                //Quaternion.Slerp(Gun.transform.rotation, Quaternion.LookRotation(Target - Gun.transform.position), NextFire);

                if (gun.transform.localEulerAngles.x > 0) {
                    gun.transform.rotation = Quaternion.Euler(0f, gun.transform.localEulerAngles.y, 0f);
                }
                
                ObjectPoolManager.Instance.GetGameObject("BulletPlayerPool", transform.TransformPoint(new Vector3(0, 1.88f, 2.96f)), transform.rotation, 0);
                ObjectPoolManager.Instance.GetGameObject("FireEffectPool", transform.TransformPoint(new Vector3(0, 1.88f, 2.96f)), Quaternion.Euler(90.0f, transform.localEulerAngles.y, 0.0f), 2);
            }

        }
    }
}
