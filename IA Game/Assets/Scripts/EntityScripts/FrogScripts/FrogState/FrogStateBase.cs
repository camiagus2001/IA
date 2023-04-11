using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogStateBase<T> : State<T>
{
    protected FrogModel _model;
    protected FSM<T> _fsm;
    public void InitializedState(FrogModel model, FSM<T> fsm)
    {
        _model = model;
        _fsm = fsm;
    }
}
