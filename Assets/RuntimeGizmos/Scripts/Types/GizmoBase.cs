using UnityEngine;

namespace GizmosHelpers
{
    [System.Serializable]
    public abstract class GizmoBase
    {
        public float LifeTime = -1.0f;
        public Color Color = Color.white;

        public GizmoBase(float lifeTime = -1.0f)
        {
            LifeTime = lifeTime;
        }
        
        public void Draw()
        {
            Color prevColor = Gizmos.color;
            Gizmos.color = Color;
            DrawGizmoVisuals();
            Gizmos.color = prevColor;
        }

        protected abstract void DrawGizmoVisuals();

        public static bool operator !(GizmoBase gizmo)
        {
            return gizmo == null;
        }
    }
}