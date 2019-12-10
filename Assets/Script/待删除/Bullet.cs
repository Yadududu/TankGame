using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class Bullet : MonoBehaviour {

        public float BulletSpeed;
        public GameObject Effect;

        private float Move;

        // Use this for initialization
        void Start() {
            Move = BulletSpeed * Time.deltaTime;
        }

        // Update is called once per frame
        void Update() {
            this.transform.Translate(Vector3.forward * Move);
        }

        void OnCollisionEnter(Collision collision) {
            string s = collision.gameObject.tag;
            if (s == "Wall" || s == "Floor" || s == "Bullet" || s == "EnemyBullet" || s == "Untagged") {
                Destroy(gameObject);

                //Vector3 playerV3 = gameObject.transform.position;
                //Effect.gameObject.transform.position = playerV3;
                Instantiate(Effect, gameObject.transform.position, Quaternion.identity);
            }


            
            
        }
    }
}

    