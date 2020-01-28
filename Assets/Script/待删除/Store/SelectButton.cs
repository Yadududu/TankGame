using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace complete {
    public class SelectButton : MonoBehaviour {

        public Store Store;
        public int num;

        private Button Btn;

        // Use this for initialization
        void Start() {
            Btn = gameObject.GetComponent<Button>();
            Btn.onClick.AddListener(TaskOnClick);
        }

        // Update is called once per frame
        void Update() {
            
        }

        void TaskOnClick() {
            Store.SelectBtn(num, Btn);
        }

    }
}

