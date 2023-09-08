using System.Collections;
using thirtwo.API.Interfaces;
using UnityEngine;
using Zenject;

namespace thirtwo.Managers.SceneManagement
{
    public class SceneManager : MonoBehaviour
    {
        private CoroutineHandler coroutineHandler;
        private IRequestAPI<string> textAPI;
        [Inject]
        private void Construct(CoroutineHandler coroutineHandler, IRequestAPI<string> textAPI)
        {
            this.coroutineHandler = coroutineHandler;
            this.textAPI = textAPI;
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeTheScene();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                TestAPI();
            }
        }
        private void TestAPI()
        {
            textAPI.GetAPIData();
            textAPI.APIRequestSucceed += (string apiText) =>
            {
                Debug.Log(apiText);
            };
            textAPI.APIRequestFailed += (string apiText) =>
            {
                Debug.LogError(apiText);
            };
        }
        private void ChangeTheScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        private void TestTheCoroutienHandler()
        {
            coroutineHandler.StartCoroutine(TestCO());
        }
        private IEnumerator TestCO()
        {
            yield return null;
            Debug.Log("Test");
        }
    }
}
