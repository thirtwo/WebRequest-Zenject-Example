using thirtwo.API;
using thirtwo.API.Interfaces;
using UnityEngine;
using Zenject;
namespace thirtwo.Zenject.Installers
{
    public class APIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ImdbImageAPIData>().AsSingle();
            Container.Bind<ImdbTextAPIData>().AsSingle();
            Container.Bind<IRequestAPI<string>>().To<ImdbTextAPI>().AsSingle();
            Container.Bind<IRequestAPI<Texture2D>>().To<ImdbImageAPI>().AsSingle();
        }
    }
}
