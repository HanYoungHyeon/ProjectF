using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gr_Attack : M_AttackState
{
    public GrayMonster gr_monster;
    public Gr_Attack(GameObject gameObject) : base(gameObject)
    {
        gameObj = gameObject;
        gr_monster = gameObj.GetComponent<GrayMonster>();
    }

    public override void Enter()
    {
        gr_monster.animator.SetTrigger("Attack");
        gr_monster.attackCols[0].enabled = true;
    }

    public override void Update()
    {
        if (gr_monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f && gr_monster.animator.GetCurrentAnimatorStateInfo(0).IsName("Basic Attack"))
        {
            monster.SetState(gr_monster.gr_movement);
        }
    }

    public override void Exit()
    {
        gr_monster.attackCols[0].enabled = false;
    }
}
public class Gr_ClawAttack : Gr_Attack
{
    public Gr_ClawAttack(GameObject gameObject) : base(gameObject)
    {
    }
    public override void Enter()
    {
        gr_monster.animator.SetTrigger("ClawAttack");
        gr_monster.attackCols[1].enabled = true;
        gr_monster.attackCols[2].enabled = true;
    }

    public override void Update()
    {
        if (gr_monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f && gr_monster.animator.GetCurrentAnimatorStateInfo(0).IsName("Claw Attack"))
        {
            gr_monster.SetState(gr_monster.gr_movement);
        }
    }

    public override void Exit()
    {
        gr_monster.attackCols[1].enabled = false;
        gr_monster.attackCols[2].enabled = false;
    }
}

public class Gr_FlameAttack : Gr_Attack
{
    public Gr_FlameAttack(GameObject gameObject) : base(gameObject)
    {
    }

    public override void Enter()
    {
        for(int i =0; i<gr_monster.particles.Length;i++)
        {
            gr_monster.particles[i].Play();
        }
        gr_monster.animator.SetTrigger("FlameAttack");
        gr_monster.attackCols[3].enabled = true;
    }
    public override void Update()
    {
        if (gr_monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f && gr_monster.animator.GetCurrentAnimatorStateInfo(0).IsName("Flame Attack"))
        {
            gr_monster.SetState(gr_monster.gr_movement);
        }
    }

    public override void Exit()
    {
        gr_monster.attackCols[3].enabled = false;
    }
}
