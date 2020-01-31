using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour {

	public SystemData systemData;

    protected ObjectInfo _ObjectInfo;
    protected int _BulletSpeed;
    
	protected virtual void Start () {
		_BulletSpeed = systemData.tankBulletSpeed;
        _ObjectInfo = GetComponent<ObjectInfo>();
	}
	
	protected void Update () {
		transform.Translate(Vector3.forward * _BulletSpeed * Time.deltaTime);
	}
    protected virtual void OnCollisionEnter(Collision collision) {
        
        _ObjectInfo.RemoveGameObject();
        ObjectPoolManager.Instance.GetGameObject("BulletBoomEffectPool", transform.position, Quaternion.identity, 1);
    }
}
