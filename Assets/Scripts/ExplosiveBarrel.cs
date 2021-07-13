using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class ExplosiveBarrel : MonoBehaviour
{
    static readonly int shPropColor = Shader.PropertyToID("_Color");

    [Range(1f, 8f)]
    public float radius = 1f;

    public float damage = 10;

    public Color color = Color.red;

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

    void OnDrawGizmosSelected()
    {
        Handles.color = color;
        Handles.DrawWireDisc(transform.position, transform.up, radius);
        Handles.color = Color.white;
        // Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Called on property change
    void OnValidate()
    {
        ApplyColor();
    }

    void OnEnable()
    {
        ApplyColor();
        ExplosiveBarrelManager.allTheBarrels.Add(this);
    }
    void OnDisable() => ExplosiveBarrelManager.allTheBarrels.Remove(this);

    void ApplyColor()
    {
        MeshRenderer rnd = GetComponent<MeshRenderer>();
        Mpb.SetColor(shPropColor, color);
        rnd.SetPropertyBlock(Mpb);
    }
}
