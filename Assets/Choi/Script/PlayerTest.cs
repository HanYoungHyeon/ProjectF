using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    GameObject monster;
    private void Start()
    {
        monster = GameObject.Find("Monster1");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(monster.TryGetComponent(out IHitable hit))
            {
                hit.Hit(100);
            }
        }
    }
}
