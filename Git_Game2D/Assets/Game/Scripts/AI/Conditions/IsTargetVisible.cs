using System.Collections;
using System.Collections.Generic;
using BBUnity.Conditions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Condition("Game/Perception/IsTargetVisible")]


public class IsTargetVisible : GOCondition
{
    [InParam("Target")]
    private GameObject target;

    [InParam("AIVision")]
    private AIVision aiVision;

    [InParam("TargetMemoryDuration")]
    private float TargetMemoryDuration;

    private float forgetTargetTime;

    public override bool Check()
    {
        if(aiVision.IsVisible(target))
        { 
            forgetTargetTime = Time.time + TargetMemoryDuration;
            return true;
        }
        return Time.time < forgetTargetTime;
    }
}
