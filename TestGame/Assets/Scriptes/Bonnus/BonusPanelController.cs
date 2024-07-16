using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class BonusPanelController : MonoBehaviour {

    [SerializeField] private BonusPanelModel _bpm;//Bonus Panel Model
    [SerializeField] private BonusPanelView _bpv;//Bonus Panel View

    //Set Title Backpack
    public void SetTitleBackpack(int countBonuses) {

        _bpv.TitleBackpack.text = "" + countBonuses;

    }

    //Get Totle Backpack
    public Text GetTitleBaackpack() {

        return _bpv.TitleBackpack;

    }

    //Get Count Bonuses
    public int GetCountBonuses() {

        return _bpm.CountBonuses;

    }

    //Set Count Bonuses
    public void SetCountBonuses(int countBonuses) {

        _bpm.CountBonuses = countBonuses;

    }

    //Get Property Level Memory Controller
    public LevelMemoryController GetLevelMemoryController() {

        return _bpv.levelMemoryController;

    }

    //Add Properties To  Id Bonuses Model
    public void AddPropertiesToIdBonussesModel(List<int> levelIdBonuses) {

        if (levelIdBonuses.Count > 0) {

            for (int i = 0; i < levelIdBonuses.Count; i++) {

                _bpm.IdBonusesModel.Add(levelIdBonuses[i]);

            }

        }

    }

    //Get Id Difficulty Level
    public int GetIdDifficultyLevel() {

        return _bpm.IdDifficultyLevel;

    }

    //Set Id Difficulty Level
    public void SetIdDifficultyLevel(int idDL) {

        _bpm.IdDifficultyLevel = idDL;

    }

    //Play Sound Click Effect Button
    public void PlaySoundClickEffectButton(AudioClip clip) {

        _bpv.AudioSourceBonusPanel.PlayOneShot(clip);

    }
   
    //Add Bonus
    public void AddBonus(int idBonus) {        

        //_bpm.IdBonusesModel.Add(idBonus);
        _bpv.levelMemoryController.AddBonus(idBonus);

    }

    //Change Title Backpack
    public void ChangeTitleBackpack() {

        _bpm.CountBonuses = _bpm.IdBonusesModel.Count;

        if (_bpm.CountBonuses > 1) {

            _bpv.TitleBackpack.text = "" + _bpm.CountBonuses.ToString();

        } else  {

            _bpv.TitleBackpack.text = "";

        }

    }

    //Init Data
    public void Init() {
       
        if (_bpm.IdBonusesModel == null) {

            _bpm.IdBonusesModel = new List<int>();
            
            _bpm.CountBonuses = _bpm.IdBonusesModel.Count;
       
        } else {

            _bpm.CountBonuses = _bpm.IdBonusesModel.Count;
            
        }

        if (_bpv.CreatedBonuses == null) {

            _bpv.CreatedBonuses = new List<BonusItemController>();

        }
       
        ShowBonuses();        

    }
    
    //Set Choosed Item Value
    public void SetChoosedItemValue(BonusItemController choosedItem) { 
    
        _bpv.ChoosedItem = choosedItem;

    }

    //Click Button YES
    public void ClickButtonYes() {

        PlaySoundClickEffectButton(_bpm.ClickEffect);

        _bpv.PanelProperty.ButtonYes(_bpm.IdBonusesModel, _bpv.CreatedBonuses, _bpv.ChoosedItem);
        _bpv.PanelProperty.gameObject.SetActive(false);        

    }

    //Click Button No
    public void ClickButtonNo() {

        PlaySoundClickEffectButton(_bpm.ClickEffect);

        _bpv.PanelProperty.ButtonNo();

    } 

    //Show Bonuses
    public void ShowBonuses() {

        if (_bpv.CreatedBonuses.Count != 0) {

            foreach(var obj in _bpv.CreatedBonuses) {

                Destroy(obj.gameObject);

            }

            _bpv.CreatedBonuses.Clear();

        }

        if (_bpm.IdBonusesModel.Count != 0) {

            for (int i = 0; i < _bpm.IdBonusesModel.Count; i++) {

                _bpv.CreatedBonuses.Add(Instantiate(_bpv.PrefubItemBonus, _bpv.BonusContent.transform));

                //_bpv.CreatedBonuses[_bpv.CreatedBonuses.Count() - 1].SetIdDifficultyLevel(GetIdDifficultyLevel());

            }

            for(int i=0; i<_bpv.levelMemoryController.GetPropertyLevelIdBonus().Count; i++) {

                _bpv.CreatedBonuses.Add(Instantiate(_bpv.PrefubItemBonus, _bpv.BonusContent.transform));

            }

            for (int i = 0; i < _bpv.levelMemoryController.GetPropertyLevelIdBonus().Count; i++) {

                _bpv.CreatedBonuses[i].GetComponent<Image>().sprite = _bpv.SpritesBonuses[_bpv.levelMemoryController.GetPropertyLevelIdBonus()[i]];

            }

            for (int i = 0; i < _bpm.IdBonusesModel.Count; i++) {

                _bpv.CreatedBonuses[i].GetComponent<Image>().sprite = _bpv.SpritesBonuses[_bpm.IdBonusesModel[i]];

            }

            for (int i = 0; i < _bpv.levelMemoryController.GetPropertyLevelIdBonus().Count; i++) {

                _bpv.CreatedBonuses[i].Init(this, _bpv.PanelProperty, _bpv.levelMemoryController.GetPropertyLevelIdBonus()[i], i);

            }

            for (int i = 0; i < _bpm.IdBonusesModel.Count; i++) {

                _bpv.CreatedBonuses[i].Init(this, _bpv.PanelProperty, _bpm.IdBonusesModel[i], i);

            }

        }

    }   

    //Save Data
    public void SaveData() {

        if (_bpm.MemoryComponent.Length > 0) {

            _bpm.MemoryComponent = "";

        }

        for (int i=0; i<_bpm.IdBonusesModel.Count; i++) {

            _bpm.MemoryComponent += " "+ _bpm.IdBonusesModel[i];            

        }

        PlayerPrefs.SetString("Bonuses", _bpm.MemoryComponent);

        PlayerPrefs.Save();

    }

    //Get Data
    public void GetData() {

        if (PlayerPrefs.HasKey("Bonuses")) {

            _bpm.MemoryComponent = PlayerPrefs.GetString("Bonuses");

            _bpm.IdBonusesModel = Regex.Matches(_bpm.MemoryComponent, @"\d+").Cast<Match>().Select(x => int.Parse(x.ToString())).ToList();

        }

    }

    //Restart Data
    public void RestartData() {

        for (int i = 0; i < _bpv.CreatedBonuses.Count; i++) {

            Destroy(_bpv.CreatedBonuses[i].gameObject);

        }        

        ShowBonuses();

    }

    public void OnDestroy() {

        if (_bpm.IdBonusesModel.Count > 0) {

            SaveData();

        }

        _bpm.IdBonusesModel.Clear();

        for (int i = 0; i < _bpv.CreatedBonuses.Count; i++) {

            Destroy(_bpv.CreatedBonuses[i]);

        }

        _bpv.CreatedBonuses.Clear();

        _bpm.CountBonuses = 0;

    }

}
