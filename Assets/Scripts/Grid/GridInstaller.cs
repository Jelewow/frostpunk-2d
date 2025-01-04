using FrostPunk.Grid.Scenarios;
using FrostPunk.Grid.ScriptableObjects;
using FrostPunk.Grid.Services;
using UnityEngine;
using Zenject;

namespace FrostPunk.Grid
{
    public class GridInstaller : MonoInstaller
    {
        [SerializeField] private GridConfig _gridConfig;
        [SerializeField] private GridConstructScenario _grid;
        
        public override void InstallBindings()
        {
            Container.Bind<GridConstructorService>().AsSingle().NonLazy();
            
            Container.BindInstance(_gridConfig).AsSingle().NonLazy();

            Container.BindInstance(_grid).AsSingle().NonLazy();
        }
    }
}