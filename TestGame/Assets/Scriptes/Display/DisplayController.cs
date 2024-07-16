using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour {

    [SerializeField] private DisplayView _dv;//Display View
    [SerializeField] private DisplayModel _dm;//Display Model

    //Get Player Property
    public PlayerController GetPlayerProperty() {

        return _dv.Player;

    }

    //Set Property Player
    public void SetPlayerProperty(PlayerController player) {

        _dv.Player = player;

    }

    //Reset Data Box And Bullet
    public void ResetDataBoxAndBullet() {

        _dv.ItemGun.Init();        
        _dv.ItemAutomatic.Init();
        _dv.ItemGun.ChangeColorItem(_dv.ItemGun.GetComponent<Image>(), Color.white);
        _dv.ItemAutomatic.ChangeColorItem(_dv.ItemAutomatic.GetComponent<Image>(), Color.white);

    }

    //Click Item Next Level
    public void ClickNextLevel() {

        PlaySoundClickEffectButton();

        ResetAllItem();

        ResetDataBoxAndBullet();

        _dv.ObjectMenu.gameObject.SetActive(false);

        _dv.ObjectMenu.NextLevel();

    }

    //Click Item Restart
    public void ClickRestart() {

        PlaySoundClickEffectButton();

        ResetAllItem();

        ResetDataBoxAndBullet();

        _dv.ObjectMenu.gameObject.SetActive(false);

        _dv.ObjectMenu.Restart();

    }

    //Click Item Gun
    public void ClickItemGun() {

        if (_dv.ItemBackpack.CheckIsChoosedItem()){

            _dv.ItemBackpack.ResetData();

        }

        if (_dv.ItemGun.CheckIsActiveItem()) {            

            _dv.ItemAutomatic.ResetItem();

            _dv.ItemGun.ClickItem();

            _dv.ItemShoot.SetGunType(_dv.ItemGun);
                        
        }

        if (_dv.ItemGun.CheckIsChoosed()) {

            PlaySoundChoosedGun();

            _dv.Player.SetPlayerType(1);

        } else {

            PlaySoundChoosedGun();

            _dv.Player.SetPlayerType(0);

        }

    }

    //Click Item Automatic
    public void ClickItemAutomatick() {

        if (_dv.ItemBackpack.CheckIsChoosedItem()) {

            _dv.ItemBackpack.ResetData();

        }

        if (_dv.ItemAutomatic.CheckIsActiveItem()) {            

            _dv.ItemGun.ResetItem();

            _dv.ItemAutomatic.ClickItem();

            _dv.ItemShoot.SetGunType(_dv.ItemAutomatic);

        }

        if (_dv.ItemAutomatic.CheckIsChoosed()) {

            PlaySoundChoosedGun();

            _dv.Player.SetPlayerType(2);

        } else {

            PlaySoundChoosedGun();

            _dv.Player.SetPlayerType(0);

        }

    }

    //Play Sound Click Effect Button
    public void PlaySoundClickEffectButton() {

        _dv.AudioSourceDisplay.PlayOneShot(_dm.ButtonClikcEffect);

    }

    //Play Sound Choosed Gun Effect
    public void PlaySoundChoosedGun() {

        _dv.AudioSourceDisplay.PlayOneShot(_dm.ChooseGunEffect);

    }

    //Click Shoot Item
    public void ClickShootItem() {

        if (_dv.ItemShoot.CheckIsActiveItem()) {
            
            if (GetPlayerProperty().GetValueIdTargets() != GetPlayerProperty().GetValueCountTargets()) {
            
                if (GetPlayerProperty().GetTargetes()[GetPlayerProperty().GetValueIdTargets()].GetComponent<EnemyController>().GetValueIsCanShoot()) {
                    
                    _dv.ItemShoot.GetGunType().SetCountBulletes((_dv.ItemShoot.GetGunType().GetCountBullet() - 1));

                    if (_dv.ItemShoot.GetGunType().GetCountBullet() == 0) {

                        if (_dv.ItemShoot.GetGunType().GetCountBox() != 0) {

                            if (_dv.ItemShoot.GetGunType() == _dv.ItemGun) {

                                GetPlayerProperty().PlaySoundChangeBoxGun();

                            } else {

                                GetPlayerProperty().PlaySoundChangeBoxAK_47();

                            }

                            _dv.ItemShoot.GetGunType().SetCountBulletes(10);
                            _dv.ItemShoot.GetGunType().SetCountBox((_dv.ItemShoot.GetGunType().GetCountBox() - 1));

                            _dv.ItemShoot.GetGunType().SetValueItemCountBox(_dv.ItemShoot.GetGunType().GetCountBox());
                            _dv.ItemShoot.GetGunType().SetValueItemCountBullet(_dv.ItemShoot.GetGunType().GetCountBullet());

                            _dv.ItemShoot.ClickItem();

                            _dv.Player.ShowGunFire(_dv.Player.CheckPlayerType());

                        } else {

                            _dv.ItemShoot.SetValueIsActive(false);

                            _dv.ItemShoot.GetGunType().ResetItem();

                            _dv.ItemShoot.GetGunType().ChangeColorItem(_dv.ItemShoot.GetGunType().GetComponent<Image>(), Color.red);

                            if (_dv.ItemShoot.GetGunType() == _dv.ItemGun) {

                                GetPlayerProperty().PlaySoundEmptyBoxGun();

                            } else {

                                GetPlayerProperty().PlaySoundEmptyBoxAK_47();

                            }

                        }

                    } else {

                        _dv.ItemShoot.GetGunType().SetValueItemCountBullet(_dv.ItemShoot.GetGunType().GetCountBullet());

                        _dv.ItemShoot.ClickItem();

                        _dv.Player.ShowGunFire(_dv.Player.CheckPlayerType());
                        
                        if (_dv.ItemShoot.GetGunType() == _dv.ItemGun) {
                            
                            GetPlayerProperty().PlaySoundGun();

                        } else {
                            
                            GetPlayerProperty().PlaySoundAK_47();

                        }

                    }

                }

            }

        }

    }

    //Click Item Backpack
    public void ClickItemBackpack() {

        PlaySoundClickEffectButton();

        if (_dv.ItemAutomatic.CheckIsActiveItem()) {

            _dv.ItemAutomatic.ResetItem();

        }

        if (_dv.ItemGun.CheckIsActiveItem()) {
            
            _dv.ItemGun.ResetItem();

        }

        if (_dv.ItemShoot.CheckIsActiveItem()) {

            _dv.ItemShoot.ResetItem();

        }

        if (_dv.Player.CheckPlayerType()!=0) {

            _dv.Player.SetPlayerType(0);

        }

        _dv.ItemBackpack.ClickItem();

    }

    //Reset All Item
    public void ResetAllItem() {

        if (_dv.ItemAutomatic.CheckIsActiveItem()) {

            _dv.ItemAutomatic.ResetItem();

        }

        if (_dv.ItemGun.CheckIsActiveItem()) {

            _dv.ItemGun.ResetItem();

        }

        if (_dv.ItemShoot.CheckIsActiveItem()) {

            _dv.ItemShoot.ResetItem();

        }

        if (_dv.ItemBackpack.CheckIsChoosedItem()) {

            _dv.ItemBackpack.ResetData();

        }

    }
    

    public void Start() {

        _dv.ItemGun.Init();
        _dv.ItemAutomatic.Init();       

    }       

}
