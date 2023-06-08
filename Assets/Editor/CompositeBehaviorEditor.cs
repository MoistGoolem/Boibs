using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CompositeBehavior))]
public class CompositeEditor : Editor {
    public override void OnInspectorGUI() {
        //setup inspector
        CompositeBehavior cb = (CompositeBehavior)target;
        
        Rect r = EditorGUILayout.BeginHorizontal();
        r.height = EditorGUIUtility.singleLineHeight;

        //check for behaviors
        if(cb.behaviors == null || cb.behaviors.Length == 0) {
            EditorGUILayout.HelpBox("No behaviors in array.", MessageType.Warning);
            EditorGUILayout.EndHorizontal();
            r = EditorGUILayout.BeginHorizontal();
            r.height = EditorGUIUtility.singleLineHeight;
        } else {
            r.x = 30f;
            r.width = EditorGUIUtility.currentViewWidth - 95f;
            EditorGUI.LabelField(r, "Behaviors");
            r.x = EditorGUIUtility.currentViewWidth - 65f;
            r.width = 60f;
            EditorGUI.LabelField(r, "Weights");
            r.y += EditorGUIUtility.singleLineHeight * 1.2f;
        }
    }
}
