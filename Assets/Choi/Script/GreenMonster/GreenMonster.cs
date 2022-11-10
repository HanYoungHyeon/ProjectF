using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMonster : Monster
{
    public G_MoveState g_MoveState;
    public GreenMonsterAttack g_Attack;
    public GreenMonsterRushAttack g_RushAttack;
    public int count;
    private void Start()
    {
        g_MoveState = new G_MoveState(gameObject);
        g_Attack = new GreenMonsterAttack(gameObject);
        g_RushAttack = new GreenMonsterRushAttack(gameObject);
        count = 0;
        SetState(g_MoveState);
    }
    private void Update()
    {
        Debug.Log(count);
        if (count >= 4)
        {
            SetState(g_RushAttack);
            count = 0;
        }
        curState.Update();
    }

}
