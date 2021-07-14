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

    Transform tf;


    public override void OnInspectorGUI()
    {
        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            using (new GUILayout.HorizontalScope())
            {
                // GUILayout.BeginHorizontal();
                GUILayout.Label("Title", new GUILayoutOption[] { GUILayout.Width(50) });
                if (GUILayout.Button("Do a thing"))
                    Debug.Log("did a thing");
                things = (Things)EditorGUILayout.EnumPopup(things);
                // GUILayout.EndHorizontal();
            }

            GUILayout.Label("things", EditorStyles.toolbarButton);
            GUILayout.Label("things", GUI.skin.button);
        }
        GUILayout.Space(40);
        GUILayout.Label("Things", EditorStyles.boldLabel);

        EditorGUILayout.ObjectField("Assign here: ", null, typeof(Transform), true);


        // explicit positioning using rect
        // GUI
        // EditorGUI

        // implicit positioning, auto-layout
        // GUILayout
        // EditorGUILayout
    }
}




