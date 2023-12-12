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
        // 이미지 파일의 경로 (예: "Assets/Resources/Images/myImage.png")
        string imagePath = $"ItemImg/Spum_Icon{baseName}"; // Resources 폴더 내의 Images 폴더에 myImage.png가 있다고 가정

        // Resources 폴더 내에서 이미지 로드
        Sprite loadedSprite = LoadSpriteFromResources(imagePath);

        // 스프라이트 할당
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
        // Resources 폴더 내에서 이미지 로드
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
