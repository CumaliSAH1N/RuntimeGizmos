using UnityEngine;

namespace GizmosHelpers
{
    [System.Serializable]
    public class MeshGizmo : GizmoBase
    {
        [SerializeField] protected Mesh Mesh;
        [SerializeField] protected int SubmeshIndex;
        [SerializeField] protected Vector3 Position;
        [SerializeField] protected Quaternion Rotation;
        [SerializeField] protected Vector3 Scale;

        public MeshGizmo(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation, Vector3 scale,
            float lifeTime = -1) : base(lifeTime)
        {
            Mesh = mesh;
            SubmeshIndex = submeshIndex;
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }

        protected override void DrawGizmoVisuals()
        {
            Gizmos.DrawMesh(Mesh, SubmeshIndex, Position, Rotation, Scale);
        }
    }
}