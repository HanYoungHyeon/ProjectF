using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : IStater
{
    GameObject gameObject;
    public BaseState(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }
    public abstract void Enter();

    public abstract void Exit();

    public abstract void Update();
}
