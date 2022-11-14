using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Attack : M_AttackState
{
    public RedMonster r_monster;
    public R_Attack(GameObject gameObject) : base(gameObject)
    {
        gameObj = gameObject;
        r_monster = gameObj.GetComponent<RedMonster>();
    }

    public override void Enter()
    {
        r_monster.animator.SetTrigger("Attack");
        r_monster.attackCols[0].enabled = true;
    }
    public override void Update()
    {
        if (r_monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f && r_monster.animator.GetCurrentAnimatorStateInfo(0).IsName("Basic Attack"))
        {
            r_monster.SetState(r_monster.r_movement);
        }
    }

    public override void Exit()
    {
        r_monster.attackCols[0].enabled = false;
    }
}

public class R_ClawAttack : R_Attack
{
    Transform target;
    public R_ClawAttack(GameObject gameObject) : base(gameObject)
    {
    }

    public override void Enter()
    {
        target = r_monster.player.transform;
        target.forward = target.position - r_monster.transform.position;
        r_monster.animator.SetTrigger("ClawAttack");
        r_monster.attackCols[1].enabled = true;
        r_monster.StartCor(1);
    }

    public override void Update()
    {
        if (r_monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f && r_monster.animator.GetCurrentAnimatorStateInfo(0).IsName("Claw Attack"))
        {
            r_monster.SetState(r_monster.r_movement);
        }
    }
    public override void Exit()
    {
        r_monster.attackCols[1].enabled = false;
    }
}

public class R_FlameAttack : R_Attack
{
    public R_FlameAttack(GameObject gameObject) : base(gameObject)
    {
    }
    public override void Enter()
    {
        r_monster.animator.SetTrigger("FlameAttack");
        r_monster.attackCols[2].enabled = true;
        r_monster.StartCor(2);
        r_monster.isFlameCool = false;
        r_monster.r_attack = new R_Attack(gameObj);
        for(int i =0; i< r_monster.particles.Length;i++)
        {
            r_monster.particles[i].Play();
        }
    }

    public override void Update()
    {
        if (r_monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f && r_monster.animator.GetCurrentAnimatorStateInfo(0).IsName("Flame Attack"))
        {
            r_monster.SetState(r_monster.r_movement);
        }
    }
    public override void Exit()
    {
        r_monster.attackCols[2].enabled = false;
    }
}
