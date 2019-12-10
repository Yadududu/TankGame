using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
	public class TurretAttack : BaseAttack {

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown(KeyCode.Mouse0)) {
                AttackControl(false);
				ActiveAudio();
            }
		}

	}

}
