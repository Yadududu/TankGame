using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace complete {

	public class EnterKey : MonoBehaviour {

		public GameObject InputText;
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			if(Input.GetKeyDown(KeyCode.Return)){
				InputText.GetComponent<InputText>().ActionMethod();
				InputText.SetActive(false);
			}
				
		}
	}
}
