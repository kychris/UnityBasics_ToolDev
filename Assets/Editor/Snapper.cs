using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class Snapper
{

    const string UNDO_STR_SNAP = "snap objects";


    [MenuItem("Edit/Snap Selected Objects", isValidateFunction: true)]
    public static bool SnapTheThingsValidate()
    {
        return Selection.gameObjects.Length > 0;
    }

    // append at the end of name to add shortcut
    [MenuItem("Edit/Snap Selected Objects")]
    public static void SnapTheThings()
    {
        foreach (var go in Selection.gameObjects)
        {
            // Important to flag values as dirty before change, to notify save
            Undo.RecordObject(go.transform, UNDO_STR_SNAP);  //need to be specific, only go will record tags and stuff; expensive;
            go.transform.position = go.transform.position.Round();
        }
    }


    public static Vector3 Round(this Vector3 v) //extension function (static class static function)
    {
        v.x = Mathf.Round(v.x);
        v.y = Mathf.Round(v.y);
        v.z = Mathf.Round(v.z);
        return v;
    }
}
