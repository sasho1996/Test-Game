using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfoController : MonoBehaviour {

    [SerializeField] private EnemyInfoView _eiv;//Enemy Info View
    [SerializeField] private EnemyInfoModel _eim;//Enemy Info Model   

    //Set Enemy Sprite
    public void SetEnemySprite() {

        _eiv.ImageEnemy.sprite = _eim.SpriteEnemy;

    }

    //Delete Enemy Info
    public void DeleteEnemyInfo() {

        Destroy(gameObject);

    }

    public void Start() {

        _eim.HP = _eim.MaxHealth;

    }

    //Change Life Count
    public void ChangeLifeCount(float count) {

        if (_eim.HP != 0) {

            _eim.HP -= count;

        }

    }

    //Get Life Count
    public float GetLifeCount() {

        return _eim.HP;

    }

    public void Update() {

        _eiv.HealthBar.fillAmount = _eim.HP / _eim.MaxHealth;

    }

}
