using UnityEngine;

namespace GizmosHelpers
{
    [System.Serializable]
    public class WireCubeGizmo : CubeGizmo
    {
        public WireCubeGizmo(Vector3 center, Vector3 size, float lifeTime = -1) : base(center, size, lifeTime)
        {
        }

        protected override void DrawGizmoVisuals()
        {
            Gizmos.DrawWireCube(Center, Size);
        }
    }
}