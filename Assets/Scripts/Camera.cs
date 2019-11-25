using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public Transform target;
    public float smoothing = 0.05f;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;
        Screen.SetResolution(540, 960, true); 
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 Campos = target.position + offset;
        transform.position = Vector3.Lerp
            (transform.position, Campos, smoothing);
	}
}
