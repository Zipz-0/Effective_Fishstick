using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Initialize", story: "Initialize [AI]", category: "Action", id: "b3a0de19466662397bf70ad421ab1801")]
public partial class InitializeAction : Action
{
    [SerializeReference] public BlackboardVariable<AIBase> AI;
    [SerializeReference] public BlackboardVariable<float> Health = new BlackboardVariable<float>(100f);
    [SerializeReference] public BlackboardVariable<float> Speed = new BlackboardVariable<float>(100f);


    protected override Status OnStart()
    {
        Health.Value = AI.Value.stats.health;
        Speed.Value = AI.Value.stats.speed;


        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

