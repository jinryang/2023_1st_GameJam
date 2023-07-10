using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public Animator _animator;
    public Move moveSistem;
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
        _fsm = new FSM(new IdleState(this,_animator));
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
                    Debug.Log(1);
                    ChangeState(State.Move);
                }
                else if(CanAttack())
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
                        Debug.Log(2);
                        ChangeState(State.Idle);
                    }
                }
                break;
            case State.Attack:
                if (IsMoving())
                {
                    ChangeState(State.Move);
                }
                else if(!CanAttack())
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
        if (new Vector2(transform.position.x, transform.position.y) != moveSistem.movePoint)
        {
            //Debug.Log("true");
            return true;
        }
        //Debug.Log("false");
        return false;
    }

    private bool CanAttack()
    {
        int EnemyCount = 1;
        if (new Vector2(transform.position.x, transform.position.y) == moveSistem.movePoint && EnemyCount == 0)
            return true;
        return false;
    }
}