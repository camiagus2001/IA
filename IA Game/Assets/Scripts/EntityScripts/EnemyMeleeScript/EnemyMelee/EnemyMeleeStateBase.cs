using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeStateBase<T> : State<T>
{
    protected EnemyMeleeModel _model;
    protected FSM<T> _fsm;
    public void InitializedState(EnemyMeleeModel model, FSM<T> fsm)
    {
        _model = model;
        _fsm = fsm;
    }
}
