using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class EnemyMove : BaseMove {
        
        protected override void Start() {
            Speed = systemData.enemyMoveSpeed;
        }
        protected override void Update() {
            MoveMethod();
        }
        protected override void MoveMethod() {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        private void OnCollisionEnter() {
            Turn();
        }
        private void Turn() {
            int num = Random.Range(1, 5);
            num = num * 90;
            if (num == transform.localEulerAngles.y) {
                Turn();
                return;
            }
            transform.localEulerAngles = new Vector3(0.0f, num, 0.0f);
        }
    }
}

