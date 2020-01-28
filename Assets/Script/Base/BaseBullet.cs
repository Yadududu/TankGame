using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour {

	public ItemData ItemData;
    //public GameObject Effect;

    protected ObjectInfo _ObjectInfo;

    private float _BulletSpeed;
    private float _Move;
    

	// Use this for initialization
	void Start () {
		_BulletSpeed = ItemData.PlayerBulletSpeed;
        _Move = _BulletSpeed * Time.deltaTime;
        _ObjectInfo = GetComponent<ObjectInfo>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.forward * _Move);
	}
}
