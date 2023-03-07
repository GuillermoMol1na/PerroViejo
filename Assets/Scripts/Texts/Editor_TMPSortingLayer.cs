using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
[CustomEditor(typeof(ScriptTMPSortingLayer))]
public class Editor_TMPSortingLayer : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ScriptTMPSortingLayer script = (ScriptTMPSortingLayer)target;
        script.sortingLayer = EditorGUILayout.IntField("Sorting layer", script.sortingLayer);
        TextMeshProUGUI t = script.gameObject.GetComponent<TextMeshProUGUI>();
       /* if (t != null){
            t.canvas.sortingOrder = script.sortingLayer;
        }*/
    }
}
