using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace complete {
    public class PlayerMove : BaseMove {

        // public ItemData ItemData;
        public GameObject Camera3D;
        public GameObject Camera3DTransform;
       
        private const int HERO_UP = 0;
        private const int HERO_RIGHT = 1;
        private const int HERO_DOWN = 2;
        private const int HERO_LEFT = 3;

        // private float Speed;
        private int State = 0;
        private Vector3 PlayerRotation;
        private bool Pattern3D = false;
        private float MoveHorizontal;
        private float MoveVertical;
        


        void Update() {
            Speed = ItemData.PlayerMoveSpeed;
            MoveHorizontal = Input.GetAxis("Horizontal");
            MoveVertical = Input.GetAxis("Vertical");
            MoveMethod();

            if (Input.GetKeyDown(KeyCode.Q)) {
                if (Pattern3D == true) {
                    Close3DPattern();
                } else {
                    Start3DPattern();
                }
            }
        }

        public override void MoveMethod(){
            if (Pattern3D == true) {

                Vector3 move = new Vector3(0f, 0f, MoveVertical);
                Vector3 rota = new Vector3(0f, MoveHorizontal, 0f);

                transform.Translate(move * Time.deltaTime * Speed);
                gameObject.transform.Rotate(rota * Time.deltaTime * 50);

            } else {

                if (MoveHorizontal == 1) {
                    SetRotation(HERO_RIGHT);
                } else if (MoveHorizontal == -1) {
                    SetRotation(HERO_LEFT);
                } else if (MoveVertical == 1) {
                    SetRotation(HERO_UP);
                } else if (MoveVertical == -1) {
                    SetRotation(HERO_DOWN);
                }
            }
        }

        void SetRotation(int newState) {
            int rotateValue = (newState - State) * 90;
            Vector3 transformValue = new Vector3();

            switch (newState) {
                case HERO_UP:
                    transformValue = Vector3.forward * Time.deltaTime;
                    break;
                case HERO_DOWN:
                    transformValue = (-Vector3.forward) * Time.deltaTime;
                    break;
                case HERO_LEFT:
                    transformValue = Vector3.left * Time.deltaTime;
                    break;
                case HERO_RIGHT:
                    transformValue = (-Vector3.left) * Time.deltaTime;
                    break;
            }

            transform.Rotate(Vector3.up, rotateValue);
            transform.Translate(transformValue * Speed, Space.World);
            State = newState;
        }

        void Start3DPattern() {

            PlayerRotation = gameObject.transform.localEulerAngles;

            Pattern3D = true;
            // Camera3D.GetComponent<Tank3Dcamera>().SetCameraTransform(Camera3DTransform);
            // Camera3D.GetComponent<Tank3Dcamera>().RealTime = true;
            // Camera3D.GetComponent<AudioListener>().enabled = true;
            // Camera3D.GetComponent<Camera>().enabled = true;
            GameSystem.m_GameControl.GetComponent<GameControl>().Set3DCamera(true ,true ,Camera3DTransform);
            GameSystem.m_GameControl.GetComponent<GameControl>().SetMainCamera(false);
        }
        void Close3DPattern() {

            gameObject.transform.rotation = Quaternion.Euler(0.0f, PlayerRotation.y, 0.0f);

            Pattern3D = false;
            GameSystem.m_GameControl.GetComponent<GameControl>().SetMainCamera(true);
            GameSystem.m_GameControl.GetComponent<GameControl>().Set3DCamera(false);
            // Camera3D.GetComponent<AudioListener>().enabled = false;
            // Camera3D.GetComponent<Camera>().enabled = false;

        }
    }
}

