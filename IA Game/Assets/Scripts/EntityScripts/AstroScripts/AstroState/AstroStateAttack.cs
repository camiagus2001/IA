using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroStateAttack<T> : AstroStateBase<T>
{
    T _inputAttack;

    public AstroStateAttack(T inputAttack)
    {
        _inputAttack = inputAttack;
    }
    public override void Awake()
    {
        base.Awake();
        Debug.Log("Attack");
    }
    public override void Execute()
    {
        base.Execute();
        //Daño
    }
}
