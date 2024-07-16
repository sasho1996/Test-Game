using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneController : MonoBehaviour {

    [SerializeField] private SceneView _sv;//Scene View
    [SerializeField] private SceneModel _sm;//Scene Model


    //Generate Scene
    public void GenerateScene() {        

        if (_sv.Player == null) {

            _sv.Player = Instantiate(_sv.PrefubPlayer, _sv.PlayerStartPosition.transform.localPosition, Quaternion.identity);

            _sv.Level.SetPlayerProperty(_sv.Player);

            _sv.Level.GetPlayerObject().SetProperties(_sv.Joystick, _sv.ObjectMenu, _sv.PlayerStartPosition);

            _sv.Level.CalcDifficultyLevel();

            _sv.Level.GetPlayerObject().SetValueObjectLevelController(_sv.Level);

            _sv.Level.GetPlayerObject().SetPropertyTitleCountEnemy(_sv.TitleCountEnemy);

            _sv.Display.SetPlayerProperty(_sv.Player);
            
        }
        
        SetPlayerProperty();

        var dl = _sv.Level.GetDifficultyLevel();

        dl += 1;

        _sv.TitleLevelNum.text = "" + "Level " + dl;

        _sv.Level.GetPlayerObject().ClearPropertyTargetes();

        EnemyController enemy;

        for (int i = 0; i < _sv.Level.GetResultCountEnemy(); i++) {

            enemy=GeneratePositionEnemy(Random.Range(3.0f+(3.58f*i), (3.58f * i)), Random.Range(-1.0f, 1.0f), Random.Range(4.2f, 7.52f));

            enemy.SetDifficultyLevel(_sv.Level.GetDifficultyLevel());

            if (i != 0) {

                enemy.gameObject.SetActive(false);

            }

        }

        _sv.BonusPanel.SetIdDifficultyLevel(_sv.Level.GetDifficultyLevel());

    }

    //Next Level
    public void NextLevel() {        

        var index = _sv.Level.GetDifficultyLevel();

        index++;

        if (index > _sv.Level.GetDifficultyLevelCount()) {

            index = 0;

        }

        _sv.Level.SetDifficultyLevel(index);

        _sv.Level.CalcDifficultyLevel();


        _sv.BonusPanel.AddPropertiesToIdBonussesModel(_sv.BonusPanel.GetLevelMemoryController().GetPropertyLevelIdBonus());

        _sv.BonusPanel.ChangeTitleBackpack();

        _sv.BonusPanel.GetLevelMemoryController().ResetMemory();

    }

    //Restart
    public void Restart() {

        _sv.BonusPanel.GetLevelMemoryController().ResetMemory();

        _sv.Level.CalcDifficultyLevel();

        //_sv.BonusPanel.DeleteBonuses(_sv.Level.GetDifficultyLevel());

    }

    //Set Player Property
    public void SetPlayerProperty() {             

        _sv.Level.GetPlayerObject().ResetInfoPlayer();
    }

    //Generate Position Enemy
    public EnemyController GeneratePositionEnemy(float posX, float posY, float posZ) {
        
        EnemyController enemy=_sv.Level.CreateEnemy(posX, posY, posZ);

        enemy.SetPropertyPanelIndicatorEnemyLife(_sv.PanelIndicatorEnemyLife);

        enemy.SetTraget(_sv.Level.GetPlayerObject().gameObject);

        enemy.SetBonusPanelProperty(_sv.BonusPanel);

        enemy.SetPropertyObjectMenu(_sv.ObjectMenu);

        enemy.SetPropertyPlayer(_sv.Level.GetPlayerObject());

        _sv.Level.GetPlayerObject().SetEnemiesValues(enemy);

        return enemy;

    }

    public void Start() {

        GenerateScene();        

    }

    public void OnDestroy() {

        _sv.Level.ClearEnemy();
        
    }

}
