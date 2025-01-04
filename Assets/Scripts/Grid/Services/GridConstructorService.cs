using FrostPunk.Grid.ScriptableObjects;
using FrostPunk.Grid.Types;
using UnityEngine;
using Zenject;

namespace FrostPunk.Grid.Services
{
    public class GridConstructorService
    {
        [Inject] private readonly GridConfig _config;

        public Vector3 GetHexagonCenter(int x, int z)
        {
            return GetHexagonCenter(_config.Orientation, x, z);
        }

        public Vector3[] GetHexagonCorners()
        {
            return GetHexagonCorners(_config.CellSize, _config.Orientation);
        }

        private Vector3 GetHexagonCenter(GridOrientation orientation, int x, int z)
        {
            var center = new Vector3();
            if (orientation == GridOrientation.PointyTop)
            {
                center.x = (x + z * 0.5f - Mathf.Floor(z / 2f)) * (_config.InnerRadius * 2f);
                center.y = 0f;
                center.z = z * (_config.OuterRadius * 1.5f);
            }
            else
            {
                center.x = x * _config.OuterRadius * 1.5f;
                center.y = 0f;
                center.z = (z + x * 0.5f - Mathf.Floor(x / 2f)) * (_config.InnerRadius * 2f);
            }

            return center;
        }

        private Vector3[] GetHexagonCorners(float cellSize, GridOrientation orientation)
        {
            var corners = new Vector3[6];
            for (int i = 0; i < corners.Length; i++)
            {
                corners[i] = GetHexagonCorner(cellSize, i, orientation);
            }

            return corners;
        }

        private Vector3 GetHexagonCorner(float cellSize, int index, GridOrientation orientation)
        {
            var angle = 60f * index;
            if (orientation == GridOrientation.PointyTop)
            {
                angle += 30f;
            }

            var corner = new Vector3(cellSize * Mathf.Cos(angle * Mathf.Deg2Rad),
                0f,
                cellSize * Mathf.Sin(angle * Mathf.Deg2Rad));

            return corner;
        }
    }
}