using UnityEngine;

namespace GizmosHelpers
{
    [System.Serializable] 
    public class GUITextureGizmo : GizmoBase
    {
        [SerializeField] private Rect ScreenRect;
        [SerializeField] private Texture Texture;
        [SerializeField] private int LeftBorder;
        [SerializeField] private int RightBorder;
        [SerializeField] private int TopBorder;
        [SerializeField] private int BottomBorder;
        [SerializeField] private Material Material;

        public GUITextureGizmo(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material material)
        {
            ScreenRect = screenRect;
            Texture = texture;
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
            TopBorder = topBorder;
            BottomBorder = bottomBorder;
            Material = material;
        }

        protected override void DrawGizmoVisuals()
        {
            Gizmos.DrawGUITexture(ScreenRect, Texture, LeftBorder, RightBorder, TopBorder, BottomBorder, Material);
        }
    }
}