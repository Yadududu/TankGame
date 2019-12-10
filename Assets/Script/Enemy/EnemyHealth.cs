using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete{
    public class EnemyHealth : BaseHealth {

        // public ItemData ItemData;
        // public GameObject BoomEffect;

        // private int HealthValue;
        // private float CurrentHealth;                      // 当前生命值

        void Start() {
            HealthValue = ItemData.EnemyHealthValue;
            CurrentHealth = HealthValue;
        }
        // void Dead() {
        //     Destroy(gameObject);
        //     Instantiate(BoomEffect, gameObject.transform.position - new Vector3(0f, 1.4f, 0f), Quaternion.identity);
        // }

        void OnCollisionEnter(Collision collision) {
            string s = collision.gameObject.tag;
            if (s == "Bullet") {
                SubHealthValue();
                if (GetHealthValue() <= 0) {
                    DeadMethod();
                }
            }
        }

        
    }
}

