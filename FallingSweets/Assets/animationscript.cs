using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationscript : MonoBehaviour {
	
	public Animation Animation;

	protected void Awake()
	{
		Animation = GetComponent<Animation>();
	}

	protected void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Animation.Play ();
		} else if (Input.GetMouseButtonUp (0)) {
			Animation.Stop ();
		}
	}
}
