using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LMJ;

namespace complete {
    public class PlayerHealth : BaseHealth {

        // public ItemData ItemData;
        // public GameObject BoomEffect;
        
        public Slider sliderSelf;
        public Color FullHealthColor = Color.green;       // 满血状态时的血条颜色
        public Color ZeroHealthColor = Color.red;         // 空血的血条状态颜色
        
        private Image _Fill;
        private HealthUI _SliderHand;

        // private int HealthValue;
        // private float CurrentHealth;                      // 当前生命值

        private void init() {
            HealthValue = ItemData.PlayerHealthValue;
            // GameSystem.m_UIControl.GetComponent<UIControl>().SetHealthUIMaxValue(PlayerHealthValue);
            _SliderHand.slider.maxValue = HealthValue;
            _SliderHand.slider.value = HealthValue;
            sliderSelf.maxValue = HealthValue;
            sliderSelf.value = HealthValue;
            CurrentHealth = HealthValue;
            _SliderHand.fill.color = FullHealthColor;
            _Fill.color = FullHealthColor;
        }
        private void Awake() {
            _SliderHand = HealthUI.Get;
            _Fill = sliderSelf.fillRect.GetComponent<Image>();
        }
        private void OnEnable() {
            init();
        }

        protected override void Start(){
            base.Start();
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

        private void UpdateUIPlayHealth() {
            //GameSystem.m_UIControl.GetComponent<UIControl>().SetHealthUIValue(CurrentHealth);
            _SliderHand.slider.value = CurrentHealth;
            sliderSelf.value = CurrentHealth;


            // 差值运算得到显示的过度颜色，从0~100之间取值
            _Fill.color = Color.Lerp(ZeroHealthColor, FullHealthColor, CurrentHealth / HealthValue);
        }

        private void Dead() {
            ScoreSystem.Get.Add(ScoreSystem.Get.score);
            _SliderHand.fill.color = ZeroHealthColor;
            DeadMethod();
        }

        private void OnCollisionEnter(Collision collision) {
            string s = collision.gameObject.tag;

            if (s == "EnemyBullet") {
                SubHealthValue();
                UpdateUIPlayHealth();
                if (GetHealthValue() <= 0) {
                    Dead();
                }
            }
        }

        //public override void DeadMethod() {
        //    base.DeadMethod();
        //    _ObjectInfo.RemoveGameObject();
        //}
    }
}

