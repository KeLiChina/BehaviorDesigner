using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

///
///this scripts has been used to control player move to target position
///
public class MySeek : Action
{

    public float speed = 6;
    public Transform target;
	public float arriveDistance = 0.1f;
	private float sqrArriveDistance;
	public override void OnStart()
	{
		// base.OnStart();
		sqrArriveDistance = arriveDistance * arriveDistance;
	}
    public override TaskStatus OnUpdate()
    {
        if (target == null)
        {
            return TaskStatus.Failure;
        }
        transform.LookAt(target.position);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		if((target.position - transform.position).sqrMagnitude < sqrArriveDistance)
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Running;
    }

}
