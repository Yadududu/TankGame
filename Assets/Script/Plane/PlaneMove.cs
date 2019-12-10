using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete{
	public class PlaneMove : BaseMove {

		// public GameObject Effect;
		public Transform Head;
		public Transform LeftAirfoil;
		public Transform RightAirfoil;
		public Transform LeftTailAirfoil;
		public Transform RightTailAirfoil;

		private float UpForce;
		private float TailUpForce;
		// private float Speed;
		private float W_LiftSpeed;
		private float S_LiftSpeed;
		private float A_LiftSpeed;
		private float D_LiftSpeed;
		private Rigidbody rb;

		// Use this for initialization
		void Start () {
			rb = GetComponent<Rigidbody>();
			UpForce = ItemData.PlaneUpForce;
			TailUpForce = ItemData.PlaneTailUpForce;
			Speed = ItemData.PlaneSpeed;
			W_LiftSpeed = ItemData.Plane_W_LiftSpeed;
			S_LiftSpeed = ItemData.Plane_S_LiftSpeed;
			A_LiftSpeed = ItemData.Plane_A_LiftSpeed;
			D_LiftSpeed = ItemData.Plane_D_LiftSpeed;
		}
		
		// Update is called once per frame
		void Update () {
			MoveMethod();
		}

		public override void MoveMethod(){
			// transform.Translate(Vector3.forward*Time.deltaTime);
			rb.AddForceAtPosition(transform.forward*Speed,Head.position);

			rb.AddForceAtPosition(transform.up*UpForce,LeftAirfoil.position);
			rb.AddForceAtPosition(transform.up*UpForce,RightAirfoil.position);

			rb.AddForceAtPosition(transform.up*TailUpForce,LeftTailAirfoil.position);
			rb.AddForceAtPosition(transform.up*TailUpForce,RightTailAirfoil.position);

			//俯冲
			if(Input.GetKey(KeyCode.W)){
				rb.AddForceAtPosition(transform.up*W_LiftSpeed,LeftTailAirfoil.position);
				rb.AddForceAtPosition(transform.up*W_LiftSpeed,RightTailAirfoil.position);
			}
			//爬升
			else if(Input.GetKey(KeyCode.S)){
				rb.AddForceAtPosition(transform.up*-S_LiftSpeed,LeftTailAirfoil.position);
				rb.AddForceAtPosition(transform.up*-S_LiftSpeed,RightTailAirfoil.position);
			}
			//左翻滚
			else if(Input.GetKey(KeyCode.A)){
				rb.AddForceAtPosition(transform.up*-A_LiftSpeed,LeftTailAirfoil.position);
				rb.AddForceAtPosition(transform.up*A_LiftSpeed,RightTailAirfoil.position);
			}
			//右翻滚
			else if(Input.GetKey(KeyCode.D)){
				rb.AddForceAtPosition(transform.up*D_LiftSpeed,LeftTailAirfoil.position);
				rb.AddForceAtPosition(transform.up*-D_LiftSpeed,RightTailAirfoil.position);
			}
		}
	}
}


