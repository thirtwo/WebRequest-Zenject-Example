using UnityEngine;
using Zenject;
namespace thirtwo.Zenject.Installers
{
    [CreateAssetMenu(fileName = "PrefabsSOInstaller", menuName = "Installers/PrefabsSOInstaller")]
    public class PrefabsSOInstaller : ScriptableObjectInstaller<PrefabsSOInstaller>
    {
        [SerializeField] private ManagersSO managersSO;
        public override void InstallBindings()
        {
            Container.BindInstance(managersSO).NonLazy();
            Container.Bind<CoroutineHandler>().FromComponentInNewPrefab(managersSO.CoroutineHandler).AsSingle();
        }
    }
}