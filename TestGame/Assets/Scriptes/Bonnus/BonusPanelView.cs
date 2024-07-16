using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusPanelView : MonoBehaviour {    

    public List<BonusItemController> CreatedBonuses;//List Game Object Created Bonuses                                   

    public GameObject BonusContent;//Bonus Content    

    public Sprite[] SpritesBonuses;//Sprites Bonuses Model

    public BonusItemController PrefubItemBonus;//Prefub Item Bonus

    public PanelBonusPropertyController PanelProperty;//Game Object Panel Property                                           

    public BonusItemController ChoosedItem;//Object Choosed Item

    public AudioSource AudioSourceBonusPanel;//Audio Source Bonus Panel

    public Text TitleBackpack;//Title Backpack

    public LevelMemoryController levelMemoryController;//Level Memory Controller
}
