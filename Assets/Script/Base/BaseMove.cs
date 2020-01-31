using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
	public class BaseMove : MonoBehaviour {

		public SystemData systemData;
        
		protected int Speed;

        protected virtual void Start() {
            Speed = 10;
        }
        protected virtual void Update() {
            MoveMethod();
        }
        protected virtual void MoveMethod() {
            transform.Translate(new Vector3(0f, 0f, Input.GetAxis("Vertical")) * Time.deltaTime * Speed);
            transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal"), 0f) * Time.deltaTime * 50);
        }
	}
}

