using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.ComponentModel;

[CanEditMultipleObjects]
[CustomEditor(typeof(BarrelType))]
public class BarrelTypeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // No undo, doesn't save when existing unity, no multiple object support
        BarrelType barrel = target as BarrelType;
        float newRadius = EditorGUILayout.FloatField("radius", barrel.radius);
        if (newRadius != barrel.radius)
        {
            Undo.RecordObject(barrel, "change barrel radius");
            barrel.radius = newRadius;
        }

        barrel.damage = EditorGUILayout.FloatField("damage", barrel.damage);
        barrel.color = EditorGUILayout.ColorField("color", barrel.color);

    }
}




