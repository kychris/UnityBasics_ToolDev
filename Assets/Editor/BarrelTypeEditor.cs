using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BarrelType))]
public class BarrelTypeEditor : Editor
{
    public float thing0; // serialized, visible, public
    float thing1; //not serialed, hidden, private
    [SerializeField] float thing2; //serialized, visible, private
    [HideInInspector] public float thing3; //serialized, hidden, public

    public enum Things
    {
        Bleep, Bloop, Blap
    }

    Things things;
    float someValue;


    public override void OnInspectorGUI()
    {
        GUILayout.Label("test");
        if (GUILayout.Button("Do a thing"))
            Debug.Log("did a thing");

        things = (Things)EditorGUILayout.EnumPopup(things);


        // explicit positioning using rect
        // GUI
        // EditorGUI

        // implicit positioning, auto-layout
        // GUILayout
        // EditorGUILayout
    }
}




