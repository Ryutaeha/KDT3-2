using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager
{
    public Sprite ItemImgSet(string itemKey)
    {
        string baseName = itemKey.Contains("Item") ? itemKey.Replace("Item", "").TrimEnd() : itemKey;
        // �̹��� ������ ��� (��: "Assets/Resources/Images/myImage.png")
        string imagePath = $"ItemImg/Spum_Icon{baseName}"; // Resources ���� ���� Images ������ myImage.png�� �ִٰ� ����

        // Resources ���� ������ �̹��� �ε�
        Sprite loadedSprite = Resources.Load<Sprite>(imagePath);

        return loadedSprite;

    }

}
