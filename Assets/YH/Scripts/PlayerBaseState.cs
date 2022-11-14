using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : BaseState
{
    public Player player;
    public PlayerBaseState(GameObject game) : base(game)
    {
        player = gameObj.GetComponent<Player>();
        this.gameObj = game;
    }
    public override void Enter()
    { }
    public override void Update()
    { }
    public override void Exit()
    { }
}
public class PlayerIdleState : PlayerBaseState
{
    public Animator animator;
    public PlayerIdleState(GameObject game) : base(game)
    {
        animator = player.GetComponent<Animator>();
    }
    public override void Enter()
    {
        animator.SetBool("Idle", true);
        
    }
    public override void Update()
    {
    }
    public override void Exit()
    {
        animator.SetBool("Idle", false);
    }
}
public class PlayerWalkState : PlayerBaseState
{
    public Animator animator;
    public PlayerWalkState(GameObject game) : base(game)
    {
        animator = player.GetComponent<Animator>();
    }
    public override void Enter()
    {
        animator.SetBool("Walk", true);
    }
    public override void Update()
    {
        if(player.moveInput.magnitude == 0 && player.isAttackOver == true)
        {
            player.SetState(new PlayerIdleState(player.gameObject));
        }
    }
    public override void Exit()
    {
        animator.SetBool("Walk", false);
    }
}
public class PlayerAttackState : PlayerBaseState
{
    public Animator animator;
    public PlayerAttackState(GameObject game) : base(game)
    {
        animator = player.GetComponent<Animator>();
    }
    public override void Enter()
    {
        player.isAttackOver = false;
        animator.SetTrigger("Attack");
    }
    public override void Update()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5 && Input.GetKeyDown(KeyCode.Space))
        {
            player.SetState(new PlayerAttackTwoState(player.gameObject));
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                player.SetState(new PlayerIdleState(player.gameObject));
            }
    }
    public override void Exit()
    {
        player.isAttackOver = true;
    }
}
public class PlayerAttackTwoState : PlayerBaseState
{
    public Animator animator;
    public float playerSecondAtk;
    public PlayerAttackTwoState(GameObject game) : base(game)
    {
        animator = player.GetComponent<Animator>();
        playerSecondAtk = player.secondAtk;
}
    public override void Enter()
    {
        player.isAttackOver = false;
        player.Atk += playerSecondAtk;
        animator.SetTrigger("Attack2");
    }
    public override void Update()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5 && Input.GetKeyDown(KeyCode.Space))
        {
            player.SetState(new PlayerAttackThreeState(player.gameObject));
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            player.SetState(new PlayerIdleState(player.gameObject));
        }
    }
    public override void Exit()
    {
        player.Atk -= playerSecondAtk;
        player.isAttackOver = true;
    }
}
public class PlayerAttackThreeState : PlayerBaseState
{
    public float playerThirdAtk;
    public Animator animator;
    public PlayerAttackThreeState(GameObject game) : base(game)
    {
        animator = player.GetComponent<Animator>();
        playerThirdAtk = player.thirdAtk;
    }
    public override void Enter()
    {
        player.Atk += playerThirdAtk;
        player.isAttackOver = false;
        animator.SetTrigger("Attack3");
    }
    public override void Update()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            player.SetState(new PlayerIdleState(player.gameObject));
        }
    }
    public override void Exit()
    {
        player.Atk -= playerThirdAtk;
        player.isAttackOver = true;
    }
}
public class PlayerShieldState : PlayerBaseState
{
    public Animator animator;
    public PlayerShieldState(GameObject game) : base(game)
    {
        animator = player.GetComponent<Animator>();
    }
    public override void Enter()
    {
        animator.SetTrigger("Shield");
    }
    public override void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            player.SetState(new PlayerIdleState(player.gameObject));
        }
    }
    public override void Exit()
    {
        player.isGuardOver = true;
    }
}
public class PlayerRollState : PlayerBaseState
{
    public Animator animator;
    public PlayerRollState(GameObject game) : base(game)
    {
        animator = player.GetComponent<Animator>();
    }
    public override void Enter()
    {
        animator.SetTrigger("Roll");
    }
    public override void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            player.SetState(new PlayerIdleState(player.gameObject));
        }
    }
    public override void Exit()
    {
    }
}
public class PlayerHitState : PlayerBaseState
{
    public Animator animator;
    public PlayerHitState(GameObject game) : base(game)
    {
        animator = player.GetComponent<Animator>();
    }
    public override void Enter()
    {
        animator.SetTrigger("Hit");
    }
    public override void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            player.SetState(new PlayerIdleState(player.gameObject));
        }
    }
    public override void Exit()
    {
        player.isHit = false;
    }
}
public class PlayerDieState : PlayerBaseState
{
    public Animator animator;
    public PlayerDieState(GameObject game) : base(game)
    {
        animator = player.GetComponent<Animator>();
    }
    public override void Enter()
    {
        animator.SetTrigger("Die");
    }
    public override void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            player.SetState(new PlayerIdleState(player.gameObject));
        }
    }
    public override void Exit()
    {

    }
}