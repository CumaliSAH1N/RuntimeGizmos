using System;
using System.Collections.Generic;
using UnityEngine;

namespace GizmosHelpers
{
    public class GizmosDrawer : MonoSingleton<GizmosDrawer>
    {
        [Serializable]
        public class GizmoData
        {
            public Guid Id;
            public float DrawingStartTime;
            [SerializeReference] public GizmoBase Gizmo;
        }

        [SerializeField]
        private List<GizmoData> gizmosToDraw;

        protected override void OnAwake()
        {
            base.OnAwake();
            gizmosToDraw = new List<GizmoData>();
        }

        public Guid AddGizmo(GizmoBase gizmo)
        {
#if UNITY_EDITOR
            if (gizmo == null)
            {
                return Guid.Empty;
            }

            if (gizmosToDraw == null)
            {
                gizmosToDraw = new List<GizmoData>();
            }

            gizmosToDraw.Add(new GizmoData
            {
                Id = Guid.NewGuid(),
                DrawingStartTime = Time.time,
                Gizmo = gizmo
            });

            return gizmosToDraw[^1].Id;
#else
            return Guid.Empty;
#endif
        }

        public bool RemoveGizmo(Guid id)
        {
#if UNITY_EDITOR
            if (gizmosToDraw == null)
            {
                return false;
            }

            if (id == Guid.Empty)
            {
                return false;
            }

            int index = gizmosToDraw.FindIndex(g => g.Id.Equals(id));
            if (index < 0)
            {
                return false;
            }

            gizmosToDraw.RemoveAt(index);

            return true;
#else
            return false;
#endif
        }

        public GizmoBase GetGizmo(Guid id)
        {
#if UNITY_EDITOR
            if (gizmosToDraw == null)
            {
                return null;
            }

            if (id == Guid.Empty)
            {
                return null;
            }

            int index = gizmosToDraw.FindIndex(g => g.Id.Equals(id));
            return index < 0 ? null : gizmosToDraw[index].Gizmo;
#else
            return null;
#endif
        }

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            if (gizmosToDraw == null)
            {
                return;
            }

            UpdateGizmosDrawEligibility();
            DrawGizmos();
#endif
        }

        private void DrawGizmos()
        {
            int count = gizmosToDraw.Count;
            for (int i = 0; i < count; i++)
            {
                gizmosToDraw[i].Gizmo.Draw();
            }
        }

        private void UpdateGizmosDrawEligibility()
        {
            int count = gizmosToDraw.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                GizmoData data = gizmosToDraw[i];
                float lifeTime = data.Gizmo.LifeTime;
                if (lifeTime < 0.0f)
                {
                    continue;
                }

                if (Time.time - data.DrawingStartTime >= lifeTime)
                {
                    gizmosToDraw.RemoveAt(i);
                }
            }
        }

        public void Clear()
        {
            gizmosToDraw.Clear();
        }
    }
}