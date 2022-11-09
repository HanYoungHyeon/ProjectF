using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Monster")]
public class M_ScriptableObject : ScriptableObject
{
    public GameObject prefab;
    public float atk;
    public float hp;
}
