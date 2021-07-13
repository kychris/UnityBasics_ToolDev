using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExplosiveBarrelManager : MonoBehaviour
{
    public static List<ExplosiveBarrel> allTheBarrels = new List<ExplosiveBarrel>();

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        // Line cover by object
        Handles.zTest = CompareFunction.LessEqual;

        foreach (ExplosiveBarrel barrel in allTheBarrels)
        {
            Vector3 managerPos = transform.position;
            Vector3 barrelPos = barrel.transform.position;
            float halfHeight = (managerPos.y - barrelPos.y) * 0.5f;
            Vector3 tangenOffset = Vector3.up * halfHeight;

            Handles.DrawBezier(
                managerPos,
                barrelPos,
                managerPos - tangenOffset,
                barrelPos + tangenOffset,
                barrel.color,
                EditorGUIUtility.whiteTexture,
                1f
            );

            // Handles.DrawAAPolyLine(transform.position, barrel.transform.position);
            // Gizmos.DrawLine(transform.position, barrel.transform.position);
        }
    }
#endif
}
