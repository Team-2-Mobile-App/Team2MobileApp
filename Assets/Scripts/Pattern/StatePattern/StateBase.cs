using UnityEngine;

/// <summary>
/// Basic state template 
/// </summary>
/// <typeparam name="TStateIDType">The type of the state ID</typeparam>
public class StateBase<TContex>
{
    public string StateID;
    protected StatesMachine<TContex> _stateMachine;

    public StateBase(string stateID, StatesMachine<TContex> stateMachine)
    {
        StateID = stateID;
        _stateMachine = stateMachine;
    }

    public virtual void OnEnter(TContex contex)
    {
        Debug.Log("OnEnter " + StateID);

    }

    public virtual void OnUpdate(TContex contex)
    {
        //Debug.Log("OnUpadte " + StateID);
    }

    public virtual void OnFixedUpdate(TContex contex)
    {
        //Debug.Log("OnUpadte " + StateID);
    }


    public virtual void OnLateUpdate(TContex contex)
    {

    }


    public virtual void OnExit(TContex contex)
    {
        Debug.Log("OnExit " + StateID);
    }



}

