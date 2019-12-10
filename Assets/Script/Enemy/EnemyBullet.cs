using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class EnemyBullet : BaseBullet {

        // public ItemData ItemData;
        // public GameObject Effect;

        // private float BulletSpeed;
        // private float Move;

        // void Start() {
        //     BulletSpeed = ItemData.EnemyBulletSpeed;
        //     Move = BulletSpeed * Time.deltaTime;
        // }

        // void Update() {
        //     this.transform.Translate(Vector3.forward * Move);
        // }

        void OnCollisionEnter(Collision collision) {
            
            Destroy(gameObject);
            Instantiate(Effect, gameObject.transform.position, Quaternion.identity);
            
        }
    }
}