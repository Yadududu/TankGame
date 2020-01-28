using complete;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

namespace complete {
    public class GameControl : MonoBehaviour {

        [Header("Data")]
        public ItemData ItemData;

        
        [HideInInspector]
        public UIControl UIControl;

        [Header("GameObject")]
        public GameObject PlayerPrefab;
        public GameObject CreateEnemy;
        public GameObject MainCamera;
        public GameObject PlaneCamera;
        public GameObject ThreeDCamera;
        public GameObject Turret;
        public GameObject Plane;
        public GameObject[] Grid;

        [Header("Transform")]
        public Transform LifePoint;
        public Transform CreateEnemyPoint1;
        public Transform CreateEnemyPoint2;
        public Transform CreateTurretPoint;
        public Transform CreatePlanePoint;

        [Header("Stripts")]
        public FollowCameraPoint FollowCameraPoint;

        [Header("Audio")]
        public AudioSource BackGroundMusic;
        public AudioSource MenuMusic;
        
        private GameObject CreateEnemyObject1;
        private GameObject CreateEnemyObject2;

        private string CurSelect;

        [HideInInspector]
        public GameObject PlayerPrefabInstantiate;

        [HideInInspector]
        public bool PlayingGameSign;

        // Use this for initialization
        void Start() {

            UIControl = GameSystem.m_UIControl.GetComponent<UIControl>();
            UIControl.StoreUI.SelectTankModel(0);
            SetTankDoubleBullet(false);
            UIControl.ShowMenuUI();
            FollowCameraPoint.SetFollowCamera(MainCamera);

        }

        // Update is called once per frame
        void Update() {
            if(Input.GetKeyDown(KeyCode.Escape)){
                if(PlayingGameSign == true){
                    UIControl.ShowWarningUI();
                }
            }
            if(Input.GetKey(KeyCode.RightControl) & Input.GetKey(KeyCode.Slash)){
                UIControl.InputTextUI.SetActive(true);
                UIControl.InputTextUI.GetComponent<InputText>().inputField.ActivateInputField();
            }
        }

        public void SendEvent(string s) {
            

            if (s == "TankDemo") {
                PlayingGameSign = true;
                CurSelect = s;

                CreatePlayerMethod(PlayerPrefab,LifePoint);
                //PlayerPrefabInstantiate.GetComponent<PlayerMove>().Camera3D = ThreeDCamera;
                CreateEnemyMethod();

                UIControl.SetHealthUIMaxValue(ItemData.PlayerHealthValue);
                UIControl.SetHealthUIValue(ItemData.PlayerHealthValue);
                UIControl.BrushScore();
                UIControl.HideMenuUI();
                UIControl.HideGameOverUI();
                BackGroundMusic.Play();
                MenuMusic.Stop();
            }

            if (s == "TurretDemo") {
                PlayingGameSign = true;
                CurSelect = s;

                CreatePlayerMethod(Turret,CreateTurretPoint);
                PlayerPrefabInstantiate.GetComponent<TurretMove>().Camera3D = ThreeDCamera;
                UIControl.InputTextUI.GetComponent<InputText>().SetTurret(PlayerPrefabInstantiate);
                UIControl.InputTextUI.GetComponent<InputText>().SetActionAutoAttack(false);
                UIControl.InputTextUI.GetComponent<InputText>().Set3DCamera(ThreeDCamera);
                CreateEnemyMethod();

                UIControl.SetHealthUIMaxValue(ItemData.PlayerHealthValue);
                UIControl.SetHealthUIValue(ItemData.PlayerHealthValue);
                UIControl.BrushScore();
                UIControl.HideMenuUI();
                UIControl.HideGameOverUI();
                BackGroundMusic.Play();
                MenuMusic.Stop();
            }

            if (s == "PlaneDemo") {
                PlayingGameSign = true;
                CurSelect = s;

                CreatePlayerMethod(Plane,CreatePlanePoint);
                CreateEnemyMethod();

                // PlaneCamera.GetComponent<PlaneCamera>().SetFollowGameObject(PlayerPrefabInstantiate);
                PlaneCamera.GetComponent<AutoCam>().SetFollowGameObject(PlayerPrefabInstantiate);
                SetPlaneCamera(true); 
                SetMainCamera(false);
                for(int i=0;i<Grid.Length;i++){
                    if(i == 0){
                        Grid[i].SetActive(true);
                    }else{
                        Grid[i].SetActive(false);
                    }
                    
                }

                UIControl.SetHealthUIMaxValue(ItemData.PlaneHealthValue);
                UIControl.SetHealthUIValue(ItemData.PlaneHealthValue);
                UIControl.BrushScore();
                UIControl.HideMenuUI();
                UIControl.HideGameOverUI();
                BackGroundMusic.Play();
                MenuMusic.Stop();
            }

            if (s == "GameOver") {
                //Destroy(CreateEnemyPoint1.transform.GetChild(0).gameObject);
                //Destroy(CreateEnemyPoint2.transform.GetChild(0).gameObject);
                DestroyEnemyMethod();
                BackGroundMusic.Stop();
                MenuMusic.Play();
            }

            if(s == "Quit"){
                DestroyEnemyMethod();

                if (PlayerPrefabInstantiate != null) {
                    Destroy(PlayerPrefabInstantiate);
                }
                
                for(int i=0;i<Grid.Length;i++){
                    Grid[i].SetActive(false);
                }
                UIControl.HideWarningUI();
                UIControl.InitCamera();
                UIControl.ShowMenuUI();
                BackGroundMusic.Stop();
                MenuMusic.Play();
            }

            if (s == "Exit") {
                Application.Quit();
            }
        }

