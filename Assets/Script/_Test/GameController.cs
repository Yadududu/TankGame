using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using complete;
using UnityEngine.UI;

namespace LMJ {

    public enum State {
        GeneralMode,
        TankMode,
        PlaneMode,
        TurretMode,
    }

    public class GameController : MonoBehaviour {

        [Header("UI")]
        //public GameObject gameOverUI;
        public GameObject warningUI;
        public Button tankBtn;
        public Button planeBtn;
        public Button turretBtn;

        public UnityEvent onGameStart;
        public UnityEvent onGameOver;

        private Transform _EnemyLifeSpot1;
        private Transform _EnemyLifeSpot2;
        private GameObject _PlayerInstance;
        private State _State = State.GeneralMode;
        private CameraController _CameraController;
        private Mesh _Mesh;
        private Material _Material;
        private BtnStore _Btn;
        private BtnStore _LastBtn;
        private bool _DoubleBullet;


        private void Start() {
            _CameraController = Camera.main.GetComponent<CameraController>();
            _EnemyLifeSpot1 = transform.Find("CreateEnemy (1)");
            _EnemyLifeSpot2 = transform.Find("CreateEnemy (2)");
        }
        private void Update() {
            //CameraControl();
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (_State != State.GeneralMode) {
                    warningUI.SetActive(true);
                }
            }
            if (Input.GetKeyDown(KeyCode.Q)) {
                if (_State == State.TankMode) {
                    CameraMode cm = _CameraController.GetCameraMode() == CameraMode.Camera2D ? CameraMode.Tank : CameraMode.Camera2D;
                    _CameraController.SetCameraMode(cm);
                } else if (_State == State.PlaneMode) {
                    CameraMode cm = _CameraController.GetCameraMode() == CameraMode.Camera2D ? CameraMode.Turret : CameraMode.Camera2D;
                    _CameraController.SetCameraMode(cm);
                }
            }
        }
        public void PlayTank() {
            _State = State.TankMode;
            onGameStart.Invoke();
            _PlayerInstance = ObjectPoolManager.Instance.GetGameObject("TankPool", new Vector3(100, 1.09f, 40), Quaternion.identity, 0);
            EnemyLifeSpotControl(true);
            _PlayerInstance.GetComponent<PlayerHealth>().onDead.AddListener(Over);
            ScoreSystem.Get.Init();
            _PlayerInstance.GetComponent<Player>().ChangeModel(_Mesh, _Material);
            _PlayerInstance.GetComponent<PlayerAttack>().SetDoubleBullet(_DoubleBullet);
            _CameraController.SetCameraMode(CameraMode.Camera2D, _PlayerInstance);
        }
        public void PlayPlane() {
            _State = State.PlaneMode;
            onGameStart.Invoke();
            _PlayerInstance = ObjectPoolManager.Instance.GetGameObject("PlanePool", new Vector3(73.2f, 5.8f, 45), Quaternion.identity, 0);
            EnemyLifeSpotControl(true);
            _PlayerInstance.GetComponent<PlaneHealth>().onDead.AddListener(Over);
            ScoreSystem.Get.Init();
            _PlayerInstance.GetComponent<Player>().ChangeModel(_Mesh, _Material);
            _PlayerInstance.GetComponent<PlaneAttack>().SetDoubleBullet(_DoubleBullet);
            _CameraController.SetCameraMode(CameraMode.Plane, _PlayerInstance);
        }
        public void PlayTurret() {
            _State = State.TurretMode;
            onGameStart.Invoke();
            _PlayerInstance = ObjectPoolManager.Instance.GetGameObject("TurretPool", new Vector3(91.6f, 0.03f, 88.2f), Quaternion.identity, 0);
            EnemyLifeSpotControl(true);
            _PlayerInstance.GetComponent<PlayerHealth>().onDead.AddListener(Over);
            ScoreSystem.Get.Init();
            _CameraController.SetCameraMode(CameraMode.Turret, _PlayerInstance);
        }
        private void EnemyLifeSpotControl(bool live) {
            if (_EnemyLifeSpot1 != null) _EnemyLifeSpot1.gameObject.SetActive(live);
            if (_EnemyLifeSpot2 != null) _EnemyLifeSpot2.gameObject.SetActive(live);
        }
        private void Over() {
            switch (_State) {
                case State.TankMode:
                    _PlayerInstance.GetComponent<PlayerMove>().init();
                    _PlayerInstance.GetComponent<PlayerHealth>().onDead.RemoveListener(Over);
                    break;
                case State.PlaneMode:
                    _PlayerInstance.GetComponent<PlaneHealth>().onDead.RemoveListener(Over);
                    break;
                case State.TurretMode:
                    _PlayerInstance.GetComponent<PlayerHealth>().onDead.RemoveListener(Over);
                    break;
            }
            _CameraController.SetCameraMode(CameraMode.Camera2D);
            onGameOver.Invoke();
            EnemyLifeSpotControl(false);
            GameOver.Get.SetRestartBtn(_State, this);
            GameOver.Get.gameObject.SetActive(true);
            _State = State.GeneralMode;
        }
        public void BackMenu() {
            if (_State == State.TankMode) {
                _PlayerInstance.GetComponent<PlayerMove>().init();
                _PlayerInstance.GetComponent<PlayerHealth>().onDead.RemoveListener(Over);
            }
            _State = State.GeneralMode;
            _CameraController.SetCameraMode(CameraMode.Camera2D);
            EnemyLifeSpotControl(false);
            _PlayerInstance.GetComponent<ObjectInfo>().RemoveGameObject();
        }
        public void ChangePlayerModel(Mesh setMesh, Material setMeterial,bool doubleBullet, BtnStore btn) {
            _Mesh = setMesh;
            _Material = setMeterial;
            _DoubleBullet = doubleBullet;
            //判断是否第一次按下按钮
            if (_Btn != null) _LastBtn = _Btn;
            _Btn = btn;
            _Btn.btnSelect.interactable = false;
            if (_LastBtn != null) {
                _LastBtn.btnSelect.interactable = true;
                _LastBtn.selectKeyDownSign = false;
            }
        }
    }
}
