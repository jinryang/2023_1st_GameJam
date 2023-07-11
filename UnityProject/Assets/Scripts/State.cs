using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{

    protected PlayerFSM _monster;
    public Animator animator;
    protected BaseState(PlayerFSM monster, Animator _animator)
    {
        _monster = monster;
        animator = _animator;
    }

    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();
}

public class IdleState : BaseState
{
    public IdleState(PlayerFSM monster, Animator _animator) : base(monster, _animator) { }

    public override void OnStateEnter()
    {
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsRun", false);
    }

    public override void OnStateUpdate()
    {
    }

    public override void OnStateExit()
    {
    }
}

public class MoveState : BaseState
{
    public MoveState(PlayerFSM monster, Animator _animator) : base(monster, _animator) { }

    public override void OnStateEnter()
    {
        animator.SetBool("IsRun", true);
    }

    public override void OnStateUpdate()
    {
    }

    public override void OnStateExit()
    {
    }
}

public class AttackState : BaseState
{
    public AttackState(PlayerFSM monster, Animator _animator) : base(monster, _animator) { }

    public override void OnStateEnter()
    {
        animator.SetBool("IsRun", false);
        animator.SetBool("IsAttack", true);
    }   

    public override void OnStateUpdate()
    {
    }

    public override void OnStateExit()
    {
    }
}