        void CreatePlayerMethod(GameObject m_gameObject,Transform CreatePlace){
            PlayerPrefabInstantiate = Instantiate(m_gameObject, CreatePlace.position, Quaternion.Euler(0.0f, CreatePlace.rotation.y, 0.0f));
        }
        void CreateEnemyMethod(){
            CreateEnemyObject1 = Instantiate(CreateEnemy, CreateEnemyPoint1.position, CreateEnemyPoint1.rotation, CreateEnemyPoint1);
            //CreateEnemyObject1.GetComponent<CreateEnemy>().SetLookAtPoint(FollowCameraPoint.gameObject);
            CreateEnemyObject2 = Instantiate(CreateEnemy, CreateEnemyPoint2.position, CreateEnemyPoint2.rotation, CreateEnemyPoint2);
            //CreateEnemyObject2.GetComponent<CreateEnemy>().SetLookAtPoint(FollowCameraPoint.gameObject);
        }
        void DestroyEnemyMethod(){
            if (CreateEnemyObject1 != null) {
                Destroy(CreateEnemyObject1);
            }
            if (CreateEnemyObject2 != null) {
                Destroy(CreateEnemyObject2);
            }
        }
        public void SetMainCamera(bool Action) { 
            if(Action){
                MainCamera.GetComponent<AudioListener>().enabled = true;
                MainCamera.GetComponent<Camera>().enabled = true;
                SetFollowCameraPoint(2);
            }else{
                MainCamera.GetComponent<AudioListener>().enabled = false;
                MainCamera.GetComponent<Camera>().enabled = false;
            }
        }
        public void SetPlaneCamera(bool Action) { 
            if(Action){
                PlaneCamera.GetComponent<AudioListener>().enabled = true;
                PlaneCamera.GetComponent<Camera>().enabled = true;
                SetFollowCameraPoint(1);
            }else{
                PlaneCamera.GetComponent<AudioListener>().enabled = false;
                PlaneCamera.GetComponent<Camera>().enabled = false;
            }
        }

        public void Set3DCamera(bool Action){
            if(Action){
                ThreeDCamera.GetComponent<AudioListener>().enabled = true;
                ThreeDCamera.GetComponent<Camera>().enabled = true;
                SetFollowCameraPoint(0);
            }else{
                ThreeDCamera.GetComponent<AudioListener>().enabled = false;
                ThreeDCamera.GetComponent<Camera>().enabled = false;
            }
        }
        public void Set3DCamera(bool Action ,bool RealTime ,GameObject SetCameraTransform) { 
            ThreeDCamera.GetComponent<ThreeDcamera>().SetCameraTransform(SetCameraTransform);

            if(Action){
                if(RealTime){
                    ThreeDCamera.GetComponent<ThreeDcamera>().RealTime = true;
                }else{
                    ThreeDCamera.GetComponent<ThreeDcamera>().RealTime = false;
                }
                ThreeDCamera.GetComponent<AudioListener>().enabled = true;
                ThreeDCamera.GetComponent<Camera>().enabled = true;
                SetFollowCameraPoint(0);
            }else{
                ThreeDCamera.GetComponent<AudioListener>().enabled = false;
                ThreeDCamera.GetComponent<Camera>().enabled = false;
            }
        }
        /// <summary>
        /// <param name="num">int=0 即FollowCameraPoint = ThreeDCamera.</param>
        /// <param name="num">int=1 即FollowCameraPoint = PlaneCamera.</param>
        /// <param name="num">int=2 即FollowCameraPoint = MainCamera.</param>
        /// </summary>
        public void SetFollowCameraPoint(int num){
            switch(num){
                case 0:FollowCameraPoint.SetFollowCamera(ThreeDCamera);break;
                case 1:FollowCameraPoint.SetFollowCamera(PlaneCamera);break;
                default:FollowCameraPoint.SetFollowCamera(MainCamera);break;
            }
                
        }

        public void Restart(){
            SendEvent(CurSelect);
        }
        public void SetTankDoubleBullet(bool b) {
            PlayerPrefab.GetComponent<PlayerAttack>().SetDoubleBullet(b);
        }
        public void SetPlaneDoubleBullet(bool b){
            Plane.GetComponent<PlaneAttack>().SetDoubleBullet(b);
        }
    }
}

