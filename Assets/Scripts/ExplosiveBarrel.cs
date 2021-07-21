using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class ExplosiveBarrel : MonoBehaviour
{
    static readonly int shPropColor = Shader.PropertyToID("_Color");

    public BarrelType type;

    // Initialize mpb, can't do direct initialization so this instead
    MaterialPropertyBlock mpb;
    MaterialPropertyBlock Mpb
    {
        get
        {
            if (mpb == null)
                mpb = new MaterialPropertyBlock();
            return mpb;
        }
    }

    void OnDrawGizmos()
    {
        if (type == null)
            return;

        Handles.zTest = CompareFunction.LessEqual;
        Handles.color = type.color;
        Handles.DrawWireDisc(transform.position, transform.up, type.radius);
        Handles.color = Color.white;
        // Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Called on property change
    void OnValidate()
    {
        TryApplyColor();
    }

    void OnEnable()
    {
        TryApplyColor();
        ExplosiveBarrelManager.allTheBarrels.Add(this);
    }
    void OnDisable() => ExplosiveBarrelManager.allTheBarrels.Remove(this);

    public void TryApplyColor()
    {
        if (type == null)
            return;
        MeshRenderer rnd = GetComponent<MeshRenderer>();
        Mpb.SetColor(shPropColor, type.color);
        rnd.SetPropertyBlock(Mpb);
    }
}
