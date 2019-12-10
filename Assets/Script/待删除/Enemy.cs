using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int EnemyHealth = 2;
    public float AttackDistance = 4f;
    public float EnemyTankSpeed = 5f;
    public GameObject Bullet;
    public float FireRate = 1.0F;
    public GameObject FireTransform;
    public GameObject FireEffect;
    public GameObject BoomEffect;

    private float AttackTime = 1;   //设置定时器时间 
    private float AttackCounter = 0; //计时器变量
    private bool IsTurn = false;
    private float NextFire = 0.0F;
    private RaycastHit Hit;
    private Ray Ray;
    //private GameControl GameControl;
    CapsuleCollider EnemyTankCollider;

	// Use this for initialization
	void Start () {
        EnemyTankCollider = GetComponent<CapsuleCollider>();
        //GameControl = GameObject.Find("GameControl").GetComponent<GameControl>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerV3;
        Vector3 playerRotation;

        if (EnemyHealth <= 0) {
            Destroy(gameObject);
            //GameControl.num += 1;
            //GameControl.SetScoreText();

            playerV3 = gameObject.transform.position;
            playerV3[1]=0;
            BoomEffect.gameObject.transform.position = playerV3;
            Instantiate(BoomEffect);
        }

        Ray = new Ray(transform.position + new Vector3(0f, EnemyTankCollider.center.y, 0f), transform.forward);
        Debug.DrawRay(Ray.origin, Ray.direction * AttackDistance, Color.red);

        if (Physics.Raycast(Ray, out Hit)) {
            if (Hit.distance < AttackDistance) {
                if (Hit.collider.gameObject.tag == "Player") {
                    playerV3 = FireTransform.gameObject.transform.position;
                    Bullet.gameObject.transform.position = playerV3;

                    playerRotation = gameObject.transform.localEulerAngles;
                    Bullet.gameObject.transform.rotation = Quaternion.Euler(90.0f, playerRotation.y, 0.0f);

                    playerV3 = FireTransform.gameObject.transform.position;
                    FireEffect.gameObject.transform.position = playerV3;

                    playerRotation = gameObject.transform.localEulerAngles;
                    FireEffect.gameObject.transform.rotation = Quaternion.Euler(90.0f, playerRotation.y, 0.0f);

                    if (Time.time > NextFire){
                        NextFire = Time.time + FireRate;
                        Instantiate(Bullet);
                        Instantiate(FireEffect);
                    }
                }
            }
        }

        gameObject.transform.Translate(Vector3.forward * EnemyTankSpeed * Time.deltaTime);

        if (IsTurn == true) { 
            AttackCounter += Time.deltaTime;
            if (AttackCounter >AttackTime){//定时器功能实现 
                if (IsTurn == true) {
                    turn();
                }
                AttackCounter = 0;
            }
        }

	}
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Bullet") {
            EnemyHealth--;
            Destroy(collision.gameObject);
        }
        IsTurn = true;
        turn();
    }
    void OnCollisionExit() {
        IsTurn = false;
    }

    void turn() {
        Vector3 playerRotation = gameObject.transform.localEulerAngles;
        int num;
        while (true) {
            num = Random.Range(1, 5);
            num = num * 90;
            if (playerRotation.y != num) {
                break;
            }
        }
        gameObject.transform.localEulerAngles = new Vector3(0.0f, num, 0.0f); 
    }
}
