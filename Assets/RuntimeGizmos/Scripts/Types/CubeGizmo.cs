using UnityEngine;

namespace GizmosHelpers
{
    [System.Serializable]
    public class CubeGizmo : GizmoBase
    {
        [SerializeField] protected Vector3 Center;
        [SerializeField] protected Vector3 Size;

        public CubeGizmo(Vector3 center, Vector3 size, float lifeTime = -1) : base(lifeTime)
        {
            Center = center;
            Size = size;
        }

        protected override void DrawGizmoVisuals()
        {
            Gizmos.DrawCube(Center, Size);
        }
    }
}