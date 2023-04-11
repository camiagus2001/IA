using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    FrogModel _model;
    FSM<FrogStateEnum> _fsm;
    ITreeNode _root;
    private void Awake()
    {
        _model = GetComponent<FrogModel>();
        IntializedFSM();
        InitializedTree();
    }

    public void IntializedFSM()
    {
        var list = new List<FrogStateBase<FrogStateEnum>>();
        _fsm = new FSM<FrogStateEnum>();

        var idle = new FrogIdleState<FrogStateEnum>();
        var jump = new FrogJumpState<FrogStateEnum>();
        var dead = new FrogDiedState<FrogStateEnum>();
        var attack = new FrogAttackState<FrogStateEnum>();

        list.Add(idle);
        list.Add(jump);
        list.Add(dead);
        list.Add(attack);

        for (int i = 0; i < list.Count; i++)
        {
            list[i].InitializedState(_model, _fsm);
        }

        idle.AddTransition(FrogStateEnum.Jump, jump);
        idle.AddTransition(FrogStateEnum.Dead, dead);

        jump.AddTransition(FrogStateEnum.Idle, idle);
        jump.AddTransition(FrogStateEnum.Attack, attack);

        _fsm.SetInit(idle);
    }
    public void InitializedTree()
    {
        //actions
        var idle = new TreeAction(ActionIdle);
        var jump = new TreeAction(ActionJump);
        var dead = new TreeAction(ActionDead);
        var attack = new TreeAction(ActionAttack);

        //questions
        var isTimeOver = new TreeQuestion(IsTimeOver, jump, idle);
        var isTouchPlayer = new TreeQuestion(IsTouchPlayer, dead, isTimeOver);
        var isTouchPlayerAttack = new TreeQuestion(IsTouchPlayer, attack, jump);
        var isTouchFloor = new TreeQuestion(IsTouchFloor, isTouchPlayer, isTouchPlayerAttack);

        _root = isTouchFloor;
    }
    bool IsTouchFloor()
    {
        return _model.IsTouchFloor;
    }
    bool IsTouchPlayer()
    {
        return _model.IsTouchPlayer;
    }
    bool IsTimeOver()
    {
        return _model.CurrentTimer < 0;
    }
    void ActionIdle()
    {
        _fsm.Transitions(FrogStateEnum.Idle);
    }
    void ActionJump()
    {
        _fsm.Transitions(FrogStateEnum.Jump);
    }
    void ActionDead()
    {
        _fsm.Transitions(FrogStateEnum.Dead);
    }
    void ActionAttack()
    {
        _fsm.Transitions(FrogStateEnum.Attack);
    }
    private void Update()
    {
        _fsm.OnUpdate();
        _root.Execute();
    }
}
