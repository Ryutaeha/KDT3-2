using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    [SerializeField] Button selectBtn;
    private ItemAbility itemInfo;

    public ItemAbility ItemInfo { get {return itemInfo; } }
    public void ItemSet(ItemAbility item, int choice)
    {
        itemInfo = item;
        ItemImgSet(item.Key);
        ItemTextSet(item.ItemName);
        ItemEquipSet(item.Equip);
        selectBtn.onClick.AddListener(() => { OnEquipAndBuySet(choice); });
    }


    public void ItemEquipSet(bool equip)
    {
        if(equip) gameObject.transform.GetChild(2).gameObject.SetActive(true);
        else gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }

    private void ItemImgSet(string itemKey)
    {
        Image imageRenderer = gameObject.transform.GetChild(0).GetComponent<Image>();
        imageRenderer.sprite = GameManager.Instance.ResourceManager.ItemImgSet(itemKey);

    }
    
    private void ItemTextSet(string itemName)
    {
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = itemName;
    }

    public void OnEquipAndBuySet(int choice)
    {
        GameManager.Instance.OpenPopUpUI(itemInfo, choice);
    }

    
}
