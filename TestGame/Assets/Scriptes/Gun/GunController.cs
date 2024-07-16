using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour {

    [SerializeField] private GunModel _gm;//Gun Model
    [SerializeField] private GunView _gv;//Gun View

    //Set Value Is Active
    public void SetValueIsActive(bool isActive) {
        
        _gm.IsActive = isActive;        

    }

    //Check Is Active
    public bool CheckIsActiveItem() {

        if (_gm.IsActive) {

            return true;

        } else {

            return false;

        }

    }

    //Click Item
    public void ClickItem() {

        if (_gm.IsActive) {

          

        }

    }


    //Reset Item
    public void ResetItem() {

        if (_gm.IsActive) {

            SetValueIsActive(false);
            ChangeSpriteItem(_gv.ItemSprite, _gm.DefaultSpriteItemGunType);            

        }

    }

    //Get Typ Gun And Bullet
    public void GetTypeGunAndBullet(GameObject choosedBulletType, GameObject choosedGunType) {
        
        _gv.ChoosedBulletType = choosedBulletType;
        _gv.ChoosedGunType = choosedGunType;

    }

    //Set Gun Type
    public void SetGunType(ItemController gunType) {

        _gv.GunType = gunType;

    }

    //Get Gun Type
    public ItemController GetGunType() {

        return _gv.GunType;

    }

    //Change Sprite Item
    public void ChangeSpriteItem(Image spriteItem, Sprite sprite) {

        spriteItem.sprite = sprite;

    }    

}
