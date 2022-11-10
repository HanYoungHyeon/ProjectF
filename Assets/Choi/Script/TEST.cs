using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour, IHitable
{
    [SerializeField]float hp;
    public float Hp { get { return hp; } set { hp = value; } }

    private void Start()
    {
        Hp = 10;
    }
    public void Hit(float damage)
    {
        Hp -= damage;
    }
}
