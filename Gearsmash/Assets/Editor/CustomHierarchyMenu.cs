using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomHierarchyMenu : EditorWindow
{
    [MenuItem("GameObject/Create a custom Header")]
    static void CreateCustomHeader(MenuCommand menuCommand)
    {
        GameObject obj = new GameObject("Header");
        Undo.RegisterCreatedObjectUndo(obj, "Create Custom Header");
        GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject);
        obj.AddComponent<CustomHeaderObject>();
        Selection.activeObject = obj;
    }
}
