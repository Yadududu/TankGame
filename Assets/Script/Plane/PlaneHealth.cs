using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete{
	public class PlaneHealth : BaseHealth {

		// public GameObject Effect;

		void Start () {
			HealthValue = ItemData.PlaneHealthValue;
		}

		void Update () {
			
		}

		void OnCollisionEnter(){
			GameSystem.m_UIControl.GetComponent<UIControl>().ShowGameOverUI();
			DeadMethod();
		}
	}
}

