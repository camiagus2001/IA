using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeDiedState<T> : EnemyMeleeStateBase<T>
{
    public override void Awake()
    {
        base.Awake();
        _model.Dead();
    }
}
