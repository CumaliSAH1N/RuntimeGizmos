using UnityEngine;

namespace GizmosHelpers
{
    [System.Serializable]
    public class SphereGizmo : GizmoBase
    {
        [SerializeField] protected Vector3 Center;
        [SerializeField] protected float Radius;

        public SphereGizmo(Vector3 center, float radius, float lifeTime = -1.0f) : base(lifeTime)
        {
            Center = center;
            Radius = radius;
        }

        protected override void DrawGizmoVisuals()
        {
            Gizmos.DrawSphere(Center, Radius);
        }
    }
}