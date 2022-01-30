using System.Collections;
using System.Collections.Generic;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("Game/Patrol")]

public class Patrol : BasePrimitiveAction
{
    [InParam("AIController")]
    private EnemyAIController aiController;

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("Patrol: OnStart");
        aiController.StartCoroutine(TEMP_Walk());
    }

    public override TaskStatus OnUpdate()
    {
        Debug.Log("Patrol: OnUpdate");
        return TaskStatus.RUNNING;
    }

    public override void OnAbort()
    {
        base.OnAbort();

        // TODO: Remover Corotine
        aiController.StopAllCoroutines();
    }

    IEnumerator TEMP_Walk()
    {
        while(true)
        { 
            aiController.movementInput.x =1;
            yield return new WaitForSeconds(1.0f);
            aiController.movementInput.x =0;
            yield return new WaitForSeconds(2.0f);
            aiController.movementInput.x =-1;
            yield return new WaitForSeconds(1.0f);
            aiController.movementInput.x =0;
            yield return new WaitForSeconds(2.0f);
        }
      

    }
}
