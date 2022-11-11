using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMonster : Monster
{

    public P_Attack p_attack;
    public P_Movement p_movement;
    private void Start()
    {
        p_attack = new P_Attack(gameObject);
        p_movement = new P_Movement(gameObject);
        SetState(p_movement);
    }

    private void Update()
    {
        curState.Update();
    }





}
