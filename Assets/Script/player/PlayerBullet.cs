using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class PlayerBullet : BaseBullet {

        // public ItemData ItemData;
        // public GameObject Effect;

        // private float BulletSpeed;
        // private float Move;

        // void Start() {
        //     BulletSpeed = ItemData.PlayerBulletSpeed;
        //     Move = BulletSpeed * Time.deltaTime;
        // }

        // void Update() {
        //     this.transform.Translate(Vector3.forward * Move);
        // }

        void OnCollisionEnter(Collision collision) {
            
            string s = collision.gameObject.tag;
            if (s == "Enemy") {
                GameSystem.m_UIControl.GetComponent<UIControl>().AddScore();
            }
            Destroy(gameObject);
            Instantiate(Effect, gameObject.transform.position, Quaternion.identity);
            
        }
    }
}

