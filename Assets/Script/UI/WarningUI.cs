using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMJ {
    public class WarningUI : MonoBehaviour {

        public static WarningUI Get { get; private set; }

        WarningUI() {
            Get = this;
        }
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                gameObject.SetActive(false);
            }
        }

    }
}

