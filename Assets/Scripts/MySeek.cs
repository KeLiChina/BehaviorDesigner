using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using UnityEngine;

///
///this scripts has been used to control player move to target position
///
public class MySeek : Action
{

    public float speed = 6;
    public SharedTransform target;
	public float arriveDistance = 0.1f;
	private float sqrArriveDistance;
	public override void OnStart()
	{
		// base.OnStart();
		sqrArriveDistance = arriveDistance * arriveDistance;
	}
    public override TaskStatus OnUpdate()
    {
        if (target.Value == null || target == null)
        {
            return TaskStatus.Failure;
        }
        transform.LookAt(target.Value.position);
        transform.position = Vector3.MoveTowards(transform.position, target.Value.position, speed * Time.deltaTime);
		if((target.Value.position - transform.position).sqrMagnitude < sqrArriveDistance)
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Running;
    }

}
