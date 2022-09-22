using UnityEngine;

namespace GizmosHelpers
{
    [System.Serializable]
    public class IconGizmo : GizmoBase
    {
        [SerializeField] private Vector3 Center;
        [SerializeField] private string Name;
        [SerializeField] private bool AllowScaling;
        [SerializeField] private Color Tint;

        public IconGizmo(Vector3 center, string name, bool allowScaling, Color tint, float lifeTime = -1) :
            base(lifeTime)
        {
            Center = center;
            Name = name;
            AllowScaling = allowScaling;
            Tint = tint;
        }

        protected override void DrawGizmoVisuals()
        {
            Gizmos.DrawIcon(Center, Name, AllowScaling, Tint);
        }
    }
}