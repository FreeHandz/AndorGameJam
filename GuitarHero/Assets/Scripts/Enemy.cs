using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public enum enemyType {
        up,
        right,
        down,
        left
    }
    public float speed;

    public bool isOut = false;
    
    public enemyType type;

	// Use this for initialization
	void Start () {
        speed = Random.Range(GameManager.instance.speedMin, GameManager.instance.speedMax);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3(-1, 0, 0);
        gameObject.transform.Translate(movement * speed * Time.deltaTime);

        if (!gameObject.GetComponent<Renderer>().isVisible && !isOut)
        {
            GameManager.instance.playerHealth--;
            isOut = true;
        }
    }
}
