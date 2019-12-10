using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
	public class ThreeDcamera : MonoBehaviour {
		
		[HideInInspector]
		public bool RealTime;

		private GameObject CameraTransform;
		// Use this for initialization
		void Start () {

		}
		
		// Update is called once per frame
		void Update () {
			if(RealTime==true){
				if(CameraTransform!=null){
					gameObject.transform.position = CameraTransform.transform.position;
					gameObject.transform.rotation = CameraTransform.transform.rotation;
				}
			}
			
		}
		public void SetCameraTransform(GameObject m_CameraTransform){
			
			CameraTransform = m_CameraTransform;
			
			gameObject.transform.position = m_CameraTransform.transform.position;
			gameObject.transform.rotation = m_CameraTransform.transform.rotation;
		}

	}
}

