using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace complete {
    public class PlayerMove : BaseMove {

        //public ItemData ItemData;
        //public GameObject Camera3D;
        //public GameObject Camera3DTransform;

        

        private const int HERO_UP = 0;
        private const int HERO_RIGHT = 1;
        private const int HERO_DOWN = 2;
        private const int HERO_LEFT = 3;

        // private float Speed;
        private bool _mode3D = false;
        private int _state = 0;
        private Vector3 _playerRotation;
        private float _moveHorizontal;
        private float _moveVertical;


        public void init() {
            SetRotation(HERO_UP);
            _mode3D = false;
            transform.rotation = Quaternion.Euler(0.0f, _playerRotation.y, 0.0f);
        }
        void Update() {
            Speed = ItemData.PlayerMoveSpeed;
            _moveHorizontal = Input.GetAxis("Horizontal");
            _moveVertical = Input.GetAxis("Vertical");
            MoveMethod();

            if (Input.GetKeyDown(KeyCode.Q)) {
                SetMode();
            }
        }
        public void SetMode() {
            if (_mode3D == true) {
                _mode3D = false;
                transform.rotation = Quaternion.Euler(0.0f, _playerRotation.y, 0.0f);
            } else {
                _mode3D = true;
                _playerRotation = transform.localEulerAngles;
            }
        }

        public override void MoveMethod(){
            if (_mode3D == true) {

                Vector3 move = new Vector3(0f, 0f, _moveVertical);
                Vector3 rota = new Vector3(0f, _moveHorizontal, 0f);

                transform.Translate(move * Time.deltaTime * Speed);
                gameObject.transform.Rotate(rota * Time.deltaTime * 50);

            } else {

                if (_moveHorizontal == 1) {
                    SetRotation(HERO_RIGHT);
                } else if (_moveHorizontal == -1) {
                    SetRotation(HERO_LEFT);
                } else if (_moveVertical == 1) {
                    SetRotation(HERO_UP);
                } else if (_moveVertical == -1) {
                    SetRotation(HERO_DOWN);
                }
            }
        }

        void SetRotation(int newState) {
            int rotateValue = (newState - _state) * 90;
            Vector3 transformValue = new Vector3();

            switch (newState) {
                case HERO_UP:
                    transformValue = Vector3.forward * Time.deltaTime;
                    break;
                case HERO_DOWN:
                    transformValue = Vector3.back * Time.deltaTime;
                    break;
                case HERO_LEFT:
                    transformValue = Vector3.left * Time.deltaTime;
                    break;
                case HERO_RIGHT:
                    transformValue = Vector3.right * Time.deltaTime;
                    break;
            }

            transform.Rotate(Vector3.up, rotateValue);
            transform.Translate(transformValue * Speed, Space.World);
            _state = newState;
        }

        //void Start3DPattern() {

        //    PlayerRotation = gameObject.transform.localEulerAngles;

        //    Pattern3D = true;
        //    // Camera3D.GetComponent<Tank3Dcamera>().SetCameraTransform(Camera3DTransform);
        //    // Camera3D.GetComponent<Tank3Dcamera>().RealTime = true;
        //    // Camera3D.GetComponent<AudioListener>().enabled = true;
        //    // Camera3D.GetComponent<Camera>().enabled = true;
        //    GameSystem.m_GameControl.GetComponent<GameControl>().Set3DCamera(true ,true ,gameObject);
        //    GameSystem.m_GameControl.GetComponent<GameControl>().SetMainCamera(false);
        //}
        //void Close3DPattern() {

        //    gameObject.transform.rotation = Quaternion.Euler(0.0f, PlayerRotation.y, 0.0f);

        //    Pattern3D = false;
        //    GameSystem.m_GameControl.GetComponent<GameControl>().SetMainCamera(true);
        //    GameSystem.m_GameControl.GetComponent<GameControl>().Set3DCamera(false);
        //    // Camera3D.GetComponent<AudioListener>().enabled = false;
        //    // Camera3D.GetComponent<Camera>().enabled = false;

        //}
    }
}

