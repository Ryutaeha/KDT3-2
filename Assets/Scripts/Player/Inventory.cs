using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemAbility> items = new List<ItemAbility>();
    public List<ItemAbility> Items { get { return items; } set { items = value; } }

    public void Start()
    {
        items.Add(GameManager.Instance.JsonLordManager.ItemsSettings("Item1"));
        items.Add(GameManager.Instance.JsonLordManager.ItemsSettings("Item2"));
        items.Add(GameManager.Instance.JsonLordManager.ItemsSettings("Item3"));
        ItemSet(items[1]);
    }

    public void AddItem(ItemAbility item)
    {
        items.Add(item);
    }
    public void ItemSet(ItemAbility itemAbility)
    {
        itemAbility.Equip = true;
        gameObject.GetComponent<PlayerAbility>().playerItemSet(itemAbility);
    }
}
