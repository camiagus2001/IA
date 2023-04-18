using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroStateIdle<T> : AstroStateBase<T>
{
    T _inputRunning;
    public AstroStateIdle(T inputRunning)
    {
        _inputRunning = inputRunning;
    }
    public override void Awake()
    {
        base.Awake();
    }
    public override void Execute()
    {
        base.Execute();
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            _fsm.Transitions(_inputRunning);
        }
    }
}
