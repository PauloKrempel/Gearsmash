using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class CustomHierarchy
{
    static CustomHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI += RenderObjects;
    }
    private static void RenderObjects(int instanceID, Rect selectionRect)
    {
        GameObject goEditor = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if(goEditor == null) return;

        if(goEditor.TryGetComponent<CustomHeaderObject>(out var customHeaderObject))
        {
            EditorGUI.DrawRect(selectionRect, customHeaderObject.backgroundColor);
            EditorGUI.LabelField(selectionRect, goEditor.name.ToUpper(), new GUIStyle(){
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold,
            normal = new GUIStyleState(){textColor = customHeaderObject.textColor}
            });
        }
    }
}
