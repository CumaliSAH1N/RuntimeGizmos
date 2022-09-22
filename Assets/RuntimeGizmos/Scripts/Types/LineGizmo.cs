using UnityEngine;

namespace GizmosHelpers
{
    [System.Serializable]
    public class LineGizmo : GizmoBase
    {
        [SerializeField] private Vector3 LineStart;
        [SerializeField] private Vector3 LineEnd;

        public LineGizmo(Vector3 lineStart, Vector3 lineEnd, float lifeTime = -1) : base(lifeTime)
        {
            LineStart = lineStart;
            LineEnd = lineEnd;
        }

        protected override void DrawGizmoVisuals()
        {
            Gizmos.DrawLine(LineStart, LineEnd);
        }
    }
}