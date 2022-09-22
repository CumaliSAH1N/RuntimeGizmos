using UnityEngine;

namespace GizmosHelpers
{
    [System.Serializable]
    public class RayGizmo : GizmoBase
    {
        [SerializeField] private Vector3 RayStart;
        [SerializeField] private Vector3 RayDirection;

        public RayGizmo(Vector3 rayStart, Vector3 rayDirection, float lifeTime = -1.0f) : base(lifeTime)
        {
            RayStart = rayStart;
            RayDirection = rayDirection;
        }

        protected override void DrawGizmoVisuals()
        {
            Gizmos.DrawRay(RayStart, RayDirection);
        }
    }
}