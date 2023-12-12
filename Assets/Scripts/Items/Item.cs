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
        
    }
    Sprite LoadSpriteFromResources(string path)
    {
        // Resources ���� ������ �̹��� �ε�
        return Resources.Load<Sprite>(path);
    }
    private void ItemTextSet(string itemName)
    {
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = itemName;
    }

}
