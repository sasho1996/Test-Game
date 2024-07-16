using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBackpackController : MonoBehaviour {

    [SerializeField] private ItemBackpackModel _ibm;//Item Backpack Model
    [SerializeField] private ItemBackpackView _ibv;//Item Backpack View   

    //Set Value Item
    public void SetValueItem(Text titleItem, int count) {

        titleItem.text = "" + count;

    }

    //Change Color Item
    public void ChangeColorItem(Image colorItem, Color color) {

        colorItem.color = color;

    }

    //Click Item
    public void ClickItem() {

        if (!_ibm.IsChoosed) {

            _ibm.IsChoosed = true;

            //Change Color Item To Yellow
            ChangeColorItem(gameObject.GetComponent<Image>(), Color.yellow);

            //Open Bonus Panel 
            OpenOrClosePanel(_ibv.BonusPanel);

        }  else  {

            _ibm.IsChoosed = false;

            //Change Color Item To White
            ChangeColorItem(gameObject.GetComponent<Image>(), Color.white);

            //Close Bonus Panel 
            OpenOrClosePanel(_ibv.BonusPanel);

        }

    }

    //Check Is Choosed Item
    public bool CheckIsChoosedItem() {

        if (_ibm.IsChoosed) {

            return true;

        } else {

            return false;

        }

    }

    //Set Value Is Active
    public void SetValueIsChoosed(bool isChoosed) {

        _ibm.IsChoosed = isChoosed;

    }

    //Open Or Close Panel
    public void OpenOrClosePanel(BonusPanelController panel) {

        if (!panel.gameObject.activeSelf) {

            panel.gameObject.SetActive(true);
            panel.Init();

        } else {

            panel.gameObject.SetActive(false);

        }

    }

    //Reset Data
    public void ResetData() {

        if (CheckIsChoosedItem()) {            

            SetValueIsChoosed(!_ibm.IsChoosed);

            //Change Color Item To Yellow
            ChangeColorItem(gameObject.GetComponent<Image>(), Color.white);

            if (_ibv.BonusPanel.gameObject.activeSelf) {

                OpenOrClosePanel(_ibv.BonusPanel);

            }

        }

    }

}
