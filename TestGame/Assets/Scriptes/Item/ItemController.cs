using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour {

    [SerializeField] private ItemModel _im;//Item Model
    [SerializeField] private ItemView _iv;//Item View    

    //Set Value Item
    public void SetValueItem(Text titleItem, int count) {

        titleItem.text = "" + count;

    }

    //Set Value Item Count Box
    public void SetValueItemCountBox(int count) {

        _iv.TitleCountBox.text = "" + count;

    }

    //Set Value Item Count Bullet
    public void SetValueItemCountBullet(int count) {

        _iv.TitleCountBullet.text = "" + count;

    }

    //Set Count Box
    public void SetCountBox(int countBox) {

        _im.CountBox = countBox;

    }

    //Set Count Box
    public void SetCountBulletes(int countBulletes) {

        _im.CountBullet = countBulletes;

    }

    //Get Count Bullet
    public int GetCountBullet() {

        return _im.CountBullet;

    }

    //Get Count Box
    public int GetCountBox() {

        return _im.CountBox;

    }

    //Change Sprite Item
    public void ChangeSpriteItem(Image spriteItem, Sprite sprite) {

        spriteItem.sprite = sprite;

    }

    //Change Color Item
    public void ChangeColorItem(Image colorItem, Color color) {

        colorItem.color = color;

    }

    //Click Item
    public void ClickItem() {

        if (!_im.IsChoosed) {

            _im.IsChoosed = true;

            //Change Color Item To Yellow
            ChangeColorItem(gameObject.GetComponent<Image>(), Color.yellow);

            //Change Sprite Item in Count Bullet
            ChangeSpriteItem(_iv.CountBullet, _im.DefaultSpriteBulletItem);

            //Change Sprite Item in Count Box
            ChangeSpriteItem(_iv.CountBox, _im.SpriteBoxType);

            //Change Sprite Item in Gun Type For Shoot
            ChangeSpriteItem(_iv.GunTypeForShoot, _im.SpriteBulletGunType);

            //Set Value Item in Count Bullet
            SetValueItem(_iv.TitleCountBullet, _im.CountBullet);

            //Set Value Item in Count Box
            SetValueItem(_iv.TitleCountBox, _im.CountBox);

            //Set Value Is Active For Set Value Is Active For Item Shoot
            _iv.ItemShoot.SetValueIsActive(_im.IsChoosed);

            //Change Gun Type
            ChangeGunType(_iv.PrefubGun, _iv.PrefubBullet);

        } else {

            _im.IsChoosed = false;

            //Change Color Item To White
            ChangeColorItem(gameObject.GetComponent<Image>(), Color.white);

            //Change Sprite Item in Count Bullet
            ChangeSpriteItem(_iv.CountBullet, _im.DefaultSpriteItemCount);

            //Change Sprite Item in Count Box
            ChangeSpriteItem(_iv.CountBox, _im.DefaultSpriteItemCount);

            //Change Sprite Item in Gun Type For Shoot
            ChangeSpriteItem(_iv.GunTypeForShoot, _im.DefaultSpriteItemGunType);

            //Set Value Item in Count Bullet
            SetValueItem(_iv.TitleCountBullet, 0);

            //Set Value Item in Count Box
            SetValueItem(_iv.TitleCountBox, 0);

            //Set Value Is Active For Set Value Is Active For Item Shoot
            _iv.ItemShoot.SetValueIsActive(_im.IsChoosed);

            //Null Choosed Gun Type
            NullChoosedGunType();

        }

    }

    //Check Is Active Item
    public bool CheckIsActiveItem() {

        if (_im.IsActive) {

            return true;

        } else {

            return false;

        }

    }

    //Check Is Choosed
    public bool CheckIsChoosed() {

        return _im.IsChoosed;

    }

    //Change Gun Type
    public void ChangeGunType( GameObject choosedGunType, GameObject choosedBulletType) {

        _iv.ChoosedBulletType= choosedBulletType;
        _iv.ChoosedGunType = choosedGunType;
        
        _iv.ItemShoot.GetTypeGunAndBullet(_iv.ChoosedBulletType, _iv.ChoosedGunType);

    }

    //Null Gun Type
    public void NullChoosedGunType() {

        if (_iv.ChoosedBulletType != null) {

            _iv.ChoosedBulletType = null;

        }

        if (_iv.ChoosedGunType != null) {

            _iv.ChoosedGunType = null;
        }
        
        _iv.ItemShoot.GetTypeGunAndBullet(null, null);

    }

    //Return Choosed Gun Type
    public GameObject ChoosedGunType() {

        if (_iv.ChoosedGunType!=null) {

            return _iv.ChoosedGunType;

        } else {

            return null;

        }

    }

    //Return Choosed Bullet Type    
    public GameObject ChoosedBulletType() {

        if (_iv.ChoosedBulletType!= null) {

            return _iv.ChoosedBulletType;

        } else {

            return null;

        }

    }

    //Reset Item
    public void ResetItem() {

        if (_im.IsChoosed) {

            _im.IsChoosed = false;

            //Null Choosed Gun Type
            NullChoosedGunType();

            //Change Color Item To White
            ChangeColorItem(gameObject.GetComponent<Image>(), Color.white);

            //Change Sprite Item in Count Bullet
            ChangeSpriteItem(_iv.CountBullet, _im.DefaultSpriteItemCount);

            //Change Sprite Item in Count Box
            ChangeSpriteItem(_iv.CountBox, _im.DefaultSpriteItemCount);

            //Change Sprite Item in Gun Type For Shoot
            ChangeSpriteItem(_iv.GunTypeForShoot, _im.DefaultSpriteItemGunType);

            //Set Value Item in Count Bullet
            SetValueItem(_iv.TitleCountBullet, 0);

            //Set Value Item in Count Box
            SetValueItem(_iv.TitleCountBox, 0);

        }

    }

    //Init Data
    public void Init() {

        SetCountBox(5);//80
        SetCountBulletes(10);//40

    }

}
