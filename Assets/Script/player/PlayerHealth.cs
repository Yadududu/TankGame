using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace complete {
    public class PlayerHealth : BaseHealth {

        // public ItemData ItemData;
        // public GameObject BoomEffect;
        public Slider Self_Slider;
        public Image FillImage;
        public Color FullHealthColor = Color.green;       // 满血状态时的血条颜色
        public Color ZeroHealthColor = Color.red;         // 空血的血条状态颜色

        // private int HealthValue;
        // private float CurrentHealth;                      // 当前生命值

        void Start(){
            HealthValue = ItemData.PlayerHealthValue;
            // GameSystem.m_UIControl.GetComponent<UIControl>().SetHealthUIMaxValue(PlayerHealthValue);
            Self_Slider.maxValue = HealthValue;
            CurrentHealth = HealthValue;
        }

        // public void SubPlayerHealth() {
        //     CurrentHealth -= 1;
        // }
        // public void AddPlayerHealth() {
        //     CurrentHealth += 1;
        // }
        // public float GetPlayerHealth() {
        //     return CurrentHealth;
        // }

        void UpdateUIPlayHealth() {
            GameSystem.m_UIControl.GetComponent<UIControl>().SetHealthUIValue(CurrentHealth);
            Self_Slider.value = CurrentHealth;

            // 差值运算得到显示的过度颜色，从0~100之间取值
            FillImage.color = Color.Lerp(ZeroHealthColor, FullHealthColor, CurrentHealth / HealthValue);
        }

        void Dead() {
            GameSystem.m_UIControl.GetComponent<UIControl>().ShowGameOverUI();
            DeadMethod();
        }

        void OnCollisionEnter(Collision collision) {
            string s = collision.gameObject.tag;

            if (s == "EnemyBullet") {
                SubHealthValue();
                UpdateUIPlayHealth();
                if (GetHealthValue() <= 0) {
                    Dead();
                }
            }
        }
    

    }
}

