using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class SnapperTool : EditorWindow
{


    //saved in layout, autoreopen when unity starts
    [MenuItem("Tools/Snapper")]
    public static void OpenTheThing() => GetWindow<SnapperTool>("Snapper");

    private void OnEnable() { Selection.selectionChanged += Repaint; }

    private void OnDisable() => Selection.selectionChanged -= Repaint;


    void OnGUI()
    {
        using (new EditorGUI.DisabledScope(Selection.gameObjects.Length == 0))
        {
            if (GUILayout.Button("Snap Selecttion"))
            {
                SnapSelection();
            }
        }
    }

    void SnapSelection()
    {
        foreach (var go in Selection.gameObjects)
        {
            Undo.RecordObject(go.transform, "snap objects");
            go.transform.position = go.transform.position.Round(1);
        }
    }

}
