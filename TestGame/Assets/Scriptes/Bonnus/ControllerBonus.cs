using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBonus : MonoBehaviour {

    [SerializeField] private ViewBonus _bv;//Bonus View
    [SerializeField] private ModelBonus _bm;//Bonus Model

    //Get Id Difficulty Level
    public int GetIdDifficultyLevel() {

        return _bm.IdDifficultyLevel;

    }

    //Set Id Difficulty Level
    public void SetIdDifficultyLevel(int idDL) {

        _bm.IdDifficultyLevel = idDL;

    }

    //Set Bonus Panel Property
    public void SetBonusPanelProperty(BonusPanelController bonusPanel) {

        _bv.BonusPanel = bonusPanel;

    }

    //Get Bonus Panel Property
    public BonusPanelController GetBonusPanelProperty() {

        return _bv.BonusPanel;

    }

    //Set Id Bonus
    public void SetIdBonus(int idBonus) {

        _bm.IdBonus = idBonus;

    }

    //Get Id Bonus
    public int GetIdBonus() {

        return _bm.IdBonus;

    }

    //Set Sprite Bonus
    public void SetSpriteBonus(int idBonus) {

        _bv.SpriteBonus.sprite = _bv.SpritesBonus[idBonus];

    }

    //Transform Bonus
    public void TransformBonus(GameObject target) {

        _bv.BonusPanel.AddBonus(_bm.IdBonus);

        _bv.BonusPanel.ChangeTitleBackpack();

        transform.DOMove(target.transform.position, 0.2f);

        DoWaitAndDestroy();

    }   

    //Do Wait And Destroy
    public void DoWaitAndDestroy() {

        if (_bm.CoroutineWaitAndDestroy == null) {

            _bm.CoroutineWaitAndDestroy = WaitAndDestroy();

            StartCoroutine(_bm.CoroutineWaitAndDestroy);

        }

    }

    //IEnumerator Wait And Destroy
    IEnumerator WaitAndDestroy() {       

        yield return new WaitForSeconds(0.5f);
        
        Destroy(gameObject);

    }

}
