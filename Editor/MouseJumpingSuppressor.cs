using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
internal static class MouseJumpingSuppressor
{
    private static EditorWindow _previousWindow;
    static MouseJumpingSuppressor()
    {
        EditorApplication.update += () =>
        {
            var current = EditorWindow.focusedWindow;
            if (_previousWindow != current)
            {
                if (_previousWindow is SceneView)
                    EditorGUIUtility.SetWantsMouseJumping(0);
                _previousWindow = current;
            }
        };
    }
}