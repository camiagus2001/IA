using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackState<T> : EnemyMeleeStateBase<T>
{
    public override void Awake()
    {
        base.Awake();
        var player = _model.LastPlayerTouch;
        _model.Attack(player);
    }
}
