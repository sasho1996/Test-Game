using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {

    public AudioClip DiedEffect;//Died Effect

    public AudioClip GunEffect;//Gun Effect

    public AudioClip AK_47_Effect;//Ak 47 Effect

    public AudioClip AK_47_ChangeBoxEffect;//Ak 47 Change Box Effect

    public AudioClip Gun_ChangeBoxEffect;//Gun Change Box Effect

    public AudioClip Gun_EmptyBoxEffect;//Gun Empty Box Effect

    public AudioClip AK_47_EmptyBoxEffect;//AK_47 Empty Box Effect

    public float SpeedMove = 5.0f;//Speed Move

    public float MaxHealth = 100.0f;//Max Health

    public float HP = 100.0f;//Health Point

    public float CalcDistanceValue = 0.0f;//Calc Distance Value

    public float MaxDistance = 3.0f;//Max Distance

    public Vector3 Move;//Move

    public int PlayerTypeStatus=0;//Player  Type Status

    public IEnumerator CoroutineFire;//Coroutine Fire

    public bool IsFire = false;//Check Is Fire

    public int CountTargetes = 3;//Count Targetes

    public int IdTargetes = 0;//Id Targetes    

    public bool IsEndGame = false;//Check Is End Game

    public bool IsLose = false;//Check Is Lose

}
