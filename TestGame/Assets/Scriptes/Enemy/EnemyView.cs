using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour {

    public AudioSource AudioSorceEnemy;//Audio Source Enemy

    public GameObject Target;//Object Target

    public GameObject[] PlayerType;//0:Walk, 1:WithGun

    public GameObject FireGun;//Object Fire Gun

    public Animator AnimController;//Animator     

    public BulletController PrefubBullet;//Prefub Bullet

    public GameObject BulletPosition;//Bullet Position

    public GameObject PanelInidicatorEnemyLife;//Object Panel Indicator Enemy Life

    public EnemyInfoController PrefubEnemyInfo;//Prefub Enemy Info                                                   

    public EnemyInfoController ObjectEnemyInfo;//Object Enemy Info

    public ControllerBonus PrefubBonus;//Prefub Bonus

    public ControllerBonus ObjCreatedBonus;//Object Created Bonus

    public BonusPanelController PanelBonus;//Bonus Panel Controller

    public GameObject ObjectMenu;//Object Menu

    public PlayerController Player;//Object Player

}
