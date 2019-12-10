using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace complete {
    public class MainCamera : MonoBehaviour {

        public GameControl GameControl;

        private GameObject PlayerPrefab;



        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update() {
            Move();
        }

        void Move(){
            if (GameControl.PlayerPrefabInstantiate!=null) {
                gameObject.transform.position = GameControl.PlayerPrefabInstantiate.transform.position + new Vector3(0.0f, 50.0f, 0.0f);
            }
            

            if (gameObject.transform.position.x >= 107) {
                gameObject.transform.position = new Vector3(107.0f, gameObject.transform.position.y, gameObject.transform.position.z);
            } else if (gameObject.transform.position.x <= 41) {
                gameObject.transform.position = new Vector3(41.0f, gameObject.transform.position.y, gameObject.transform.position.z);
            } 
            if (gameObject.transform.position.z <= 22) {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 22.0f);
            } else if (gameObject.transform.position.z >= 120) {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 120.0f);
            }
        }
    }
}

