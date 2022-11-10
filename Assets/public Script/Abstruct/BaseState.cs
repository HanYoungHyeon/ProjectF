using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : IStater
{
<<<<<<< HEAD
    public GameObject gameObject;
    public BaseState(GameObject gameObject)
    {
        this.gameObject = gameObject;
=======
    public GameObject gameObj;
    public BaseState(GameObject game)
    {
        this.gameObj = game;
>>>>>>> YH
    }
    public abstract void Enter();
    public abstract void Exit();
<<<<<<< HEAD

=======
>>>>>>> YH
    public abstract void Update();
}
