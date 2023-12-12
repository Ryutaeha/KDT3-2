
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressbleManager
{


    public void ReleaseObj(AsyncOperationHandle<GameObject> async)
    {
        // �ڵ��� ���� ��� ������ Ȯ��
        if (async.IsValid())
        {
            // �񵿱� �۾��� �Ϸ�� ������ ���
            async.Completed += handle =>
            {
                Debug.Log("Handle completed. Trying to release.");

                // �Ϸ�Ǹ� �ڵ��� ����
                try
                {
                    Addressables.Release(handle);
                    Debug.Log("Release successful.");
                }
                catch (Exception e)
                {
                    Debug.LogError($"Release failed with error: {e.Message}");
                }
            };
        }
        else
        {
            // �ڵ��� �̹� ��ȿȭ�Ǿ����� �ٷ� ����
            Debug.LogWarning("�̹� ��ȿȭ�� �ڵ��� �����Ϸ��� �õ��Ͽ����ϴ�.");
        }
    }
    public AsyncOperationHandle<GameObject> CreateObj(string name, Transform parent)
    {
        // ��巹���� �׷� �̸��� ������Ʈ �̸��� ����Ͽ� AssetReference ����
        AssetReference assetReference = new AssetReference($"{name}");

        // ��巹���� ������Ʈ�� �񵿱������� �ν��Ͻ�ȭ
        AsyncOperationHandle<GameObject> handle = assetReference.InstantiateAsync(new Vector3(0,0,0), Quaternion.identity, parent);
        return handle;
        //Addressables.Release(handle);
    }
}
