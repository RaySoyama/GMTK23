using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[InitializeOnLoad]
public static class HierarchyWindowGroupHeader
{
    static HierarchyWindowGroupHeader()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
    }

    static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        int colorCode = 111;
        string prefix = "*";
        string suffix = "*";


        if (gameObject != null && gameObject.name.Length >= 5 && gameObject.name.Substring(0, 1) == prefix && int.TryParse(gameObject.name.Substring(1, 3), out colorCode) && gameObject.name.Substring(4, 1) == suffix)
        {
            byte rVal = System.Convert.ToByte(Mathf.RoundToInt((float.Parse(gameObject.name.Substring(1, 1)) / 9.0f) * 255.0f));
            byte gVal = System.Convert.ToByte(Mathf.RoundToInt((float.Parse(gameObject.name.Substring(2, 1)) / 9.0f) * 255.0f));
            byte bVal = System.Convert.ToByte(Mathf.RoundToInt((float.Parse(gameObject.name.Substring(3, 1)) / 9.0f) * 255.0f));

            EditorGUI.DrawRect(selectionRect, new Color32(rVal, gVal, bVal, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace(gameObject.name.Substring(0, 5), "").ToUpperInvariant());
        }
    }
}
#endif