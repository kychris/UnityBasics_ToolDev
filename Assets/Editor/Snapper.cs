using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection.Emit;

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
            go.transform.position = go.transform.position.Round(1f);
        }
    }

    public static Vector3 Round(this Vector3 v, float baseVal) //extension function (static class static function)
    {
        v.x = round(v.x, baseVal);
        v.y = round(v.y, baseVal);
        v.z = round(v.z, baseVal);
        return v;
    }

    public static float round(float num, float baseVal) { return floor(num + 0.5f * baseVal, baseVal); }

    public static float floor(float num, float baseVal) { return num - num % baseVal; }
}
