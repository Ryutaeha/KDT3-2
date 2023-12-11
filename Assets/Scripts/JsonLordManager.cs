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
    //������Ʈ�� �̸����� ������ ������
    public ItemAbility AbilitySettings(string itemName)
    {

        // "(Clone)"�� ���ԵǾ� ������ ����, ������ �״��
        string baseName = itemName.Contains("(Clone)") ? itemName.Replace("(Clone)", "").TrimEnd() : itemName;
        ItemContainer itemContainer = new ItemContainer();

        // ���� ��� ����
        string filePath = Path.Combine(Application.dataPath, "Resources/Json/CharacterDate.json");

        // ������ �����ϴ��� Ȯ��
        if (File.Exists(filePath))
        {
            // ���� ���� �б�
            string jsonString = File.ReadAllText(filePath);

            // JSON ���ڿ��� ��ü�� ������ȭ (Newtonsoft.Json ���)
            itemContainer = JsonConvert.DeserializeObject<ItemContainer>(jsonString);

            // Ư�� �÷��̾� ��������
            string targetJobSettingsKey = baseName;
            if (itemContainer.Jobs.ContainsKey(targetJobSettingsKey))
            {
                //���� ������Ʈ �̸��� Ű������ �ش� ���� ����ִ� json��ü�� JobSettings���� �����Ͽ� �־���
                ItemAbility targetJobSettings = itemContainer.Jobs[targetJobSettingsKey];
                //������ ������ ����
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
        //���н� null ����
        return null;
    }

}
