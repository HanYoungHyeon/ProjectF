using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour, IHitable
{
    [SerializeField]float hp;
    public float Hp { get { return hp; } set { hp = value; } }

    public GameObject monster;
    IHitable hit;

    private void Start()
    {
        Hp = 10;
        hit = monster.GetComponent<IHitable>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            hit.Hit(10);
        }
    }
    public void Hit(float damage)
    {
        Hp -= damage;
    }
}
