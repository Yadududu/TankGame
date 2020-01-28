using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class GameSystem : MonoBehaviour {

        [SerializeField]
        private GameObject GameControl;
        [SerializeField]
        private GameObject UIControl;

        private static GameSystem m_GameSystem;

        // Use this for initialization
        protected void Start() {
            //m_GameSystem = this;
            //Debug.Log("You call Start()");
        }

        protected void Awake() {
            m_GameSystem = this;
        }

        public static GameObject m_GameControl {
            get {
                return m_GameSystem.GameControl;
            }
        }

        public static GameObject m_UIControl {
            get {
                return m_GameSystem.UIControl;
            }
        }

        public static GameObject GetGameControl() {
            return m_GameSystem.GameControl;
        }

        public static GameObject GetUIControl() {
            return m_GameSystem.UIControl;
        }
    }
}

