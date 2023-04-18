using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroController : MonoBehaviour
{
    AstroModel _model;
    FSM<AstroStateEnum> _fsm;
    List<AstroStateBase<AstroStateEnum>> _states;
    void InitializedFSM()
    {
        _fsm = new FSM<AstroStateEnum>();
        _states = new List<AstroStateBase<AstroStateEnum>>();
        var idle = new AstroStateIdle<AstroStateEnum>(AstroStateEnum.Running);
        var move = new AstroStateMove<AstroStateEnum>(AstroStateEnum.Idle);

        _states.Add(idle);
        _states.Add(move);

        idle.AddTransition(AstroStateEnum.Running, move);
        move.AddTransition(AstroStateEnum.Idle, idle);


        for (int i = 0; i < _states.Count; i++)
        {
            _states[i].InitializedState(_model, _fsm);
        }
        _states = null;

        _fsm.SetInit(idle);
    }
    private void Awake()
    {
        _model = GetComponent<AstroModel>();
        InitializedFSM();
    }
    private void Update()
    {
        _fsm.OnUpdate();
    }
}
