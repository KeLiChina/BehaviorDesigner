using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using BehaviorDesigner.Runtime;
using UnityEngine.AI;
public class Defend : Action {

	public SharedFloat viewDistance;
	public SharedFloat fieldOfViewAngle;
	public SharedFloat speed;
	public SharedFloat angularSpeed;
	public SharedTransform target;
	private float sqrViewDistance;
	private NavMeshAgent agent;

	 public override void OnAwake()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.enabled= true;
		agent.speed = speed.Value;
		agent.angularSpeed = angularSpeed.Value;
		agent.destination = target.Value.position;

	}
	public override void OnStart()
	{
		sqrViewDistance = viewDistance.Value*viewDistance.Value;
	}
	public override TaskStatus OnUpdate()
	{
		if (target==null&&target.Value == null)
		{
		return TaskStatus.Failure;
		}
		float sqrDistance = (target.Value.position - transform.position).sqrMagnitude;
		float angle = Vector3.Angle(transform.forward,target.Value.position-transform.position);
		
		if (sqrDistance < sqrViewDistance && angle < fieldOfViewAngle.Value*0.5f)
		{
			if (agent.destination != target.Value.position)
			{
				agent.destination = target.Value.position;
				
			}return TaskStatus.Running;
		}
		else
		{
			return TaskStatus.Success;
		}
	}
	public override void OnEnd()
	{
			agent.enabled= false;
	}
}
