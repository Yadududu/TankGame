using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace complete {
	public class NeedScoreValue : MonoBehaviour {

		[HideInInspector]
		public int Value;

		// Use this for initialization
		void Start () {
			gameObject.GetComponent<Text>().text = Value.ToString();
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}

