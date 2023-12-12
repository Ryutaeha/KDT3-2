using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GameManager : MonoBehaviour
{
    private JsonLordManager jsonLordManager = new JsonLordManager();
    private AddressbleManager addressbleManager = new AddressbleManager();
    private ResourceManager resourceManager = new ResourceManager();
    private static GameManager instance;
    public static GameObject Player {  get { return Instance.player; }}

    private GameObject player;
    
    public event Action<GameObject> PlayerSet;
    public event Action ItemUpdate;
    public event Action<ItemAbility, int> PopUpOpen;

    public JsonLordManager JsonLordManager { get { return Instance.jsonLordManager; } }
    public AddressbleManager AddressbleManager {  get { return Instance.addressbleManager; }}
    public ResourceManager ResourceManager { get { return Instance.resourceManager; }}
    // 싱글톤화
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject container = new GameObject("GameManager");
                    instance = container.AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);

        instance = this;

        PlayerCreate();
        ItemAbility item = jsonLordManager.ItemsSettings("Item1");
        Debug.Log($"{item.Key}  {item.ItemName}  {item.Attack}  {item.Defensive}  {item.Health}  {item.Fatal} {item.Info}");
    }


    public async void PlayerCreate()
    {
        // 어드레서블 그룹 이름과 오브젝트 이름을 사용하여 AssetReference 생성
        AssetReference assetReference = new AssetReference($"Player");

        // 어드레서블 오브젝트를 비동기적으로 인스턴스화
        AsyncOperationHandle<GameObject> handle = assetReference.InstantiateAsync(new Vector3(-1, -2, 0), Quaternion.identity);

        await handle.Task;

        player = handle.Result;
        
        PlayerSet?.Invoke(player);

        //Addressables.Release(handle);
    }
    public void EquipSet()
    {
        List<ItemAbility> items = Player.GetComponent<Inventory>().Items;
        foreach (ItemAbility item in items)
        {
            if (item.Equip) item.Equip = false;
        }
    }

    internal void EquipUpdate()
    {
        ItemUpdate?.Invoke();
    }

    internal void OpenPopUpUI(ItemAbility itemInfo, int choice)
    {
        PopUpOpen?.Invoke(itemInfo , choice);
    }
}
