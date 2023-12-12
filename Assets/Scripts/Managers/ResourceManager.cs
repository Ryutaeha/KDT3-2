using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager
{
    public Sprite ItemImgSet(string itemKey)
    {
        string baseName = itemKey.Contains("Item") ? itemKey.Replace("Item", "").TrimEnd() : itemKey;
        // 이미지 파일의 경로 (예: "Assets/Resources/Images/myImage.png")
        string imagePath = $"ItemImg/Spum_Icon{baseName}"; // Resources 폴더 내의 Images 폴더에 myImage.png가 있다고 가정

        // Resources 폴더 내에서 이미지 로드
        Sprite loadedSprite = Resources.Load<Sprite>(imagePath);

        return loadedSprite;

    }

}
