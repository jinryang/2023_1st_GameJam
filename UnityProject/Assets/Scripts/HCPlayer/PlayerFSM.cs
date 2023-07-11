using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public Animator _animator;
    public Move moveSystem;
    private enum State
    {
        Idle,
        Move,
        Attack
    }

    private State _curState;
    private FSM _fsm;

    public void Start()
    {
        _curState = State.Idle;
        _fsm = new FSM(new IdleState(this, _animator));
        //Debug.Log("ddkkdkdkdk");
    }

    public void Update()
    {
        //Debug.Log("zzzzzzzzzzzz");
        switch (_curState)
        {
            case State.Idle:
                if (IsMoving())
                {
                    ChangeState(State.Move);
                }
                else if (CanAttack())
                {
                    ChangeState(State.Attack);
                }
                break;
            case State.Move:
                if (!IsMoving())
                {
                    if (CanAttack())
                    {
                        ChangeState(State.Attack);
                    }
                    else
                    {
                        ChangeState(State.Idle);
                    }
                }
                break;
            case State.Attack:
                if (IsMoving())
                {
                    ChangeState(State.Move);
                }
                else if (!CanAttack())
                {
                    ChangeState(State.Idle);
                }
                break;
        }

        _fsm.UpdateState();
    }

    private void ChangeState(State nextState)
    {
        _curState = nextState;
        switch (_curState)
        {
            case State.Idle:
                _fsm.ChangeState(new IdleState(this, _animator));
                break;
            case State.Move:
                _fsm.ChangeState(new MoveState(this, _animator));
                break;
            case State.Attack:
                _fsm.ChangeState(new AttackState(this, _animator));
                break;
        }
    }

    private bool IsMoving()
    {
        if (Mathf.Abs(transform.position.x - moveSystem.transform.position.x) > 0.5f || Mathf.Abs(transform.position.y - moveSystem.transform.position.y) > 0.5f)
        {
            return true;
        }
        return false;
    }

    private bool CanAttack()
    {
        int EnemyCount = GetComponent<PlayerAttack>().GetCount();

        if (EnemyCount != 0)
            return true;
        return false;
    }
}