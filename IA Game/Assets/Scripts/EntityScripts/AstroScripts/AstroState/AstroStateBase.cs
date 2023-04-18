using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroStateBase<T> : State<T>
{
    protected AstroModel _model;
    protected FSM<T> _fsm;
    public void InitializedState(AstroModel model, FSM<T> fsm)
    {
        _model = model;
        _fsm = fsm;
    }
}
