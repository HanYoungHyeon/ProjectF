using UnityEngine;

public class GreenMonsterAttack : M_AttackState
{
    public GreenMonster greenMonster;
    public GreenMonsterAttack(GameObject gameObject) : base(gameObject)
    {
        this.gameObj = gameObject;
        greenMonster = this.gameObj.GetComponent<GreenMonster>();
    }
    public override void Enter()
    {
        monster.attackCols[0].enabled = true;
        monster.animator.SetTrigger("HandAttack");
    }
    public override void Update()
    {
        if (monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            monster.SetState(greenMonster.g_MoveState);
        }
    }

    public override void Exit()
    {
        monster.attackCols[0].enabled = false;
        greenMonster.count++;
    }
}

public class GreenMonsterRushAttack : GreenMonsterAttack
{
    public GreenMonsterRushAttack(GameObject gameObject) : base(gameObject)
    {
    }
    public override void Enter()
    {
        monster.attackCols[1].enabled = true;
        monster.animator.SetTrigger("RushAttack");
    }
    public override void Update()
    {
        if (monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            monster.SetState(greenMonster.g_MoveState);
        }
    }

    public override void Exit()
    {
        monster.attackCols[1].enabled = false;
    }
}
