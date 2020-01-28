using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
	public class TurretMove : BaseMove {

		public GameObject Camera3D;
		public GameObject Camera3DTransform;

		private Vector3 Vector3;

		// Use this for initialization
		void Start () {
			Speed = ItemData.TurretSpeed;

			// Camera3D.GetComponent<Tank3Dcamera>().SetCameraTransform(Camera3DTransform);
			// Camera3D.GetComponent<Tank3Dcamera>().RealTime = false;
			// Camera3D.GetComponent<AudioListener>().enabled = true;
            // Camera3D.GetComponent<Camera>().enabled = true;
			//GameSystem.m_GameControl.GetComponent<GameControl>().Set3DCamera(true ,false ,Camera3DTransform);
            //GameSystem.m_GameControl.GetComponent<GameControl>().SetMainCamera(false);

		}
		
		// Update is called once per frame
		void Update () {
			MoveMethod();
		}

		public override void MoveMethod(){
			

			float mouseX = Input.GetAxis("Mouse X") * Speed;
			float mouseY = Input.GetAxis("Mouse Y") * Speed;
	
			// Debug.Log("mouseX"+mouseX);
			// Debug.Log("mouseY"+mouseY);

			// Camera3D.transform.rotation = Camera3D.transform.rotation * Quaternion.Euler(0, mouseX, 0);
			// Camera3D.transform.rotation = Camera3D.transform.rotation * Quaternion.Euler(-mouseY, 0, 0);
			// Camera3D.transform.eulerAngles=(-mouseY, mouseX, 0);s
			
			//要么上下观察，要么左右观察
			if (Mathf.Abs(mouseX) > Mathf.Abs(mouseY)){
                Camera.main.transform.eulerAngles += new Vector3(0, mouseX, 0);
				transform.localRotation = transform.localRotation * Quaternion.Euler(0, mouseX, 0);
			}
			else{
                Camera.main.transform.eulerAngles += new Vector3(-mouseY, 0, 0);//摄像机绕x轴旋转的方向跟鼠标y移动方向相反
				// Debug.Log(Camera3D.transform.eulerAngles.x);
				if(Camera.main.transform.eulerAngles.x <= 350 & Camera.main.transform.eulerAngles.x >= 270){
                    Camera.main.transform.rotation = Quaternion.Euler(new Vector3(-10, Camera.main.transform.eulerAngles.y,0));
				}
				if(Camera.main.transform.eulerAngles.x >= 45 & Camera.main.transform.eulerAngles.x <= 90){
                    Camera.main.transform.rotation = Quaternion.Euler(new Vector3(45, Camera.main.transform.eulerAngles.y,0));
				}
			}
            	

			
		}

	}
}

