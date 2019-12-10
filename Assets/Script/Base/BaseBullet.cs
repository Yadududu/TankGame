using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour {

	public ItemData ItemData;
    public GameObject Effect;

	private float BulletSpeed;
    private float Move;

	// Use this for initialization
	void Start () {
		BulletSpeed = ItemData.PlayerBulletSpeed;
        Move = BulletSpeed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.forward * Move);
	}
}
