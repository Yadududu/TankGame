using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
	public abstract class AutoAttack : MonoBehaviour {

		public ItemData ItemData;

		[HideInInspector]
		public float FireRate;
		[HideInInspector]
		public float NextFire = 0.0F;

		public abstract void AutoAttackMethod();

		public void ActiveAudio(){
            GetComponent<AudioSource>().Play();
		}
	}

}
