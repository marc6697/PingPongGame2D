using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
	public float batasatas;
	public float batasbawah;

	public float kecepatan;
	public string axis;



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//atur kecepatan
			float gerak=Input.GetAxis(axis)*kecepatan*Time.deltaTime;
			

			// batas pukulan
			float nextPos=transform.position.y+gerak;
			if(nextPos >batasatas)
			{
				gerak=0;
			}
			if(nextPos<batasbawah)
			{
				gerak=0;
			}
			transform.Translate(0,gerak,0);
	}
}
