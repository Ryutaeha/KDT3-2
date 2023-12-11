using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> items = new List<GameObject>();
    public List<GameObject> Item { get { return items; } set { items = value; } }
    
    public void AddItem(GameObject item)
    {
        items.Add(item);
    }
}
