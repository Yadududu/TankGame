using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
	public abstract class BaseAttack : MonoBehaviour {
        
        private ObjectPool _BulletPool;
        private ObjectPool _EffectPool;
        
        public virtual void AttackControl(bool DoubleBullet) {
            if (DoubleBullet) {
                ObjectPoolManager.Instance.GetGameObject("BulletPlayerPool", transform.TransformPoint(new Vector3(1.6f, 0.64f, 2)), transform.rotation, 0);
                ObjectPoolManager.Instance.GetGameObject("FireEffectPool", transform.TransformPoint(new Vector3(1.6f, 0.64f, 2)), Quaternion.Euler(90.0f, transform.localEulerAngles.y, 0.0f), 2);

                ObjectPoolManager.Instance.GetGameObject("BulletPlayerPool", transform.TransformPoint(new Vector3(-1.6f, 0.64f, 2)), transform.rotation, 0);
                ObjectPoolManager.Instance.GetGameObject("FireEffectPool", transform.TransformPoint(new Vector3(-1.6f, 0.64f, 2)), Quaternion.Euler(90.0f, transform.localEulerAngles.y, 0.0f), 2);
            } else {
                ObjectPoolManager.Instance.GetGameObject("BulletPlayerPool", transform.TransformPoint(new Vector3(0, 0.57f, 1.41f)), transform.rotation, 0);
                ObjectPoolManager.Instance.GetGameObject("FireEffectPool", transform.TransformPoint(new Vector3(0, 0.57f, 1.41f)), Quaternion.Euler(90.0f, transform.localEulerAngles.y, 0.0f), 2);
            }
		}

		public void ActiveAudio(){
            GetComponent<AudioSource>().Play();
		}
	}
}
