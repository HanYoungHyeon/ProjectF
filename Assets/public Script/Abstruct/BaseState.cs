using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : IStater
{
    public abstract void Enter();

    public abstract void Exit();

    public abstract void SetState();

    public abstract void Update();
}
