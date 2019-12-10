﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete{
    public class EnemyAttack : AutoAttack {

        // public ItemData ItemData;
        // public GameObject Bullet;
        // public GameObject FireEffect;
        // public GameObject FireTransform;

        // private float FireRate;
        // private float NextFire = 0.0F;
        private float AttackDistance;
        private RaycastHit Hit;
        private Ray Ray;
        private CapsuleCollider EnemyTankCollider;

        void Start() {
            AttackDistance = ItemData.EnemyAttackDistance;
            FireRate = ItemData.EnemyFireRate;
            EnemyTankCollider = GetComponent<CapsuleCollider>();
        }

        void Update() {
            AutoAttackMethod();
        }

	    public override void AutoAttackMethod(){
            Ray = new Ray(transform.position + new Vector3(0f, EnemyTankCollider.center.y, 0f), transform.forward);
            Debug.DrawRay(Ray.origin, Ray.direction * AttackDistance, Color.red);

            if (Physics.Raycast(Ray, out Hit)) {
                if (Hit.distance < AttackDistance) {
                    if (Hit.collider.gameObject.tag == "Player") {
                        
                        if (Time.time > NextFire) {
                            NextFire = Time.time + FireRate;
                            Instantiate(Bullet, FireTransform.transform.position, gameObject.transform.rotation);
                            Instantiate(FireEffect, FireTransform.transform.position, Quaternion.Euler(90.0f, gameObject.transform.localEulerAngles.y, 0.0f));
                            ActiveAudio();
                        }
                    }
                }
            }

            
         } 
    }
}
