using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class EnemyMove : BaseMove {

        // public ItemData ItemData;
        // private float Speed;
        private bool IsTurn = false;

        void Update() {
            Speed = ItemData.EnemyMoveSpeed;
            MoveMethod();
        }

        public override void MoveMethod(){
            gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        void OnCollisionEnter() {
            IsTurn = true;
            Turn();
        }
        void OnCollisionExit() {
            IsTurn = false;
        }

        void Turn() {
            Vector3 playerRotation = gameObject.transform.localEulerAngles;
            int num;
            while (true) {
                num = Random.Range(1, 5);
                num = num * 90;
                if (playerRotation.y != num) {
                    break;
                }
            }
            gameObject.transform.localEulerAngles = new Vector3(0.0f, num, 0.0f);
        }
        
    }
}

