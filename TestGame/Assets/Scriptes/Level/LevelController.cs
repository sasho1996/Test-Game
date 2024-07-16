using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class LevelController : MonoBehaviour {

    [SerializeField] private LevelModel _lm;//Level Model
    [SerializeField] private LevelView _lv;//Level View

    //Get Max Count Enemy
    public int GetDifficultyLevelCount() {

        return _lm.CountDifficultyLevel;

    }

    //Set Player Property
    public void SetPlayerProperty(PlayerController player) {

        _lv.Player = player;

    }

    //Get Player Object
    public PlayerController GetPlayerObject() {

        return _lv.Player;

    }

    //Reset Player Data
    public void ResetPlayerData() {

        _lv.Player.ResetInfoPlayer();

    }

    //Get Difficulty Level
    public int GetDifficultyLevel() {

        return _lm.DifficultyLevel;

    }

    //Set Difficulty Level
    public void SetDifficultyLevel(int dl) {

        _lm.DifficultyLevel = dl;

    }

    //Get Result Count Enemy
    public float GetResultCountEnemy() {

        return _lm.ResultCountEnemy;

    }

    //Calc Difficulty Level
    public void CalcDifficultyLevel() {

        if (_lm.DifficultyLevel == 0) {

            _lm.ResultCountEnemy = _lm.DifficultyLevel * _lm.MaxCountEnemy;
            _lm.ResultCountEnemy /= _lm.CountDifficultyLevel;
            _lm.ResultCountEnemy += _lm.MinCountEnemy;
            _lm.ResultCountEnemy = MathF.Floor(_lm.ResultCountEnemy);

        } else {

            _lm.ResultCountEnemy = _lm.DifficultyLevel * _lm.MaxCountEnemy;
            _lm.ResultCountEnemy /= _lm.CountDifficultyLevel;
            _lm.ResultCountEnemy += _lm.MinCountEnemy;
            _lm.ResultCountEnemy = MathF.Floor(_lm.ResultCountEnemy);

        }
        
    }

    //Create Enemy
    public EnemyController CreateEnemy(float posX, float posY, float posZ) {

        return Instantiate(_lv.Enemy, new Vector3(posX, posY, posZ), Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f)));

    }

    //Clear Enemy
    public void ClearEnemy() {

        for (int i = 0; i < _lv.CreatedEnemies.Count; i++) {

            if (_lv.CreatedEnemies[i] != null) {

                Destroy(_lv.CreatedEnemies[i]);

            }

        }

        _lv.CreatedEnemies.Clear();

    }

    private void OnDestroy() {

        _lv.CreatedEnemies.Clear();

    }    

}
