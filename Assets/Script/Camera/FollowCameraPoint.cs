using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
	public class FollowCameraPoint : MonoBehaviour {

		private GameObject FollowCamera;
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			if(FollowCamera!=null){
				transform.position = FollowCamera.transform.position;
				// transform.rotation = FollowCamera.transform.rotation;
			}
		}
		public void SetFollowCamera(GameObject m_FollowCamera){
			FollowCamera = m_FollowCamera;
		}
	}
}

