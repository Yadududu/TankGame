using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace complete {
    public class SettingUI : MonoBehaviour {

        public ItemData ItemData;
        [Header("Tank")]
        public InputField PlayerHealthInputField;
        public InputField PlayerBulletSpeedInputField;
        public InputField PlayerMoveSpeedInputField;

        [Header("Enemy")]
        public InputField EnemyHealthInputField;
        public InputField EnemyBulletSpeedInputField;
        public InputField EnemyAttackDistanceInputField;
        public InputField EnemyTankSpeedInputField;
        public InputField EnemyFireRateInputField;
        public InputField EnemyCreateRateInputField;

        [Header("Turret")]
        public InputField TurretFireRateInputField;
        public InputField TurretMoveSpeedInputField;

        [Header("Plane")]
        public InputField PlaneUpForceInputField;
        public InputField PlaneTailUpForceInputField;
        public InputField PlaneMoveSpeedInputField;
        public InputField Plane_W_LiftSpeedInputField;
        public InputField Plane_S_LiftSpeedInputField;
        public InputField Plane_A_LiftSpeedInputField;
        public InputField Plane_D_LiftSpeedInputField;

        public UIControl UIControl;

        public void SendEvent(string s) {
            if (s == "Setting") {
                PlayerHealthInputField.text = ItemData.PlayerHealthValue + "";
                PlayerBulletSpeedInputField.text = ItemData.PlayerBulletSpeed + "";
                PlayerMoveSpeedInputField.text = ItemData.PlayerMoveSpeed + "";
                EnemyHealthInputField.text = ItemData.EnemyHealthValue + "";
                EnemyBulletSpeedInputField.text = ItemData.EnemyBulletSpeed + "";
                EnemyAttackDistanceInputField.text = ItemData.EnemyAttackDistance + "";
                EnemyTankSpeedInputField.text = ItemData.EnemyMoveSpeed + "";
                EnemyFireRateInputField.text = ItemData.EnemyFireRate + "";
                EnemyCreateRateInputField.text = ItemData.EnemyCreateRate +"";
                TurretFireRateInputField.text = ItemData.TurretFireRate +"";
                TurretMoveSpeedInputField.text = ItemData.TurretSpeed +"";
                PlaneUpForceInputField.text = ItemData.PlaneUpForce +"";
                PlaneTailUpForceInputField.text = ItemData.PlaneTailUpForce +"";
                PlaneMoveSpeedInputField.text = ItemData.PlaneSpeed +"";
                Plane_W_LiftSpeedInputField.text = ItemData.Plane_W_LiftSpeed +"";
                Plane_S_LiftSpeedInputField.text = ItemData.Plane_S_LiftSpeed +"";
                Plane_A_LiftSpeedInputField.text = ItemData.Plane_A_LiftSpeed +"";
                Plane_D_LiftSpeedInputField.text = ItemData.Plane_D_LiftSpeed +"";
                
                //MenuUI.SetActive(false);
                //Setting.SetActive(true);
            }

            if (s == "Save") {
                ItemData.PlayerHealthValue = float.Parse(PlayerHealthInputField.text);
                ItemData.PlayerBulletSpeed = float.Parse(PlayerBulletSpeedInputField.text);
                ItemData.PlayerMoveSpeed = float.Parse(PlayerMoveSpeedInputField.text);
                ItemData.EnemyHealthValue = float.Parse(EnemyHealthInputField.text);
                ItemData.EnemyBulletSpeed = float.Parse(EnemyBulletSpeedInputField.text);
                ItemData.EnemyAttackDistance = float.Parse(EnemyAttackDistanceInputField.text);
                ItemData.EnemyMoveSpeed = float.Parse(EnemyTankSpeedInputField.text);
                ItemData.EnemyFireRate = float.Parse(EnemyFireRateInputField.text);
                ItemData.EnemyCreateRate = float.Parse(EnemyCreateRateInputField.text);
                ItemData.TurretFireRate = float.Parse(TurretFireRateInputField.text);
                ItemData.TurretSpeed = float.Parse(TurretMoveSpeedInputField.text);
                ItemData.PlaneUpForce = float.Parse(PlaneUpForceInputField.text);
                ItemData.PlaneTailUpForce = float.Parse(PlaneTailUpForceInputField.text);
                ItemData.PlaneSpeed = float.Parse(PlaneMoveSpeedInputField.text);
                ItemData.Plane_W_LiftSpeed = float.Parse(Plane_W_LiftSpeedInputField.text);
                ItemData.Plane_S_LiftSpeed = float.Parse(Plane_S_LiftSpeedInputField.text);
                ItemData.Plane_A_LiftSpeed = float.Parse(Plane_A_LiftSpeedInputField.text);
                ItemData.Plane_D_LiftSpeed = float.Parse(Plane_D_LiftSpeedInputField.text);

                UIControl.ShowMenuUI();
                UIControl.HideSettingUI();
            }

            if (s == "Cancel") {
                PlayerHealthInputField.text = ItemData.PlayerHealthValue + "";                  //3
                PlayerBulletSpeedInputField.text = ItemData.PlayerBulletSpeed + "";             //30
                PlayerMoveSpeedInputField.text = ItemData.PlayerMoveSpeed + "";
                EnemyHealthInputField.text = ItemData.EnemyHealthValue + "";                    //1
                EnemyBulletSpeedInputField.text = ItemData.EnemyBulletSpeed + "";          //10
                EnemyAttackDistanceInputField.text = ItemData.EnemyAttackDistance + "";    //20
                EnemyTankSpeedInputField.text = ItemData.EnemyMoveSpeed + "";              //5
                EnemyFireRateInputField.text = ItemData.EnemyFireRate + "";                //5
                EnemyCreateRateInputField.text = ItemData.EnemyCreateRate +"";            //1
                TurretFireRateInputField.text = ItemData.TurretFireRate +"";
                TurretMoveSpeedInputField.text = ItemData.TurretSpeed +"";
                PlaneUpForceInputField.text = ItemData.PlaneUpForce +"";
                PlaneTailUpForceInputField.text = ItemData.PlaneTailUpForce +"";
                PlaneMoveSpeedInputField.text = ItemData.PlaneSpeed +"";
                Plane_W_LiftSpeedInputField.text = ItemData.Plane_W_LiftSpeed +"";
                Plane_S_LiftSpeedInputField.text = ItemData.Plane_S_LiftSpeed +"";
                Plane_A_LiftSpeedInputField.text = ItemData.Plane_A_LiftSpeed +"";
                Plane_D_LiftSpeedInputField.text = ItemData.Plane_D_LiftSpeed +"";

                UIControl.ShowMenuUI();
                UIControl.HideSettingUI();
            }

        }

    }
}

