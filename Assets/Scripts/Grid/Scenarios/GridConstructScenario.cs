using System;
using FrostPunk.Grid.ScriptableObjects;
using FrostPunk.Grid.Services;
using UnityEngine;
using Zenject;

namespace FrostPunk.Grid.Scenarios
{
    public class GridConstructScenario : MonoBehaviour
    {
        [Inject] private readonly GridConfig _config;
        [Inject] private readonly GridConstructorService _constructorService;
        
        private void OnDrawGizmos()
        {
            if(_constructorService == null)
                return;
            
            for (int z = 0; z < _config.Height; z++)
            {
                for (int x = 0; x < _config.Width; x++)
                {
                    var center = _constructorService.GetHexagonCenter(x, z) + transform.position;

                    for (int i = 0; i < _constructorService.GetHexagonCorners().Length; i++)
                    {
                        Gizmos.DrawLine(center + _constructorService.GetHexagonCorners()[i % 6],
                            center + _constructorService.GetHexagonCorners()[(i + 1) % 6]);
                    }
                }
            }
        }
    }
}