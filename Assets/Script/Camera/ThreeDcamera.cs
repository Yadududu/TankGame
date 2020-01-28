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
					gameObject.transform.position = CameraTransform.transform.TransformPoint(new Vector3(0, 1.86f, -1.46f));
                    gameObject.transform.rotation = CameraTransform.transform.rotation;
				}
			}
			
		}
		public void SetCameraTransform(GameObject m_CameraTransform){
			
			CameraTransform = m_CameraTransform;
			
			gameObject.transform.position = m_CameraTransform.transform.TransformPoint(new Vector3(0,1.86f,-1.46f));
			gameObject.transform.rotation = m_CameraTransform.transform.rotation;
		}

	}
}

