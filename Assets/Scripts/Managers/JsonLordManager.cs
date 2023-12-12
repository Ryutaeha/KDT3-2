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
    //������Ʈ�� �̸����� ������ ������
    public ItemAbility ItemsSettings(string itemName)
    {

        // "(Clone)"�� ���ԵǾ� ������ ����, ������ �״��
        string baseName = itemName.Contains("(Clone)") ? itemName.Replace("(Clone)", "").TrimEnd() : itemName;
        ItemContainer itemContainer = new ItemContainer();

        // ���� ��� ����
        TextAsset jsonFile = Resources.Load<TextAsset>("Json/ItemDate");

        // ������ �����ϴ��� Ȯ��
        if (jsonFile!=null)
        {
            // ���� ���� �б�
            //string itemString = File.ReadAllText(filePath);

            // JSON ���ڿ��� ��ü�� ������ȭ (Newtonsoft.Json ���)
            //itemContainer = JsonConvert.DeserializeObject<ItemContainer>(itemString);
            itemContainer = JsonConvert.DeserializeObject<ItemContainer>(jsonFile.text);
            // Ư�� �÷��̾� ��������
            string targetItemSettingsKey = baseName;
            if (itemContainer.Items.ContainsKey(targetItemSettingsKey))
            {
                //���� ������Ʈ �̸��� Ű������ �ش� ���� ����ִ� json��ü�� JobSettings���� �����Ͽ� �־���
                ItemAbility targetItemSettings = itemContainer.Items[targetItemSettingsKey];
                targetItemSettings.Key = targetItemSettingsKey;
                //������ ������ ����
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
        //���н� null ����
        return null;
    }
    public List<string> ItemsName()
    {

        ItemContainer itemContainer = new ItemContainer();

        // ���� ��� ����
        TextAsset jsonFile = Resources.Load<TextAsset>("Json/ItemDate");

        // ������ �����ϴ��� Ȯ��
        if (jsonFile != null)
        {
            itemContainer = JsonConvert.DeserializeObject<ItemContainer>(jsonFile.text);
            return itemContainer.Items.Keys.ToList();
        }
        else
        {
            Debug.LogError("File not found: ");
        }
        //���н� null ����
        return null;
    }
}
