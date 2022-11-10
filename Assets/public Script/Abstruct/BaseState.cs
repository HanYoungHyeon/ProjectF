using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : IStater
{
    public GameObject gameObj;
    public BaseState(GameObject game)
    {
        this.gameObj = game;
    }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
