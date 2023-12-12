using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public void ItemSet(string ItemKey)
    {
        ItemAbility item = GameManager.Instance.JsonLordManager.ItemsSettings(ItemKey);
        ItemImgSet(item.Key);
        ItemTextSet(item.ItemName);
    }
    private void ItemImgSet(string itemKey)
    {
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
        
    }
    Sprite LoadSpriteFromResources(string path)
    {
        // Resources 폴더 내에서 이미지 로드
        return Resources.Load<Sprite>(path);
    }
    private void ItemTextSet(string itemName)
    {
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = itemName;
    }

}
