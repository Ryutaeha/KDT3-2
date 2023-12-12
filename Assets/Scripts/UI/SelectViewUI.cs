using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class SelectViewUI : MonoBehaviour
{
    [SerializeField] TMP_Text playerGold;
    [SerializeField] TMP_Text selectPanel;
    [SerializeField] Button exitBtn;
    [SerializeField] GameObject Items;
    [SerializeField] GameObject ItemBox;
    GameObject player;
    private void Start()
    {
        GameManager.Instance.PlayerSet += SetPlayer;
        GameManager.Instance.ItemUpdate += EquipUpdate;
        gameObject.SetActive(false);
    }

    private void SetPlayer(GameObject player)
    {
        this.player = player;
        GoldSet();
    }
    private void GoldSet()
    {
        playerGold.text = player.GetComponent<PlayerAbility>().PlayerGold.ToString();
    }
    public void view(bool set)
    {
        if(!set) 
        {
            exitBtn.onClick.RemoveAllListeners();
            exitBtn.onClick.AddListener(() => view(false));
        }
        gameObject.SetActive(set);
        
    }
    public void selectView(int selectView)
    {
        switch (selectView)
        {
            case 0:
                StatusView();
                break;
            case 1:
                InventoryView();
                break;
            case 2:
                ShopView();
                break;
            case 3:
                BankView();
                break;
        }
    }

    private void BankView()
    {
        selectPanel.text = "은행";
        Debug.Log("BankView");
    }

    private void ShopView()
    {
        selectPanel.text = "상점";
        Debug.Log("ShopView");
    }

    private void InventoryView()
    {

        selectPanel.text = "인벤토리";
        ItemBox.transform.parent.parent.gameObject.SetActive(true);
        List<ItemAbility> inventory = player.GetComponent<Inventory>().Items;
        for (int i = 0; i < inventory.Count; i++)
        {
            GameObject instantiatedPrefab = Instantiate(Items, new Vector3(0, 0, 0), Quaternion.identity, ItemBox.transform);
            instantiatedPrefab.transform.GetChild(0).GetComponent<Item>().ItemSet(inventory[i], 0);
        }
        exitBtn.onClick.AddListener(() => ClearAllChildren());
    }

    private void ClearAllChildren()
    {
        // 부모 게임 오브젝트의 모든 자식을 반복
        foreach (Transform child in ItemBox.transform)
        {
            // 각 자식 오브젝트를 삭제
            Destroy(child.gameObject);
        }
        ItemBox.transform.parent.parent.gameObject.SetActive(false);
    }

    private async void StatusView()
    {
        selectPanel.text = "캐릭터 정보";
        AsyncOperationHandle<GameObject> view = GameManager.Instance.AddressbleManager.CreateObj("StatusUI",gameObject.transform);
        await view.Task;
        view.Result.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        view.Result.GetComponent<StatusUI>().StatusView(GameManager.Player);
        exitBtn.onClick.AddListener(() => StatusViewReleaseObj(view));


    }

    private void StatusViewReleaseObj(AsyncOperationHandle<GameObject> view)
    {
        GameManager.Instance.AddressbleManager.ReleaseObj(view);
    }
    public void EquipUpdate()
    {
        foreach (Transform child in ItemBox.transform)
        { 
            Item item = child.GetChild(0).GetComponent<Item>();
            item.ItemEquipSet(item.ItemInfo.Equip);
        }
    }
}
