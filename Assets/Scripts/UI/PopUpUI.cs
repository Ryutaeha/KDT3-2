using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
public interface IPopUpUIPublic
{
    void Info(ItemAbility item);
    void BtnRe();
}



public class PopUpUIBase : MonoBehaviour, IPopUpUIPublic
{
    
    public void Info(ItemAbility item)
    {
        Transform transform = gameObject.transform;
        transform.GetChild(1).GetComponent<Image>().sprite = GameManager.Instance.ResourceManager.ItemImgSet(item.Key);
        transform.GetChild(2).GetComponent<TMP_Text>().text = item.ItemName;
        transform.GetChild(3).GetComponent<TMP_Text>().text = $"{item.Info}\n공격력 : {item.Attack} 방어력 : {item.Defensive} 체력 : {item.Health} 치명타 : {item.Fatal}";
    }

    public void BtnRe()
    {
        gameObject.transform.GetChild(4).GetComponent<Button>().onClick.RemoveAllListeners();
        BtnSet();
    }

    public virtual void BtnSet() { }
}
public class Equip : PopUpUIBase
{
    public override void BtnSet()
    {
        gameObject.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => GameManager.Instance.Equip());
    }
}
public class Buy : PopUpUIBase
{
    public override void BtnSet()
    {
        gameObject.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => GameManager.Instance.Buy());
    }
}
 */
public class PopUpUI : MonoBehaviour
{
    [SerializeField] GameObject PanelUI;
    [SerializeField] TMP_Text BtnText;
    //[SerializeField] GameObject EquipAndBuyBtn;
    private ItemAbility itemInfo;
    private void Start()
    {
        GameManager.Instance.PopUpOpen += Info;
        PanelUI.SetActive(false);
    }

    public void CancleBtnSet()
    {
        PanelUI.SetActive(false);
    }
    public void ItemUpdateBtnSet()
    {
        bool check = itemInfo.Equip;
        GameManager.Instance.EquipSet();
        if (!check)
        {
            GameManager.Player.GetComponent<PlayerAbility>().playerItemSet(itemInfo);
            itemInfo.Equip = true;
        }
        else
        {
            GameManager.Player.GetComponent<PlayerAbility>().playerItemSet(null);
            itemInfo.Equip = false;
        }
        GameManager.Instance.EquipUpdate();
        PanelUI.SetActive(false);
    }
    public void Info(ItemAbility item, int choice)
    {
        //버튼에 이벤트 지우기 추가해야함
        itemInfo = item;
        PanelUI.SetActive(true);
        Transform transform = gameObject.transform;
        transform.GetChild(1).GetComponent<Image>().sprite = GameManager.Instance.ResourceManager.ItemImgSet(item.Key);
        transform.GetChild(2).GetComponent<TMP_Text>().text = item.ItemName;
        transform.GetChild(3).GetComponent<TMP_Text>().text = $"{item.Info}\n공격력 : {item.Attack} 방어력 : {item.Defensive} 체력 : {item.Health} 치명타 : {item.Fatal}";
        if (item.Equip && choice == 0) BtnText.text = "해제";
        else if(!item.Equip && choice == 0) BtnText.text = "장착";
        else if(choice == 1) BtnText.text = $"{item.price}";
    }

}