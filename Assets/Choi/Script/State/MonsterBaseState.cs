using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBaseState : BaseState
{
    public Monster monster;
    public MonsterBaseState(GameObject gameObject) : base(gameObject)
    {
        this.gameObject = gameObject;
        monster = this.gameObject.GetComponent<Monster>();
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        
    }
}
