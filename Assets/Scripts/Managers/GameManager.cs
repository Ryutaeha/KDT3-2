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
    private ItemManager itemManager = new ItemManager();
    private static GameManager instance;
    public static GameObject Player {  get { return Instance.player; }}

    private GameObject player;
    
    public event Action<GameObject> PlayerSet;

    public JsonLordManager JsonLordManager { get { return Instance.jsonLordManager; } }
    public AddressbleManager AddressbleManager {  get { return Instance.addressbleManager; }}
    public ItemManager ItemManager { get { return Instance.itemManager; }}
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

    private void Start()
    {
        itemManager.items = jsonLordManager.ItemsName();
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

}
