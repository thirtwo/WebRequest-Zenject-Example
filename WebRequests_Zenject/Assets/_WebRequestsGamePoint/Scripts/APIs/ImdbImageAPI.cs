using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Networking;
namespace thirtwo.API
{
    using Interfaces;
    public class ImdbImageAPI : IRequestAPI<Texture2D>
    {
        #region Events
        public event Action<string> APIRequestFailed;
        public event Action<Texture2D> APIRequestSucceed;
        #endregion
        #region Variables
        private readonly ImdbImageAPIData apiData;
        private readonly CoroutineHandler coroutineHandler;
        #endregion
        #region Constructor
        public ImdbImageAPI(ImdbImageAPIData apiData, CoroutineHandler coroutineHandler)
        {
            this.apiData = apiData;
            this.coroutineHandler = coroutineHandler;
        }
        #endregion
        #region Request Methods
        public void GetAPIData()
        {
            coroutineHandler.StartCoroutine(ProcessRequestCO());
        }
        private IEnumerator ProcessRequestCO()
        {
            using UnityWebRequest request = UnityWebRequest.Get(apiData.APIUrl);

            request.SetRequestHeader("X-RapidAPI-Host", apiData.APIHost);
            request.SetRequestHeader("X-RapidAPI-Key", apiData.APIKey);

            yield return request.SendWebRequest();

            var texture = DownloadHandlerTexture.GetContent(request);
            if (request.result == UnityWebRequest.Result.Success && texture != null)
            {
                APIRequestSucceed?.Invoke(texture);
            }
            else
            {
                APIRequestFailed?.Invoke(request.error);
            }
        }
        #endregion
    }
}
