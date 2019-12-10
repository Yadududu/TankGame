using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName="Data/Item")]
public class ItemData : ScriptableObject {

	[Header("Tank")]
	public float PlayerHealthValue;
	public float PlayerBulletSpeed;
	public float PlayerMoveSpeed;
    
	[Header("Enemy")]
	public float EnemyHealthValue;
	public float EnemyBulletSpeed;
	public float EnemyMoveSpeed;
	public float EnemyAttackDistance;
	public float EnemyFireRate;
	public float EnemyCreateRate;

	[Header("Turret")]
	public float TurretFireRate;
	public float TurretSpeed;

	[Header("Plane")]
	public float PlaneHealthValue;
	public float PlaneUpForce;
	public float PlaneTailUpForce;
	public float PlaneSpeed;
	public float Plane_W_LiftSpeed;
	public float Plane_S_LiftSpeed;
	public float Plane_A_LiftSpeed;
	public float Plane_D_LiftSpeed;

    public virtual void Use() { 
    
    }
}

