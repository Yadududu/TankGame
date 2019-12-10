using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GameData",menuName="Data/GameData")]
public class GameData : ScriptableObject {

	public int TotalScore;
	public int CurrentScore;
    public int TankModelInit;
    public int TankModelPrice_1;
    public int TankModelPrice_2;
    public int TankModelPrice_3;
    public int TankModelPrice_4;
    public int PlaneModePrice;
    public int TurretPrice;

    public virtual void Use() { 
    
    }
}

