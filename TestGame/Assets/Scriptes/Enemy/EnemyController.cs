using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour {

    [SerializeField] private EnemyModel _em;//Enemy Model
    [SerializeField] private EnemyView _ev;//Enemy View                                                         

    //Set Difficulty Level
    public void SetDifficultyLevel(int idDL) {

        _em.IdDifficultyLevel = idDL;

    }

    //Get Difficulty Level
    public int GetDifficultyLevel() {

        return _em.IdDifficultyLevel;

    }

    //Get Enemy Info Object
    public EnemyInfoController GetEnemyInfoObject() {

        return _ev.ObjectEnemyInfo;

    }

    //Set Value IsDie
    public void SetValueIsDie(bool isDie) {

        _em.IsDie = isDie;

    }

    //Get Value IsDie
    public bool GetValueIsDie() {

        return _em.IsDie;

    }

    //Play Sound Died
    public void PlaySoundDied() {

        _ev.AudioSorceEnemy.PlayOneShot(_em.DiedEffect);

    }

    //Play Sound Gun
    public void PlaySoundGun() {

        _ev.AudioSorceEnemy.PlayOneShot(_em.GunEffect);

    }

    //Show Gun Fire
    public void ShowGunFire() {

        if (_em.IsFire) {            

            PlaySoundGun();

            _ev.FireGun.SetActive(true);            

            if (_em.CoroutineFire == null) {

                _em.CoroutineFire = DeactivateFire();

                StartCoroutine(_em.CoroutineFire);

            } else {

                StopCoroutine(_em.CoroutineFire);

                _em.CoroutineFire = DeactivateFire();

                StartCoroutine(_em.CoroutineFire);

            }

        } else {
            
            _ev.FireGun.SetActive(false);

            StopCoroutine(_em.CoroutineFire);

            _em.CoroutineFire = null;                         

        }

    }

    //Reset Enemy Type
    public void ResetEnemyType() {

        _ev.PlayerType[_em.PlayerTypeStatus].SetActive(false);

    }

    //Set Enemy Type
    public void SetPlayerType(int idType) {

        ResetEnemyType();

        _em.PlayerTypeStatus = idType;
        _ev.PlayerType[idType].SetActive(true);
        _ev.AnimController = _ev.PlayerType[idType].GetComponent<Animator>();

    }

    //Check Enemy Type
    public int CheckPlayerType() {

        return _em.PlayerTypeStatus;

    }

    //Change Life Count
    public void ChangeLifeCount(float count) {

        _ev.ObjectEnemyInfo.ChangeLifeCount(count);        

    }

    //Get Life Count
    public float GetLifeCount() {

        return _ev.ObjectEnemyInfo.GetLifeCount();

    }

    //Set Bonus Panel Property
    public void SetBonusPanelProperty(BonusPanelController bonusPanel) {

        _ev.PanelBonus = bonusPanel;

    }

    //Get Bonus Panel Property
    public BonusPanelController GetBonusPanelProperty() {

        return _ev.PanelBonus;

    }      

    //Set Traget 
    public void SetTraget(GameObject target) {

        _ev.Target = target;

    }

    //Create Bonus
    public void CreateBonus() {
        
        if (_ev.ObjCreatedBonus==null) {

            _ev.ObjCreatedBonus = Instantiate(_ev.PrefubBonus, transform.position, Quaternion.identity);

            _ev.ObjCreatedBonus.SetIdBonus(Random.Range(0, 6));

            _ev.ObjCreatedBonus.SetSpriteBonus(_ev.ObjCreatedBonus.GetIdBonus());

            _ev.ObjCreatedBonus.SetBonusPanelProperty(GetBonusPanelProperty());

            _ev.ObjCreatedBonus.SetIdDifficultyLevel(GetDifficultyLevel());

            _ev.ObjCreatedBonus.TransformBonus(_ev.Target);

            _ev.ObjectEnemyInfo.DeleteEnemyInfo();

            StartCoroutine(WaitAndDestroyEnemy());

        }

    }

    //Deactive Coroutine Gun
    public void DeactiveCoroutine() {

        if (_ev!.AnimController.GetBool("IsIdle")) {

            _em.IsFire = false;

        }

    }

    //Stop All Coroutine Enemy
    public void StopAllCoroutineEnemy() {

        if (_em.CoroutineFire != null) {

            StopCoroutine(_em.CoroutineFire);

        }

    }
   
   //Set Property Panel Indicator Enemy Life
   public void SetPropertyPanelIndicatorEnemyLife(GameObject panelIndicatorEnemyLife) {

        _ev.PanelInidicatorEnemyLife = panelIndicatorEnemyLife;

   }

    //Get Value Is Can Shoot
    public bool GetValueIsCanShoot() {

        return _em.IsCanShoot;

    }    

    void Update() {

        if (_ev.Target.gameObject != null) {

            _em.CalcDistanceValue = Vector3.Distance(transform.position, _ev.Target.transform.position);

        }

        if (_em.CalcDistanceValue > _em.MaxDistance) {

            _em.IsCanShoot = false;

            if (!_ev.AnimController.GetBool("IsWalk")) {

                _ev.AnimController.SetBool("IsIdle", false);
                _ev.AnimController.SetBool("IsWalk", true);                
                _em.IsFire = false;

                SetPlayerType(0);

            }

            if (transform.position.x > _ev.Target.transform.position.x) {

                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);

            } else {

                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            }            

            transform.position = Vector3.MoveTowards(transform.position, _ev.Target.transform.position, _em.Speed * Time.fixedDeltaTime);

            transform.position = new Vector3(transform.position.x, _ev.Target.transform.position.y, _ev.Target.transform.position.z);

        } else {

            _em.IsCanShoot = true;

            if (!_em.IsHaveIndicator) {

                _em.IsHaveIndicator = true;

                _ev.ObjectEnemyInfo = Instantiate(_ev.PrefubEnemyInfo, _ev.PanelInidicatorEnemyLife.transform);

                _ev.ObjectEnemyInfo.SetEnemySprite();
                
            }

            if (!_ev.AnimController.GetBool("IsIdle")) {

                SetPlayerType(1);

                _ev.AnimController.SetBool("IsWalk", false);
                _ev.AnimController.SetBool("IsIdle", true);

                _em.IsFire = true;
                
                ShowGunFire();

            }            

        }      

    }

    //Set Property Object Menu
    public void SetPropertyObjectMenu(GameObject objectMenu) {

        _ev.ObjectMenu = objectMenu;

    }

    //Get Property Object Menu
    public GameObject GetPropertyObjectMenu() {

        return _ev.ObjectMenu;

    }

    //Set Property Player
    public void SetPropertyPlayer(PlayerController player) {

        _ev.Player = player;

    }

    //Get Player Property
    public PlayerController GetPlayerProperty() {

        return _ev.Player;

    }

    public void OnDestroy() {

        if (_ev.ObjectEnemyInfo != null) {

            Destroy(_ev.ObjectEnemyInfo.gameObject);

        }

        if (_em.CoroutineFire != null) {

            StopCoroutine(_em.CoroutineFire);
            _em.CoroutineFire = null;

        }       

    }

    //IEnumerator Wait And Destroy Enemy
    IEnumerator WaitAndDestroyEnemy() {

        StopAllCoroutineEnemy();

        yield return new WaitForSeconds(0.5f);       

        Destroy(gameObject);

    }

    //Coroutine De Active Fire
    IEnumerator DeactivateFire() {

        var obj = Instantiate(_ev.PrefubBullet, _ev.BulletPosition.transform.position, Quaternion.Euler(transform.eulerAngles));

        obj.SetEnemyValue(this);

        obj.SetValueIsEnemyBullet(true);

        obj.Shoot(_ev.Target);

        yield return new WaitForSeconds(0.2f);

        _ev.FireGun.SetActive(false);

        yield return new WaitForSeconds(0.2f);

        ShowGunFire();

    }

}
