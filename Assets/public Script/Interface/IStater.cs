using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStater
{
    public void SetState();
    public void Enter();
    public void Exit();
    public void Update();
}
