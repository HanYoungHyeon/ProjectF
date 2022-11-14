using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMonster : Monster
{
    public G_MoveState g_MoveState;
    public GreenMonsterAttack g_Attack;
    public bool isRush;

    IEnumerator skillCor;
    private void Start()
    {
        g_MoveState = new G_MoveState(gameObject);
        g_Attack = new GreenMonsterAttack(gameObject);
        isRush = true;
        skillCor = SkillCool();

        SetState(g_MoveState);
    }
    private void Update()
    {
        curState.Update();
    }

    public void StartCor()
    {
        StartCoroutine(skillCor);
    }

    public IEnumerator SkillCool()
    {
        yield return new WaitForSeconds(7);
        isRush = true;
    }

}
