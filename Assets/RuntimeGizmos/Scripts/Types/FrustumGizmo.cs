using UnityEngine;

namespace GizmosHelpers
{
    [System.Serializable]
    public class FrustumGizmo : GizmoBase
    {
        [SerializeField] private Vector3 Center;
        [SerializeField] private float FieldOfView;
        [SerializeField] private float FarPlaneDistance;
        [SerializeField] private float NearPlaneDistance;
        [SerializeField] private float AspectRatio;

        public FrustumGizmo(Vector3 center, float fieldOfView, float farPlaneDistance, float nearPlaneDistance,
            float aspectRatio)
        {
            Center = center;
            FieldOfView = fieldOfView;
            FarPlaneDistance = farPlaneDistance;
            NearPlaneDistance = nearPlaneDistance;
            AspectRatio = aspectRatio;
        }

        protected override void DrawGizmoVisuals()
        {
            Gizmos.DrawFrustum(Center, FieldOfView, FarPlaneDistance, NearPlaneDistance, AspectRatio);
        }
    }
}