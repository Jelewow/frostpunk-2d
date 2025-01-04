using FrostPunk.Grid.Types;
using UnityEngine;

namespace FrostPunk.Grid.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Grid config", menuName = "FrostPunk/Configs/Grid")]
    public class GridConfig : ScriptableObject
    {
        [field: SerializeField] 
        public int Width { get; private set; }

        [field: SerializeField] 
        public int Height { get; private set; }

        [field: SerializeField] 
        public float CellSize { get; private set; }
        
        [field: SerializeField] 
        public GridOrientation Orientation { get; private set; }

        [field: SerializeField] 
        public GameObject CellPrefab { get; private set; }

        public float OuterRadius => CellSize;

        public float InnerRadius => CellSize * 0.866025404f;
    }
}