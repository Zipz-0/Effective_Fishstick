using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack", story: "Perform Attack", category: "Action", id: "ecac9972c6bc2855400b712e65b0a815")]
public partial class AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<AIBase> AI;

    protected override Status OnStart()
    {
       
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
         AI.Value.TriggerAttack();
        Debug.Log("Attack");
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

