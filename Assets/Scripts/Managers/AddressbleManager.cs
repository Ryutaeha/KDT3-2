
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressbleManager
{


    public void ReleaseObj(AsyncOperationHandle<GameObject> async)
    {
        // 핸들이 아직 사용 중인지 확인
        if (async.IsValid())
        {
            // 비동기 작업이 완료될 때까지 대기
            async.Completed += handle =>
            {
                Debug.Log("Handle completed. Trying to release.");

                // 완료되면 핸들을 해제
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
            // 핸들이 이미 무효화되었으면 바로 해제
            Debug.LogWarning("이미 무효화된 핸들을 해제하려고 시도하였습니다.");
        }
    }
    public AsyncOperationHandle<GameObject> CreateObj(string name, Transform parent)
    {
        // 어드레서블 그룹 이름과 오브젝트 이름을 사용하여 AssetReference 생성
        AssetReference assetReference = new AssetReference($"{name}");

        // 어드레서블 오브젝트를 비동기적으로 인스턴스화
        AsyncOperationHandle<GameObject> handle = assetReference.InstantiateAsync(new Vector3(0,0,0), Quaternion.identity, parent);
        return handle;
        //Addressables.Release(handle);
    }
}
