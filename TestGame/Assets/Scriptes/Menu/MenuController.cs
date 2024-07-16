using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    [SerializeField] private MenuModel _mm;//Menu Model
    [SerializeField] private MenuView _mv;//Menu View

    //Get Property Bonus Panel 
    public BonusPanelController GetBonusPanelProperty() {

        return _mv.bonusPanelController;

    }

    //Get Object Restart Button
    public GameObject GetObjectRestartButton() {

        return _mv.ButtonRestart;

    }

    //Get Object Next Level Button
    public GameObject GetObjectNextLevelButton() {

        return _mv.ButtonNextLevel;

    }

    //Change Status Restart Button
    public void ChangeStatusRestartButton(bool isStatus) {

        _mv.ButtonRestart.SetActive(isStatus);

    }

    //Change Status Next Level Button
    public void ChangeStatusNextLevelButton(bool isStatus) {

        _mv.ButtonNextLevel.SetActive(isStatus);

    }

    //Next Level
    public void NextLevel() {        

        _mv.sceneController.NextLevel();        

        _mv.sceneController.GenerateScene();        

    }
  
    //Restart
    public void Restart() {        

        _mv.sceneController.Restart();        
        //delete bonus        
        _mv.sceneController.GenerateScene();        

    }  

    //Wait And Close Icon Menu
    IEnumerator WaitAndCloseIconMenu() {

        yield return new WaitForSeconds(1.0f);

        gameObject.SetActive(false);

    }

    public void Start() {

        _mv.displayController.ResetAllItem();

    }

}
