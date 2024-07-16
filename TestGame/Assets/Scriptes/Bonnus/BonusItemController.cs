using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItemController : MonoBehaviour {

    [SerializeField]private BonusItemModel _bim;//Bonus Item Model
    [SerializeField]private BonusItemView _biv;//Bonus Item View

    //Get Id Difficulty Level
    public int GetIdDifficultyLevel() {

        return _bim.IdDifficultyLevel;

    }

    //Set Id Difficulty Level
    public void SetIdDifficultyLevel(int idDL)
    {

        _bim.IdDifficultyLevel = idDL;

    }

    //Play Sound Click Effect
    public void PlaySoundClickEffect() {

        _biv.AudioSourceBonusItem.PlayOneShot(_bim.ClickEffect);

    }

    //Open Panel Property
    public void OpenPanelProperty() {
        
        if (!_biv.PanelProperty.gameObject.activeSelf) {

            PlaySoundClickEffect();

            _biv.BonusPanel.SetChoosedItemValue(this);
            _biv.PanelProperty.gameObject.SetActive(true);

        }

    }    

    //Init Data
    public void Init(BonusPanelController bonusPanel, PanelBonusPropertyController panelProperty, int idBonus, int idPositionBonusInArray) {

        _biv.BonusPanel = bonusPanel;

        _biv.PanelProperty = panelProperty;

        SetIdItem(idBonus);

        SetIdPositionBonusInArray(idPositionBonusInArray);

    }

    //Set Id Item
    public void SetIdItem(int idBonus) {

        _bim.IdBonus = idBonus;

    }

    //Get Id Item
    public int GetIdItem(){

        return _bim.IdBonus;

    }

    //Set Id Position Bonus In Array
    public void SetIdPositionBonusInArray(int idPositionBonusInArray) {

        _bim.IdPpositionBonusInArray=idPositionBonusInArray;

    }

    //Get Id Position Bonus In Array
    public int GetIdPositionBonusInArray() {

        return _bim.IdPpositionBonusInArray;

    }

}
