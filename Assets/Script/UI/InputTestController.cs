using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LMJ {
    public class InputTestController : MonoBehaviour {

        public static InputTestController Get { get; private set; }
        public GameObject inputUI;

        private string _Str;
        private InputField _Input;

        private InputTestController() {
            Get = this;
        }
        private void Start() {
            _Input = inputUI.GetComponent<InputField>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Return)) {
                if (inputUI.activeInHierarchy) {
                    inputUI.SetActive(false);
                    _Str = _Input.text;
                    _Input.text = "";
                    Orider(_Str);
                    Debug.Log(_Str);
                } else {
                    inputUI.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(inputUI);
                }
            }
        }
        private void Orider(string str) {
            if (str == "GiveMeScore") {
                ScoreSystem.Get.Add(300);
            }
        }
    }
}
    
