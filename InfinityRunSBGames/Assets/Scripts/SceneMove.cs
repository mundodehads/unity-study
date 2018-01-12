using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour {

	public float x;
	public float y;

	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2(Time.time * x, y * Time.time);
		this.GetComponent<Renderer>().material.mainTextureOffset = offset;
	}

	public float getX (){
		return x;
	}

	public void setX (float newX){
		x = newX;
	}

	public float getY (){
		return y;
	}

	public void setY (float newY){
		y = newY;
	}

}
