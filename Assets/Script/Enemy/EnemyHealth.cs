using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete{
    public class EnemyHealth : BaseHealth {

        // public ItemData ItemData;
        // public GameObject BoomEffect;

        // private int HealthValue;
        // private float CurrentHealth;                      // 当前生命值
        

        protected override void Start() {
            base.Start();
            HealthValue = ItemData.EnemyHealthValue;
            CurrentHealth = HealthValue;
            
        }

        void OnCollisionEnter(Collision collision) {
            string s = collision.gameObject.tag;
            if (s == "Bullet") {
                SubHealthValue();
                if (GetHealthValue() <= 0) {
                    DeadMethod();
                }
            }
        }
        //public override void DeadMethod() {
        //    base.DeadMethod();
        //    _ObjectInfo.RemoveGameObject();
        //}
    }
}

