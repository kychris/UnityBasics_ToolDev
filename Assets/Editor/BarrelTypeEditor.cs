using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.ComponentModel;

[CanEditMultipleObjects]
[CustomEditor(typeof(BarrelType))]
public class BarrelTypeEditor : Editor
{
    SerializedObject so;
    SerializedProperty propRadius;
    SerializedProperty propDamage;
    SerializedProperty propColor;

    void OnEnable()
    {
        so = serializedObject;
        propRadius = so.FindProperty("radius");
        propDamage = so.FindProperty("damage");
        propColor = so.FindProperty("color");
    }

    public override void OnInspectorGUI()
    {
        so.Update();
        EditorGUILayout.PropertyField(propRadius); //field picked automatically
        EditorGUILayout.PropertyField(propDamage);
        EditorGUILayout.PropertyField(propColor);

        // if sth changed
        if (so.ApplyModifiedProperties())
        {
            ExplosiveBarrelManager.UpdateAllBarrelColors();
        }
    }
}




