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
        if (choice == 0) selectBtn.onClick.AddListener(() => { OnEquipSet(choice); });
    }


    public void ItemEquipSet(bool equip)
    {
        if(equip) gameObject.transform.GetChild(2).gameObject.SetActive(true);
        else gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }

    private void ItemImgSet(string itemKey)
    {
        /*
        string baseName = itemKey.Contains("Item") ? itemKey.Replace("Item", "").TrimEnd() : itemKey;
        Image imageRenderer = gameObject.transform.GetChild(0).GetComponent<Image>();
        // �̹��� ������ ��� (��: "Assets/Resources/Images/myImage.png")
        string imagePath = $"ItemImg/Spum_Icon{baseName}"; // Resources ���� ���� Images ������ myImage.png�� �ִٰ� ����

        // Resources ���� ������ �̹��� �ε�
        Sprite loadedSprite = LoadSpriteFromResources(imagePath);

        // ��������Ʈ �Ҵ�
        if (loadedSprite != null)
        {
            imageRenderer.sprite = loadedSprite;
        }
        else
        {
            Debug.LogError("Failed to load the sprite.");
        }
         */
        Image imageRenderer = gameObject.transform.GetChild(0).GetComponent<Image>();
        imageRenderer.sprite = GameManager.Instance.ResourceManager.ItemImgSet(itemKey);

    }
    /*
    Sprite LoadSpriteFromResources(string path)
    {
        // Resources ���� ������ �̹��� �ε�
        return Resources.Load<Sprite>(path);
    }
     */
    private void ItemTextSet(string itemName)
    {
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = itemName;
    }

    public void OnEquipSet(int choice)
    {
        GameManager.Instance.OpenPopUpUI(itemInfo, choice);
        /*
        GameManager.Instance.EquipSet();
        if (!itemInfo.Equip)
        {
            //GameManager.Player.GetComponent<PlayerAbility>().playerItemSet(itemInfo);
            //itemInfo.Equip = true;
        }
        else
        {
            //GameManager.Player.GetComponent<PlayerAbility>().playerItemSet(null);
            //itemInfo.Equip = false;
        }
        GameManager.Instance.EquipUpdate();
        */
    }

    
}
