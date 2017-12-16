using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public enum type {
        up,
        right,
        down,
        left
    }
    public int speed = 3;
    
    public bool isInRange = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3(-1, 0, 0);
        gameObject.transform.Translate(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInRange = true;
        Debug.Log(isInRange);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        Debug.Log(isInRange);
        gameObject.SetActive(false);
    }
}
