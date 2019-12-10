using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace complete {
	public class InputText : MonoBehaviour {

		public GameData gameData;
		public InputField inputField;

		private GameObject Turret;
		private GameObject ThreeCamera;
		private GameControl GameControl;
		private bool ActionTurretAutoAttack;

		private void Start() {
			GameControl = GameSystem.m_GameControl.gameObject.GetComponent<GameControl>();
		}

		public void ActionMethod(){
			Debug.Log(inputField.text);
			if(inputField.text == "GetMeMoney"){
				gameData.TotalScore += 5000;
				GameSystem.m_UIControl.GetComponent<UIControl>().StoreUI.TotalScoreValue.text = gameData.TotalScore.ToString();
			}
			if(inputField.text == "Init"){
				GameControl.ItemData.PlayerHealthValue = 3;
				GameControl.ItemData.PlayerBulletSpeed = 30;
				GameControl.ItemData.PlayerMoveSpeed = 10;

				GameControl.ItemData.EnemyHealthValue = 1;
				GameControl.ItemData.EnemyBulletSpeed = 20;
				GameControl.ItemData.EnemyMoveSpeed = 5;
				GameControl.ItemData.EnemyAttackDistance = 30;
				GameControl.ItemData.EnemyFireRate = 1;
				GameControl.ItemData.EnemyCreateRate = 3;

				GameControl.ItemData.TurretFireRate = 0.5f;
				GameControl.ItemData.TurretSpeed = 10;

				GameControl.ItemData.PlaneHealthValue = 1;
				GameControl.ItemData.PlaneUpForce = 5;
				GameControl.ItemData.PlaneTailUpForce = 1;
				GameControl.ItemData.PlaneSpeed = 250;
				GameControl.ItemData.Plane_W_LiftSpeed = 10;
				GameControl.ItemData.Plane_S_LiftSpeed = 5;
				GameControl.ItemData.Plane_A_LiftSpeed = 10;
				GameControl.ItemData.Plane_D_LiftSpeed = 10;

				gameData.TotalScore = 0;
				GameSystem.m_UIControl.GetComponent<UIControl>().StoreUI.TotalScoreValue.text = gameData.TotalScore.ToString();
			}
			if(inputField.text == "TurretAutoAttack"){
				Debug.Log("ready");
				if(Turret != null){
					Debug.Log("OK");
					ActionTurretAutoAttack = true;
					GameControl.Set3DCamera(false);
					GameControl.SetMainCamera(true);
					// Turret.transform.position = new Vector3(91.6f ,0.03f ,88.2f);
					Turret.transform.eulerAngles = new Vector3(0f ,0f ,0f);
					Turret.GetComponent<TurretMove>().enabled = false;
					Turret.GetComponent<TurretAttack>().enabled = false;
					Turret.GetComponent<BoxCollider>().enabled = true;
				}
			}
			if(inputField.text == "CancelTurretAutoAttack"){
				if(ActionTurretAutoAttack ==true){
					ActionTurretAutoAttack = false;
					Turret.GetComponent<BoxCollider>().enabled = false;
					GameControl.Set3DCamera(true);
					GameControl.SetMainCamera(false);
					Turret.GetComponent<TurretMove>().enabled = true;
					Turret.GetComponent<TurretAttack>().enabled = true;
					ThreeCamera.transform.eulerAngles = new Vector3(0f ,0f ,0f);
					Turret.GetComponent<TurretAutoAttack>().Gun.transform.eulerAngles = new Vector3(0f ,0f ,0f);
				}
		}
			inputField.text = "";
		}
		public void SetTurret(GameObject m_Turret){
			Turret = m_Turret;
		}
		public void Set3DCamera(GameObject m_ThreeCamera){
			ThreeCamera = m_ThreeCamera;
		}
		public void SetActionAutoAttack(bool m_ActionTurretAutoAttack){
			ActionTurretAutoAttack = m_ActionTurretAutoAttack;
		}
	}
}

