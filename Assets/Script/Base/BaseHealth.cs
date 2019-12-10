using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete{
	public abstract class BaseHealth : MonoBehaviour {
		public ItemData ItemData;
		public GameObject BoomEffect;

		[HideInInspector]
		public float HealthValue;
		[HideInInspector]
		public float CurrentHealth;  		// 当前生命值
		
		public void SubHealthValue() {
			CurrentHealth -= 1;
		}
		public void AddHealthValue() {
			CurrentHealth += 1;
		}
		public float GetHealthValue() {
			return CurrentHealth;
		}

		public void DeadMethod() {
			Destroy(gameObject);
			Instantiate(BoomEffect, gameObject.transform.position - new Vector3(0f, 1.4f, 0f), Quaternion.identity);
		}

	}
}

