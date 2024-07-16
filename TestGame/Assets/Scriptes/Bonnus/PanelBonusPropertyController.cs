using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBonusPropertyController : MonoBehaviour {

    [SerializeField] private PanelBonusPropertyModel _pbpm;//Panel Bonus Property Model
    [SerializeField] private PanelBonusPropertyView _pbpv;//Panel Bonus Property View

    //Restart Data
    public void RestartData(List<BonusItemController> createdBonuses) {

        for(int i=0; i<createdBonuses.Count; i++) {

            createdBonuses[i].SetIdPositionBonusInArray(i);
            
        }

        _pbpv.ObjectBonusPanel.SetCountBonuses(_pbpv.ObjectBonusPanel.GetCountBonuses() - 1);

        _pbpv.ObjectBonusPanel.SetTitleBackpack(_pbpv.ObjectBonusPanel.GetCountBonuses());

    }

    //Function Button Yes
    public void ButtonYes(List<int> idBonusesModel, List<BonusItemController> createdBonuses, BonusItemController item) {        

        Destroy(createdBonuses[item.GetIdPositionBonusInArray()].gameObject);

        createdBonuses.Remove(item);

        idBonusesModel.Remove(idBonusesModel[item.GetIdPositionBonusInArray()]);

        RestartData(createdBonuses);        

    }

    //Function Button No
    public void ButtonNo() {
       
        _pbpv.ObjectPanelBonusProperty.gameObject.SetActive(false);

    }

}
