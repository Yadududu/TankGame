using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace complete {
    public class GameOver : MonoBehaviour {

        public GameObject Grid;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        void OnEnable() {
            StartCoroutine(Wait());
            
        }
        IEnumerator Wait(){
            GameSystem.m_UIControl.GetComponent<UIControl>().SendEvent("GameOver");
			yield return new WaitForSeconds(1);
			InitCamera();
		}
        public void InitCamera(){
            // MainCamera.GetComponent<AudioListener>().enabled = true;
            // MainCamera.GetComponent<Camera>().enabled = true;
            // Camera3D.GetComponent<AudioListener>().enabled = false;
            // Camera3D.GetComponent<Camera>().enabled = false;
            // PlaneCamera.GetComponent<AudioListener>().enabled = false;
            // PlaneCamera.GetComponent<Camera>().enabled = false;
            GameSystem.m_GameControl.GetComponent<GameControl>().SetMainCamera(true);
            GameSystem.m_GameControl.GetComponent<GameControl>().SetPlaneCamera(false);
            GameSystem.m_GameControl.GetComponent<GameControl>().Set3DCamera(false);
            Grid.SetActive(false);
            
        }
    }
}

