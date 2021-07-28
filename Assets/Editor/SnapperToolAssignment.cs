using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;

public class SnapperToolAssignment : EditorWindow
{
    //saved in layout, autoreopen when unity starts
    [MenuItem("Tools/MySnapper")]
    public static void OpenTheThing() => GetWindow<SnapperTool>("Snapper");

    private void OnEnable() { Selection.selectionChanged += Repaint; }
    private void OnDisable() => Selection.selectionChanged -= Repaint;

    float gridSize = 1f;

    void OnGUI()
    {
        using (new EditorGUI.DisabledScope(Selection.gameObjects.Length == 0))
        {
            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Label("Grid Size: ");
                gridSize = EditorGUILayout.FloatField(gridSize, GUILayout.Width(Screen.width / 2));
            }
            if (GUILayout.Button("Snap Selecttion"))
            {
                SnapSelection(gridSize);
            }
        }

        for (float x = -10f; x < 10f; x += gridSize)
        {
            Vector3[] points = new Vector3[(int)(20 / gridSize)];
            int count = 0;
            for (float z = -10f; z < 10f; z += gridSize)
            {
                points[count] = new Vector3(x, 0, z);
                count += 1;
            }

            // foreach (Vector3 point in points)
            // {
            //     Debug.Log(point);
            // }
            Handles.DrawAAPolyLine(10, points);

        }

        // Handles.DrawAAPolyLine()

    }

    void SnapSelection(float size)
    {
        foreach (var go in Selection.gameObjects)
        {
            Undo.RecordObject(go.transform, "snap objects");
            go.transform.position = go.transform.position.Round(gridSize);
        }
    }




}
