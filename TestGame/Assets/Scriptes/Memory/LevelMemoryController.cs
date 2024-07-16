using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMemoryController : MonoBehaviour {

    [SerializeField] private LevelMemoryModel _lmm;//Level Memory Model
    [SerializeField] private LevelMemoryView _lmv;//Level Memory View

    //Get Property Bonus Panel Controller
    public BonusPanelController GetPropertyBonusPanelController() {

        return _lmv.bonusPanelController;

    }

    //Set Property Bonus Panel Controller
    public void SetPropertyBonusPanelController(BonusPanelController bonusPanelController) {

        _lmv.bonusPanelController = bonusPanelController;

    }

    //Get Property Level Id Bonus
    public List<int> GetPropertyLevelIdBonus(){

        return _lmm.LevelIdBonus;

    }

    //Add Bonus
    public void AddBonus(int idBonus) {

        _lmm.LevelIdBonus.Add(idBonus);

    }

    //Remove Bonus
    public void RemoveBonus(int idBonus) {

        _lmm.LevelIdBonus.Remove(idBonus);

    }

    //Add AllBonus
    public void AddAllBonus(List<int> IdBonuses) {

        foreach (var obj in _lmm.LevelIdBonus) {

            IdBonuses.Add(obj);

        }

    }

    //Reset Memory
    public void ResetMemory() {

        _lmm.LevelIdBonus.Clear();

    }

}
