using App.Enums;
using App.Models;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace App
{
    public class NetworkManager : SingletonBase<NetworkManager>
    {
        private const string BaseURL = "https://wadahub.manerai.com/api";
        private const string InventoryBaseURL = BaseURL + "/inventory/status";
        
        private string authToken = "Bearer kPERnYcWAY46xaSy8CEzanosAgsWM84Nx7SKM4QBSqPq6c7StWfGxzhxPfDh8MaP";
        
        public async UniTask<bool> ExecuteInventoryAction(InventoryItemModel item, InventoryActionType action)
        {
            using UnityWebRequest request = new UnityWebRequest(InventoryBaseURL, UnityWebRequest.kHttpVerbPOST);
            
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", authToken);

            InventoryActionPayloadModel payload = new InventoryActionPayloadModel(item.Id, action);

            string json = JsonUtility.ToJson(payload);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
            
            request.uploadHandler = new UploadHandlerRaw(bytes);
            
            await request.SendWebRequest();
            
            return request.result == UnityWebRequest.Result.Success;
        }
    }
}
