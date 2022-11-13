using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayMonster : Monster
{
    public Gr_Attack gr_attack;
    public Gr_Movement gr_movement;

    private void Start()
    {
        gr_movement = new Gr_Movement(gameObject);
        gr_attack = new Gr_Attack(gameObject);
    }

    private void Update()
    {
        curState.Update();
    }
}
