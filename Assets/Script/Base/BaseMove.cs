using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
	public abstract class BaseMove : MonoBehaviour {
		public ItemData ItemData;

		[HideInInspector]
		public float Speed;
		
		public abstract void MoveMethod();
	}
}

