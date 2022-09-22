using System;
using UnityEngine;

namespace GizmosHelpers
{
    public class GizmoTester : MonoBehaviour
    {
#if UNITY_EDITOR
        private Guid id;

        private void Start()
        {
            GizmosDrawer.Instance.AddGizmo(new LineGizmo(Vector3.zero, Vector3.forward * 9.0f)
            {
                Color = Color.red
            });

            id = GizmosDrawer.Instance.AddGizmo(new SphereGizmo(Vector3.up, 0.5f)
            {
                Color = Color.blue
            });

            GizmosDrawer.Instance.AddGizmo(new WireSphereGizmo(Vector3.down, 0.5f)
            {
                Color = Color.magenta
            });
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RemoveGizmo();
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                ChangeGizmoColor();
            }
        }

        private void RemoveGizmo()
        {
            GizmosDrawer.Instance.RemoveGizmo(id);
        }

        private void ChangeGizmoColor()
        {
            GizmoBase gizmo = GizmosDrawer.Instance.GetGizmo(id);
            if (!gizmo)
            {
                Debug.LogError("null");
                return;
            }
            else
            {
                Debug.LogError("not null");
            }

            gizmo.Color = Color.yellow;
        }
#endif
    }
}