using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
	private Offense owner;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Offense")
        {
			if (owner != null)
			{
				owner.hasflag = false;
			}
            other.GetComponent<Offense>().hasflag = true;
			owner = other.GetComponent<Offense>();
            transform.parent = other.transform;
        }
    }
}
