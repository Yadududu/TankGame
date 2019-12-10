using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace complete {
	public class HeadLookAtPoint : MonoBehaviour {

		public GameObject HeadPortrait;
		[HideInInspector]
		public GameObject h_LookAtPoint;

		// Use this for initialization
		void Start () {
			int num = Random.Range(0, 8);
			HeadPortrait.GetComponent<HeadProtrait>().ActionHeadProtrait(num);
		}
		
		// Update is called once per frame
		void Update () {
			HeadPortrait.transform.LookAt(h_LookAtPoint.transform);
		}
	}
}

