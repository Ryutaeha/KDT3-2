using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

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
        transform.GetChild(3).GetComponent<TMP_Text>().text = $"{item.Info}\n���ݷ� : {item.Attack} ���� : {item.Defensive} ü�� : {item.Health} ġ��Ÿ : {item.Fatal}";
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
    [SerializeField] GameObject panelUI;
    [SerializeField] Button equipAndBuyBtn;
    [SerializeField] GameObject buyPopUp;
    //[SerializeField] GameObject EquipAndBuyBtn;
    private ItemAbility itemInfo;
    private void Start()
    {
        GameManager.Instance.PopUpOpen += Info;
        panelUI.SetActive(false);
    }

    public void CancleBtnSet()
    {
        panelUI.SetActive(false);
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
        panelUI.SetActive(false);
    }
    public void Info(ItemAbility item, int choice)
    {
        
        itemInfo = item;
        panelUI.SetActive(true);
        InfoTooltip(item, choice);
        EquipAndBuyBtnSet(choice);
        
    }

    private void EquipAndBuyBtnSet(int choice)
    {
        equipAndBuyBtn.onClick.RemoveAllListeners();
        if(choice == 0) equipAndBuyBtn.onClick.AddListener(() => { ItemUpdateBtnSet(); });
        else if(choice == 1) equipAndBuyBtn.onClick.AddListener(() => { ItemBuyBtnSet(); });
    }

    private void ItemBuyBtnSet()
    {
        bool buyCheck = GameManager.Instance.BuyItem(itemInfo);
        StartCoroutine(BuyPopUp(buyCheck));
    }

    private IEnumerator BuyPopUp(bool buyCheck)
    {
        buyPopUp.SetActive(true);
        buyPopUp.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = buyCheck ? "���� �Ϸ�" : "���� ����";
        yield return new WaitForSeconds(1.0f);
        if (buyCheck) panelUI.SetActive(false);
        buyPopUp.SetActive(false);
    }

    private void InfoTooltip(ItemAbility item, int choice)
    {
        Transform transform = gameObject.transform;
        transform.GetChild(0).GetComponent<TMP_Text>().text = $"�ش� ���⸦ {(choice == 0 ? "����" : "����")}�Ͻðڽ��ϱ�?";
        transform.GetChild(1).GetComponent<Image>().sprite = GameManager.Instance.ResourceManager.ItemImgSet(item.Key);
        transform.GetChild(2).GetComponent<TMP_Text>().text = item.ItemName;
        transform.GetChild(3).GetComponent<TMP_Text>().text = $"{item.Info}\n���ݷ� : {item.Attack} ���� : {item.Defensive} ü�� : {item.Health} ġ��Ÿ : {item.Fatal}";
        TMP_Text btnText = equipAndBuyBtn.transform.GetChild(0).GetComponent<TMP_Text>();
        if (item.Equip && choice == 0) btnText.text = "����";
        else if (!item.Equip && choice == 0) btnText.text = "����";
        else if (choice == 1) btnText.text = $"{item.price}";
    }
}