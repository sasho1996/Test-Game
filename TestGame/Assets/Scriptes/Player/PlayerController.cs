using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [SerializeField] private PlayerView _pv;//Player View
    [SerializeField] private PlayerModel _pm;//Player Model         

    //Play Sound Gun
    public void PlaySoundGun() {

        _pv.audioSourcePlayer.PlayOneShot(_pm.GunEffect);

    }

    //Play Sound AK_47
    public void PlaySoundAK_47() {

        _pv.audioSourcePlayer.PlayOneShot(_pm.AK_47_Effect);

    }

    //Play Sound Change Box AK_47
    public void PlaySoundChangeBoxAK_47() {

        _pv.audioSourcePlayer.PlayOneShot(_pm.AK_47_ChangeBoxEffect);

    }

    //Play Sound Change Box Gun
    public void PlaySoundChangeBoxGun() {

        _pv.audioSourcePlayer.PlayOneShot(_pm.Gun_ChangeBoxEffect);

    }

    //Play Sound Empty Box Gun
    public void PlaySoundEmptyBoxGun() {

        _pv.audioSourcePlayer.PlayOneShot(_pm.Gun_EmptyBoxEffect);

    }

    //Play Sound Empty Box AK_47
    public void PlaySoundEmptyBoxAK_47() {

        _pv.audioSourcePlayer.PlayOneShot(_pm.AK_47_EmptyBoxEffect);

    }

    //Play Sound Player Die
    public void PlaySoundPlayerDie() {

        _pv.audioSourcePlayer.PlayOneShot(_pm.DiedEffect);

    }

    //Get Value Id Targetes
    public int GetValueIdTargets() {

        return _pm.IdTargetes;

    }

    //Get Targetes
    public List<EnemyController> GetTargetes() {

        return _pv.Targetes;

    }

    //Get Value Count Targetes
    public int GetValueCountTargets() {

        return _pm.CountTargetes;

    }
    //Reset Info Player
    public void ResetInfoPlayer() {

        if (_pv.PlayerStartPosition != null) {

            gameObject.transform.localPosition = new Vector3(_pv.PlayerStartPosition.transform.localPosition.x, _pv.PlayerStartPosition.transform.localPosition.y, _pv.PlayerStartPosition.transform.localPosition.z);

        }

        SetPlayerType(0);    

        StartCoroutine(WaitAndResetData());

    }


    //Set Title Count Enemy
    public void SetTitleCountEnemy(int countEnemy) {

        _pv.TitleCountEnemy.text = "" + countEnemy;

    }

    //Set Value Object Level Controller
    public void SetValueObjectLevelController(LevelController lc) {

        _pv.LC = lc;

    }   

    //Set Properties
    public void SetProperties(FixedJoystick joystick, GameObject objectMenu, GameObject playerStartPosition) {

        _pv.joystick = joystick;
        _pv.ObjectMenu = objectMenu;
        _pv.PlayerStartPosition = playerStartPosition;

    }

    //Clear Property Targetes
    public void ClearPropertyTargetes() {

        _pv.Targetes.Clear();

    }

    //Set Enemies Value
    public void SetEnemiesValues(EnemyController enemy) {

        _pv.Targetes.Add(enemy);

    }

    //Show next Target
    public void ShowNextTarget(){
        
        _pv.Targetes[_pm.IdTargetes].PlaySoundDied();

        _pm.IdTargetes++;

        SetTitleCountEnemy((_pm.CountTargetes-_pm.IdTargetes));

        if (_pm.IdTargetes != _pm.CountTargetes) {

            _pv.Targetes[_pm.IdTargetes].gameObject.SetActive(true);

        }

    }   

    //Show Gun Fire
    public void ShowGunFire(int idGunType) {

        if (_pm.IdTargetes != _pm.CountTargetes) {
            
            if (_pv.Targetes[_pm.IdTargetes].GetComponent<EnemyController>().GetValueIsCanShoot()) {

                _pv.FireGunType[idGunType - 1].SetActive(true);

                if (_pm.CoroutineFire == null) {

                    _pm.CoroutineFire = DeactivateFire(idGunType);

                    StartCoroutine(_pm.CoroutineFire);

                } else {

                    StopCoroutine(_pm.CoroutineFire);

                    _pm.CoroutineFire = DeactivateFire(idGunType);

                    StartCoroutine(_pm.CoroutineFire);

                }

            }

        }

    }

    //Set Property Title CountEnemy
    public void SetPropertyTitleCountEnemy(Text titleCountEnemy) {

        _pv.TitleCountEnemy = titleCountEnemy;

    }

    //Get Value Is Lose
    public bool GetValueIsLose() {

        return _pm.IsLose;

    }

    //Set Value Is Lose
    public void SetValueIsLose(bool isLose) {

        _pm.IsLose = isLose;

    }

    //Reset Player Type
    public void ResetPlayerType() {

        _pv.PlayerType[_pm.PlayerTypeStatus].SetActive(false);

    }

    //Get Player Type
    public GameObject GetPlayerType() {

        return _pv.PlayerType[_pm.PlayerTypeStatus];        

    }

    //Set Player Type
    public void SetPlayerType(int idType) {

        ResetPlayerType();

        _pm.PlayerTypeStatus=idType;
        _pv.PlayerType[idType].SetActive(true);
        _pv.AnimController = _pv.PlayerType[idType].GetComponent<Animator>();
        
    }

    //Check Player Type
    public int CheckPlayerType() {

        return _pm.PlayerTypeStatus;

    }  

    //Stop All Coroutine Player
    public void StopAllCoroutinePlayer() {

        if (_pm.CoroutineFire != null) {

            StopCoroutine(_pm.CoroutineFire);

        }

    }          

    //Set Count Targetes
    public void SetCounEnemy(int countTragetes) {

        _pm.CountTargetes = countTragetes;

    }

    //Change Life Count 
    public void ChangeLifeCount(float count) {

        if (_pm.HP != 0) {

            _pm.HP -= count;

        }

    }

    //Get Life Count
    public float GetLifeCount() {

        return _pm.HP;

    }    

    public void Start() {

        _pv.controller = GetComponent<CharacterController>();

        _pm.HP = _pm.MaxHealth;        

    }

    //Body Rotate
    public void BodyRotate(bool isShoot) {

        if (!isShoot) {

            if (_pv.joystick.Vertical < 0f) {

                GetPlayerType().transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                GetPlayerType().transform.rotation = Quaternion.Euler(0.0f, -5.0f, 0.0f);

            } else {

                if (_pv.joystick.Vertical != 0f && _pv.joystick.Vertical > 0f) {

                    GetPlayerType().transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    GetPlayerType().transform.rotation = Quaternion.Euler(0.0f, 5.0f, 0.0f);

                } else {

                    GetPlayerType().transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

                }

            }

        } else {

            if (_pv.Targetes[_pm.IdTargetes].transform.position.y > transform.position.y) {

                GetPlayerType().transform.rotation = Quaternion.Euler(0.0f, -5.0f, 0.0f);

            } else {

                GetPlayerType().transform.rotation = Quaternion.Euler(0.0f, 5.0f, 0.0f);

            }

        }

    }

    public void Update() {

        _pv.HealthBar.fillAmount = _pm.HP / _pm.MaxHealth;
       
        if (_pm.IdTargetes != _pm.CountTargetes) {

            if (_pv.Targetes[_pm.IdTargetes] != null) {
                
                _pm.CalcDistanceValue = Vector3.Distance(transform.position, _pv.Targetes[_pm.IdTargetes].transform.position);

            }

        } else {

            if (!_pm.IsEndGame) {

                _pm.IsEndGame = true;
                WaitAndDestroyPlayer();

            }

        }

        if (_pm.Move != Vector3.zero){

            if (!_pv.AnimController.GetBool("IsWalk")) {

                _pv.AnimController.SetBool("IsIdle", false);
                _pv.AnimController.SetBool("IsWalk", true);
                
            }

        } else {

            if (!_pv.AnimController.GetBool("IsIdle")) {

                _pv.AnimController.SetBool("IsWalk", false);
                _pv.AnimController.SetBool("IsIdle", true);

            }

        }
        
        
        if (_pm.CalcDistanceValue > _pm.MaxDistance && _pv.joystick.Horizontal < 0.0f) {
            

            BodyRotate(false);

            _pm.Move = transform.right * _pv.joystick.Horizontal + transform.forward * _pv.joystick.Vertical;
            _pv.controller.Move(-_pm.Move * _pm.SpeedMove * Time.deltaTime);

        } else {

            if (!_pv.AnimController.GetBool("IsIdle")) {

                _pv.AnimController.SetBool("IsWalk", false);
                _pv.AnimController.SetBool("IsIdle", true);

            }

        }

    }     
    
    public void OnDestroy() {

        StopCoroutine(WaitAndDestroy());

        _pv.Targetes.Clear();

        if (_pm.CoroutineFire != null) {

            StopCoroutine(_pm.CoroutineFire);
            _pm.CoroutineFire = null;

        }
        
    }

    //Change Value => IdTargetes 
    public void DiePlayer() {

        _pm.IdTargetes = _pm.CountTargetes;

    }

    //Wait And Destroy Player
    public void WaitAndDestroyPlayer() {

        StartCoroutine(WaitAndDestroy());

    }


    //Destroy All Enemy
    public void DestroyAllEnemy() {

        StartCoroutine(DestroyAllEnemies());

    }


    //Destroy All Enemies
    IEnumerator DestroyAllEnemies() {

        yield return new WaitForSeconds(1.0f);

        foreach(var enemy in _pv.Targetes) {

            if (enemy != null) {

                if (!enemy.gameObject.activeSelf) {

                    enemy.gameObject.SetActive(true);
                    
                }               
                
                Destroy(enemy.gameObject);

            }

        }

    }

    //Deactive Fire
    IEnumerator DeactivateFire(int idGunType) {

        if (_pm.IdTargetes != _pm.CountTargetes) {
            
            if (_pv.Targetes[_pm.IdTargetes].GetComponent<EnemyController>().GetValueIsCanShoot()) {                

                if (!_pv.Targetes[_pm.IdTargetes].GetComponent<EnemyController>().GetValueIsDie()) {
                    
                    var obj = Instantiate(_pv.PrefubesBullet[idGunType - 1], _pv.BulletesPosition[idGunType - 1].transform.position, Quaternion.Euler(transform.eulerAngles));

                    obj.SetPlayerValue(this);

                    obj.Shoot(_pv.Targetes[_pm.IdTargetes].gameObject);

                }

            }

            yield return new WaitForSeconds(0.2f);

            _pv.FireGunType[idGunType - 1].SetActive(false);

        }

    }

    //IEnumerator Wait And Destroy Player
    IEnumerator WaitAndDestroy() {

        StopAllCoroutinePlayer();

        PlaySoundPlayerDie();

        yield return new WaitForSeconds(1.5f);

        _pv.ObjectMenu.SetActive(true);

        if (!GetValueIsLose()) {

            //Win
            if (!_pv.ObjectMenu.GetComponent<MenuController>().GetObjectNextLevelButton().activeSelf) {

                _pv.ObjectMenu.GetComponent<MenuController>().ChangeStatusNextLevelButton(true);

            }

        } else {

            //Lose
            if (_pv.ObjectMenu.GetComponent<MenuController>().GetObjectNextLevelButton().activeSelf) {

                _pv.ObjectMenu.GetComponent<MenuController>().ChangeStatusNextLevelButton(false);

            }

        }

        _pv.IndicatorLife.SetActive(false);        

        foreach(var obj in _pv.FireGunType) {

            if (obj.activeSelf) {

                obj.SetActive(false);

            }

        }

        foreach(var obj in _pv.PlayerType) {

            if (obj.activeSelf) {               

                obj.SetActive(false);  
                
            }

        }        

    }

    IEnumerator WaitAndResetData() {

        yield return new WaitForSeconds(0.5f);

        _pm.IdTargetes = 0;

        _pm.IsEndGame = false;

        _pm.MaxHealth = 100.0f;

        _pm.HP = 100.0f;

        _pv.IndicatorLife.SetActive(true);

        //Set Count Enemy
        SetCounEnemy((int)_pv.LC.GetResultCountEnemy());
        //Set Title Count Enemy
        SetTitleCountEnemy((int)_pv.LC.GetResultCountEnemy());

    }

    private void Awake() {
         
        _pv.Targetes = new List<EnemyController>();        

    }
    
}
