using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyModel : MonoBehaviour {

    public AudioClip DiedEffect;//Died Effect

    public AudioClip GunEffect;//Gun Effect

    public IEnumerator CoroutineFire;//Coroutine Fire

    public int PlayerTypeStatus = 0;//Enemy  Type Status

    public int IdDifficultyLevel = 0;//Id Difficulty Level

    public float Speed = 3;//Speed

    public float CalcDistanceValue = 0.0f;//Calc Distance Value

    public float MaxDistance = 3.0f;//Max Distance

    public bool IsFire = false;//Check Is Fire

    public bool IsDie = false;//Check Is Die    

    public bool IsHaveIndicator = false;//Check Is Indicator Show

    public bool IsCanShoot=false;//Is Can Shoot

}
