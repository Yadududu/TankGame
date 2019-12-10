using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
	public abstract class BaseAttack : MonoBehaviour {

		public GameObject FireTransform;
		public GameObject FireTransform2;
		public GameObject FireTransform3;
		public GameObject Bullet;
		public GameObject FireEffect;
		public AudioClip FireClip;
		public void AttackControl(bool DoubleBullet) {
			if (DoubleBullet == false) {
				Instantiate(Bullet, FireTransform.transform.position, gameObject.transform.rotation);
				Instantiate(FireEffect, FireTransform.transform.position, Quaternion.Euler(90.0f, gameObject.transform.localEulerAngles.y, 0.0f));
			} else {
				Instantiate(Bullet, FireTransform2.transform.position, gameObject.transform.rotation);
				Instantiate(FireEffect, FireTransform2.transform.position, Quaternion.Euler(90.0f, gameObject.transform.localEulerAngles.y, 0.0f));

				Instantiate(Bullet, FireTransform3.transform.position, gameObject.transform.rotation);
				Instantiate(FireEffect, FireTransform3.transform.position, Quaternion.Euler(90.0f, gameObject.transform.localEulerAngles.y, 0.0f));
			}
		}
		public void ActiveAudio(){
			GetComponent<AudioSource>().clip = FireClip;
            GetComponent<AudioSource>().Play();
		}
	}
}
