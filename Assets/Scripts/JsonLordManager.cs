using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemAbility
{
    private int health;
    private int attack;
    private int defensive;
    private int fatal;
}

[System.Serializable]
public class ItemContainer
{
    public Dictionary<string, ItemAbility> Jobs = new Dictionary<string, ItemAbility>();

}
public class JsonLordManager
{
    //오브젝트의 이름으로 데이터 얻어오기
    public ItemAbility AbilitySettings(string itemName)
    {

        // "(Clone)"이 포함되어 있으면 제외, 없으면 그대로
        string baseName = itemName.Contains("(Clone)") ? itemName.Replace("(Clone)", "").TrimEnd() : itemName;
        ItemContainer itemContainer = new ItemContainer();

        // 파일 경로 설정
        string filePath = Path.Combine(Application.dataPath, "Resources/Json/CharacterDate.json");

        // 파일이 존재하는지 확인
        if (File.Exists(filePath))
        {
            // 파일 내용 읽기
            string jsonString = File.ReadAllText(filePath);

            // JSON 문자열을 객체로 역직렬화 (Newtonsoft.Json 사용)
            itemContainer = JsonConvert.DeserializeObject<ItemContainer>(jsonString);

            // 특정 플레이어 가져오기
            string targetJobSettingsKey = baseName;
            if (itemContainer.Jobs.ContainsKey(targetJobSettingsKey))
            {
                //받은 오브젝트 이름을 키값으로 해당 값이 들어있는 json객체를 JobSettings으로 포맷하여 넣어줌
                ItemAbility targetJobSettings = itemContainer.Jobs[targetJobSettingsKey];
                //성공시 데이터 리턴
                return targetJobSettings;
            }
            else
            {
                Debug.LogError("Job not found: " + targetJobSettingsKey);
            }
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
        //실패시 null 리턴
        return null;
    }

}
