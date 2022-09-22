using UnityEngine;

namespace GizmosHelpers
{
    [System.Serializable]
    public class WireMeshGizmo : MeshGizmo
    {
        public WireMeshGizmo(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation, Vector3 scale,
            float lifeTime = -1) : base(mesh, submeshIndex, position, rotation, scale, lifeTime)
        {
        }

        protected override void DrawGizmoVisuals()
        {
            Gizmos.DrawWireMesh(Mesh, SubmeshIndex, Position, Rotation, Scale);
        }
    }
}