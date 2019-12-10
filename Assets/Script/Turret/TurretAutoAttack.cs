using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class TurretAutoAttack : AutoAttack {

        // public ItemData ItemData;
        // public GameObject Bullet;
        // public GameObject FireEffect;
        // public GameObject FireTransform;
        public GameObject Gun;

        // private float FireRate;
        // private float NextFire = 0.0F;
        private Vector3 Target;
        private GameObject Tar;

        void Start() {
            //EnemyTankCollider = GetComponent<CapsuleCollider>();
            FireRate = ItemData.TurretFireRate;
        }

        void Update() {
            //transform.Rotate(Vector3.up * Time.deltaTime * 1);
        }

        public override void AutoAttackMethod() {
            if (Time.time > NextFire) {
                NextFire = Time.time + FireRate;

                Gun.transform.LookAt(Target);
                //Gun.transform.rotation = Quaternion.LookRotation(Target - Gun.transform.position);
                
                //Debug.DrawLine(transform.position, Target, Color.blue);
                //Quaternion.Slerp(Gun.transform.rotation, Quaternion.LookRotation(Target - Gun.transform.position), NextFire);

                if (Gun.transform.localEulerAngles.x > 0) {
                    Gun.transform.rotation = Quaternion.Euler(0f, Gun.transform.localEulerAngles.y, 0f);
                }

                Instantiate(Bullet, FireTransform.transform.position, Gun.transform.localRotation);
                Instantiate(FireEffect, FireTransform.transform.position, Quaternion.Euler(90.0f, FireTransform.transform.eulerAngles.y, 0.0f));
            }

        }

        void OnTriggerStay(Collider collider) {
            if (collider.gameObject.tag == "Enemy") {
                Target = collider.transform.position;
                Tar = collider.gameObject;
                
                AutoAttackMethod();
            }
        }
    }
}
