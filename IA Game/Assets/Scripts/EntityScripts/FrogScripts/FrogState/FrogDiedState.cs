using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDiedState<T> : FrogStateBase<T>
{
    public override void Awake()
    {
        base.Awake();
        _model.Dead();
    }
}
