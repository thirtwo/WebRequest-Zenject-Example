using System.Collections;
using UnityEngine.Networking;
using System;
namespace thirtwo.API
{
    using Interfaces;

    public class ImdbTextAPI : IRequestAPI<string>
    {
        #region Events
        public event Action<string> APIRequestFailed;
        public event Action<string> APIRequestSucceed;
        #endregion
        #region Variables
        private readonly ImdbTextAPIData apiData;
        private readonly CoroutineHandler coroutineHandler;
        #endregion
        #region Constructor
        public ImdbTextAPI(ImdbTextAPIData apiData, CoroutineHandler coroutineHandler)
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

            if (request.result == UnityWebRequest.Result.Success)
            {
                APIRequestSucceed?.Invoke(request.downloadHandler.text);
            }
            else
            {
                APIRequestFailed?.Invoke(request.error);
            }
        }
        #endregion
    }
}
