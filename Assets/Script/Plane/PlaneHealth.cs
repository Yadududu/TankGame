using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LMJ;

namespace complete{
	public class PlaneHealth : BaseHealth {

        // public GameObject Effect;

        protected override void Start() {
            base.Start();
            HealthValue = ItemData.PlaneHealthValue;
		}

		void Update () {
			
		}

		void OnCollisionEnter(){
            //GameSystem.m_UIControl.GetComponent<UIControl>().ShowGameOverUI();
            ScoreSystem.Get.Add(ScoreSystem.Get.score);
            DeadMethod();
		}
	}
}

