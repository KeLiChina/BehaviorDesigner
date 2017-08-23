using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class MyCanSee : Conditional
{

    public Transform[] targets;
    public SharedFloat viewDistance = 7f;
    public SharedFloat fieldOfViewAngle = 90;
	// public Transform target;
	public SharedTransform target;
    public override TaskStatus OnUpdate()
    {
        if (targets == null)
            return TaskStatus.Failure;
        foreach (var target in targets)
        {
            float disatance = (target.position - transform.position).magnitude;
            float angle = Vector3.Angle(transform.forward, target.position - transform.position);
            if (disatance < viewDistance.Value && angle < fieldOfViewAngle.Value * 0.5f)
            {
				this.target.Value = target;
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }
}
