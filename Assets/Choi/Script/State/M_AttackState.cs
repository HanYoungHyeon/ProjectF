using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_AttackState : MonsterBaseState
{
    public M_AttackState(GameObject gameObject) : base(gameObject)
    {
    }

    public override void Enter()
    {
        monster.attackRange[0].SetActive(true);
        monster.animator.SetTrigger("HandAttack");
    }

    public override void Update()
    {
        if (monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.6f)
        {
            IHitable canHit = monster.HitAttackTarget(monster.attackRange[0]).transform?.GetComponent<IHitable>();
            canHit?.Hit(monster.atk);
        }

        if(monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            monster.SetState(new M_MoveState(gameObj));

    }

    public override void Exit()
    {
        monster.attackRange[0].SetActive(false);
    }
}

public class M_RushAttack : M_AttackState
{
    public M_RushAttack(GameObject gameObject) : base(gameObject)
    {
        
    }

}
