using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class IsHaveFlag : Conditional {
   
    private Offense offense;
	public override void OnAwake()
	{
		offense = this.GetComponent<Offense>();
	}
	public override TaskStatus OnUpdate()
	{
		if (offense.hasflag){
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;	
	}
}
