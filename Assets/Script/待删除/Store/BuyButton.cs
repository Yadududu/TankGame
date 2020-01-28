using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace complete {
    
    public class BuyButton : MonoBehaviour {

        public Type m_Type;
        public Store Store;
        public NeedScoreValue NeedScoreValue;
        public GameObject SelectBtn;
        
        private int Value;
        private Button Btn;


        // Use this for initialization
        private void OnEnable() {
            Value = Store.ModePeice(m_Type);
            NeedScoreValue.Value = Value;
        }
        void Start() {
            Btn = gameObject.GetComponent<Button>();
            Btn.onClick.AddListener(TaskOnClick);
            
            // SelectBtn.GetComponent<SelectButton>().SetNum(Num);
            // SelectBtn.GetComponent<SelectButton>().SetStore(Store);
        }

        // Update is called once per frame
        void Update() {
            Store.BuyBtn(Value, Btn);
        }

        void TaskOnClick() {
            Store.Buy(Value);
            SelectBtn.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

