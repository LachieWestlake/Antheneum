using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	private Transform bar;

	// Use this for initialization
	void Start () {
		bar = transform.Find("Bar");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetSize(float sizeNormalised)
	{
		bar.localScale = new Vector3(sizeNormalised, 1f);
	}
}
