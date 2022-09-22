using UnityEngine;

namespace GizmosHelpers
{
    [System.Serializable]
    public class WireSphereGizmo : SphereGizmo
    {
        public WireSphereGizmo(Vector3 center, float radius, float lifeTime = -1) : base(center, radius, lifeTime)
        {
        }

        protected override void DrawGizmoVisuals()
        {
            Gizmos.DrawWireSphere(Center, Radius);
        }
    }
}
