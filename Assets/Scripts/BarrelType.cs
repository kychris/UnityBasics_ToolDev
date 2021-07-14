using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BarrelType : ScriptableObject
{
    [Range(1f, 8f)]
    public float radius = 1f;
    public float damage = 10;
    public Color color = Color.red;
    public List<MyClass> test;

    public ChildClass test2;
}

[Serializable]
public class MyClass
{
    public Vector3 pos;
    public Color color;
}

// Serialize do not work with polymorphism, list mix of parent and children, 
// extra attributes are dropped.
[Serializable]
public class ChildClass : MyClass
{
    public Quaternion rot;
}