using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class MyCanSee : Conditional {

	public Transform[] targets;
	public float viewDistance = 7f;
	public float fieldOfViewAngle = 90;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// public override TaskStatus OnUpdate()
	// {
	// 	if (targets == null)
	// 		return TaskStatus.Failure;
	// 	foreach (var one in targets)
	// 	{
	// 		float dis
	// 	}
	// }
}
