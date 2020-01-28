using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace complete{
	public abstract class BaseHealth : MonoBehaviour {
		public ItemData ItemData;
        //public GameObject BoomEffect;
        public UnityEvent onDead;

        [HideInInspector]
		public float HealthValue;
		[HideInInspector]
		public float CurrentHealth;  		// 当前生命值

        protected ObjectInfo _ObjectInfo;

        protected virtual void Start() {
            _ObjectInfo = GetComponent<ObjectInfo>();
        }

        public void SubHealthValue() {
			CurrentHealth -= 1;
		}
		public void AddHealthValue() {
			CurrentHealth += 1;
		}
		public float GetHealthValue() {
			return CurrentHealth;
		}

		public virtual void DeadMethod() {
			//Destroy(gameObject);
            //Instantiate(BoomEffect, gameObject.transform.position - new Vector3(0f, 1.4f, 0f), Quaternion.identity);
            ObjectPoolManager.Instance.GetGameObject("ObjBoomEffectPool", gameObject.transform.position - new Vector3(0f, 1.4f, 0f), Quaternion.identity, 1);
            _ObjectInfo.RemoveGameObject();
            onDead.Invoke();
        }

	}
}

