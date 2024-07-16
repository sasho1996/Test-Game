using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour {

    public AudioSource audioSourcePlayer;//Audio Source Player

    public CharacterController controller;//Character Controller

    public FixedJoystick joystick;//Fixed Joystick

    public GameObject[] PlayerType;//0:Idl, 1:WithGun, 2:WithAutomatic
    public GameObject[] FireGunType;//0: Fire gun, 1:Fire Automatic

    public Animator AnimController;//Animator

    public GameObject IndicatorLife;//Health Bar Controller

    public GameObject FireGun;//Object Fire Gun

    public GameObject[] BulletesPosition;//Bulletes Position 0: Gun, 1: Automatic

    public GameObject ObjectMenu;//Object Menu

    public BulletController[] PrefubesBullet;//Prefubes Bullet 0: Gun, 1: Automatic

    public List<EnemyController> Targetes;//Targetes

    public Image HealthBar;//Image Health Bar

    public GameObject PlayerStartPosition;//Player Start Position

    public LevelController LC;//Level Controller

    public Text TitleCountEnemy;//Title Count Enemy

}
