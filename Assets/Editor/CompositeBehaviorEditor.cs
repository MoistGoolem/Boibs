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
            //Setup space for behaviors
            r.x = 30f;
            r.width = EditorGUIUtility.currentViewWidth - 95f;
            EditorGUI.LabelField(r, "Behaviors");

            r.x = EditorGUIUtility.currentViewWidth - 65f;
            //Setup space for weights
            r.width = 60f;
            EditorGUI.LabelField(r, "Weights");
            r.y += EditorGUIUtility.singleLineHeight * 1.2f;

            //Populate behaviors and weights
            for (int i = 0; i < cb.behaviors.Length; i++) {
                r.x = 5f;
                r.width = 20f;
                EditorGUI.LabelField(r, i.ToString());
                r.x = 30f;
                r.width = EditorGUIUtility.currentViewWidth - 95f;
                cb.behaviors[i] = (FlockBehavior)EditorGUI.ObjectField(r, cb.behaviors[i], typeof(FlockBehavior), false);
                r.x = EditorGUIUtility.currentViewWidth - 65f;
                r.width = 60f;
                cb.weights[i] = EditorGUI.FloatField(r, cb.weights[i]);
                r.y += EditorGUIUtility.singleLineHeight * 1.1f;
            }

            EditorGUILayout.EndHorizontal();
            r.x = 5f;
            r.width = EditorGUIUtility.currentViewWidth - 10f;
            r.y += EditorGUIUtility.singleLineHeight * 0.5f;

            //Add new behavior button
            if(GUI.Button(r, "Add Behavior")) {
                // AddBehavior(cb);
                // EditorUtility.SetDirty(cb);
            }

            r.y += EditorGUIUtility.singleLineHeight * 1.5f;
            //Remove behavior button
            if(cb.behaviors != null && cb.behaviors.Length > 0) {
                if(GUI.Button(r, "Remove Behavior")) {
                    // RemoveBehavior(cb);
                    // EditorUtility.SetDirty(cb);
                }
            }
        }
    }
}
