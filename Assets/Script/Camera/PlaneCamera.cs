using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete{
	public class PlaneCamera : MonoBehaviour {

		//相机距离人物高度
		public float m_Height = 2.25f;
		//相机距离人物距离
		public float m_Distance = -2.55f;
		private GameObject PlaneObject;
		//相机跟随速度
		private float m_Speed = 4f;
		//目标位置
		private Vector3 m_TargetPosition;
		//要跟随的人物
		private Transform Follow;
		private Camera Camera;

		// Use this for initialization
		void Start () {
			Camera = gameObject.GetComponent<Camera>();
		}
		
		// Update is called once per frame
		void Update () {

			if(PlaneObject != null){
				//得到这个目标位置
				m_TargetPosition = Follow.position + Vector3.up * m_Height - Follow.forward * m_Distance;
				//相机位置
				transform.position = Vector3.Lerp (transform.position, m_TargetPosition, m_Speed * Time.deltaTime);
				//相机时刻看着人物
				transform.LookAt (Follow);
			}
		}

		public void SetFollowGameObject(GameObject m_PlaneObject){
			PlaneObject = m_PlaneObject;
			Follow = PlaneObject.transform;
		}
	}
}

