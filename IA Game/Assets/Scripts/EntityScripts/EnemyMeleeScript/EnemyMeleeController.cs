using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeController : MonoBehaviour
{
    EnemyMeleeModel _model;
    FSM<EnemyMeleeStateEnum> _fsm;
    ITreeNode _root;
    private void Awake()
    {
        _model = GetComponent<EnemyMeleeModel>();
        IntializedFSM();
        InitializedTree();
    }

    public void IntializedFSM()
    {
        var list = new List<EnemyMeleeStateBase<EnemyMeleeStateEnum>>();
        _fsm = new FSM<EnemyMeleeStateEnum>();

        var idle = new EnemyMeleeIdleState<EnemyMeleeStateEnum>();
        var jump = new EnemyMeleeJumpState<EnemyMeleeStateEnum>();
        var dead = new EnemyMeleeDiedState<EnemyMeleeStateEnum>();
        var attack = new EnemyMeleeAttackState<EnemyMeleeStateEnum>();

        list.Add(idle);
        list.Add(jump);
        list.Add(dead);
        list.Add(attack);

        for (int i = 0; i < list.Count; i++)
        {
            list[i].InitializedState(_model, _fsm);
        }

        idle.AddTransition(EnemyMeleeStateEnum.Jump, jump);
        idle.AddTransition(EnemyMeleeStateEnum.Dead, dead);

        jump.AddTransition(EnemyMeleeStateEnum.Idle, idle);
        jump.AddTransition(EnemyMeleeStateEnum.Attack, attack);

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
        _fsm.Transitions(EnemyMeleeStateEnum.Idle);
    }
    void ActionJump()
    {
        _fsm.Transitions(EnemyMeleeStateEnum.Jump);
    }
    void ActionDead()
    {
        _fsm.Transitions(EnemyMeleeStateEnum.Dead);
    }
    void ActionAttack()
    {
        _fsm.Transitions(EnemyMeleeStateEnum.Attack);
    }
    private void Update()
    {
        _fsm.OnUpdate();
        _root.Execute();
    }
}
