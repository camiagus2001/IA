using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeJumpState<T> : EnemyMeleeStateBase<T>
{
    public override void Awake()
    {
        base.Awake();
        Vector3 dir = _model.GetJumpDirection();
        _model.Jump(dir);
    }
}
