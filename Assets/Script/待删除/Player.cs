using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int PlayerHealth;
    public float MoveSpeed;
    public GameObject Bullet;
    public GameObject FireTransform;
    public GameObject FireTransform2;
    public GameObject FireTransform3;
    public GameObject FireEffect;
    public GameObject BoomEffect;
    

    public const int HERO_UP = 0;
    public const int HERO_RIGHT = 1;
    public const int HERO_DOWN = 2;
    public const int HERO_LEFT = 3;
    private int State = 0;
    public bool Pattern3D;
    public bool DoubleBullet;
    private Vector3 PlayerRotation;
    private GameObject GameControlStrip;


    // Use this for initialization
    void Start() {
        GameControlStrip = GameObject.FindGameObjectWithTag("GameControl");
        //HealthUI = GameObject.FindGameObjectWithTag("HealthUI");
        //HealthUI.GetComponent<Slider>().maxValue = PlayerHealth;
    }

    // Update is called once per frame
    void Update() {
        Vector3 playerV3;
        Vector3 playerRotation;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Pattern3D == true) {
            
            Vector3 move = new Vector3(0f, 0f, moveVertical);
            Vector3 rota = new Vector3(0f, moveHorizontal, 0f);

            transform.Translate(move * Time.deltaTime * MoveSpeed);
            gameObject.transform.Rotate(rota * Time.deltaTime * 50);

        } else {

            if (moveHorizontal == 1) {
                SetRotation(HERO_RIGHT);
            } else if (moveHorizontal == -1) {
                SetRotation(HERO_LEFT);
            } else if (moveVertical == 1) {
                SetRotation(HERO_UP);
            } else if (moveVertical == -1) {
                SetRotation(HERO_DOWN);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            if (Pattern3D == true) {
                Close3DPattern();
            } else {
                Start3DPattern();
            }
        }


        if (Input.GetKeyDown(KeyCode.Space)) {
            if (DoubleBullet == false) {
                playerV3 = FireTransform.gameObject.transform.position;
                Bullet.gameObject.transform.position = playerV3;

                playerRotation = gameObject.transform.localEulerAngles;
                Bullet.gameObject.transform.rotation = Quaternion.Euler(90.0f, playerRotation.y, 0.0f);

                playerV3 = FireTransform.gameObject.transform.position;
                FireEffect.gameObject.transform.position = playerV3;

                playerRotation = gameObject.transform.localEulerAngles;
                FireEffect.gameObject.transform.rotation = Quaternion.Euler(90.0f, playerRotation.y, 0.0f);

                Instantiate(Bullet);
                Instantiate(FireEffect);
            } else {
                playerV3 = FireTransform2.gameObject.transform.position;
                Bullet.gameObject.transform.position = playerV3;

                playerRotation = gameObject.transform.localEulerAngles;
                Bullet.gameObject.transform.rotation = Quaternion.Euler(90.0f, playerRotation.y, 0.0f);

                playerV3 = FireTransform2.gameObject.transform.position;
                FireEffect.gameObject.transform.position = playerV3;

                playerRotation = gameObject.transform.localEulerAngles;
                FireEffect.gameObject.transform.rotation = Quaternion.Euler(90.0f, playerRotation.y, 0.0f);

                Instantiate(Bullet);
                Instantiate(FireEffect);

                playerV3 = FireTransform3.gameObject.transform.position;
                Bullet.gameObject.transform.position = playerV3;

                playerRotation = gameObject.transform.localEulerAngles;
                Bullet.gameObject.transform.rotation = Quaternion.Euler(90.0f, playerRotation.y, 0.0f);

                playerV3 = FireTransform3.gameObject.transform.position;
                FireEffect.gameObject.transform.position = playerV3;

                playerRotation = gameObject.transform.localEulerAngles;
                FireEffect.gameObject.transform.rotation = Quaternion.Euler(90.0f, playerRotation.y, 0.0f);

                Instantiate(Bullet);
                Instantiate(FireEffect);
            }
            
        }

        if (PlayerHealth <= 0) {
            Destroy(gameObject);
            GameObject.Find("UI/Canvas/GameOver").SetActive(true);

            playerV3 = gameObject.transform.position;
            BoomEffect.gameObject.transform.position = playerV3;
            Instantiate(BoomEffect);
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
        transform.Translate(transformValue * MoveSpeed, Space.World);
        State = newState;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "EnemyBullet") {
            PlayerHealth--;
            //GameControlStrip.GetComponent<GameControl>().UpdatePlayHealth();
            Destroy(collision.gameObject);
        }
    }

    void Start3DPattern() {

        PlayerRotation = gameObject.transform.localEulerAngles;

        Pattern3D = true;
        print(Pattern3D);
        GameObject.FindGameObjectWithTag("Camera3D").GetComponent<AudioListener>().enabled = true;
        GameObject.FindGameObjectWithTag("Camera3D").GetComponent<Camera>().enabled = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>().enabled = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = false;

        
    }
    void Close3DPattern() {

        gameObject.transform.rotation = Quaternion.Euler(0.0f, PlayerRotation.y, 0.0f);

        Pattern3D = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>().enabled = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = true;
        GameObject.FindGameObjectWithTag("Camera3D").GetComponent<AudioListener>().enabled = false;
        GameObject.FindGameObjectWithTag("Camera3D").GetComponent<Camera>().enabled = false;

        
    }
}
