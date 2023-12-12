using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class ItemAbility
{
    public string Key;
    public string ItemName;
    public int Health;
    public int Attack;
    public int Defensive;
    public int Fatal;
    public int price;
    public string Info;
    public bool Equip;
}

[System.Serializable]
public class ItemContainer
{
    public Dictionary<string, ItemAbility> Items = new Dictionary<string, ItemAbility>();

}
public class JsonLordManager
{
    //오브젝트의 이름으로 데이터 얻어오기
    public ItemAbility ItemsSettings(string itemName)
    {

        // "(Clone)"이 포함되어 있으면 제외, 없으면 그대로
        string baseName = itemName.Contains("(Clone)") ? itemName.Replace("(Clone)", "").TrimEnd() : itemName;
        ItemContainer itemContainer = new ItemContainer();

        // 파일 경로 설정
        TextAsset jsonFile = Resources.Load<TextAsset>("Json/ItemDate");

        // 파일이 존재하는지 확인
        if (jsonFile!=null)
        {
            // 파일 내용 읽기
            //string itemString = File.ReadAllText(filePath);

            // JSON 문자열을 객체로 역직렬화 (Newtonsoft.Json 사용)
            //itemContainer = JsonConvert.DeserializeObject<ItemContainer>(itemString);
            itemContainer = JsonConvert.DeserializeObject<ItemContainer>(jsonFile.text);
            // 특정 플레이어 가져오기
            string targetItemSettingsKey = baseName;
            if (itemContainer.Items.ContainsKey(targetItemSettingsKey))
            {
                //받은 오브젝트 이름을 키값으로 해당 값이 들어있는 json객체를 JobSettings으로 포맷하여 넣어줌
                ItemAbility targetItemSettings = itemContainer.Items[targetItemSettingsKey];
                targetItemSettings.Key = targetItemSettingsKey;
                //성공시 데이터 리턴
                return targetItemSettings;
            }
            else
            {
                Debug.LogError("Job not found: " + targetItemSettingsKey);
            }
        }
        else
        {
            Debug.LogError("File not found: ");
        }
        //실패시 null 리턴
        return null;
    }
    public List<string> ItemsName()
    {

        ItemContainer itemContainer = new ItemContainer();

        // 파일 경로 설정
        TextAsset jsonFile = Resources.Load<TextAsset>("Json/ItemDate");

        // 파일이 존재하는지 확인
        if (jsonFile != null)
        {
            itemContainer = JsonConvert.DeserializeObject<ItemContainer>(jsonFile.text);
            return itemContainer.Items.Keys.ToList();
        }
        else
        {
            Debug.LogError("File not found: ");
        }
        //실패시 null 리턴
        return null;
    }
}
