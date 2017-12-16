using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

    public List<GameObject> enemiesInRange;
	// Use this for initialization
	void Start () {
        enemiesInRange = new List<GameObject>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            foreach (GameObject enemy in enemiesInRange)
            {
                if (enemy.GetComponent<Enemy>().type == Enemy.enemyType.down)
                {
                    enemiesInRange.Remove(enemy);
                    enemy.gameObject.SetActive(false);
                    GameManager.instance.playerPoints++;
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            foreach (GameObject enemy in enemiesInRange)
            {
                if (enemy.GetComponent<Enemy>().type == Enemy.enemyType.right)
                {
                    enemiesInRange.Remove(enemy);
                    enemy.gameObject.SetActive(false);
                    GameManager.instance.playerPoints++;
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            foreach (GameObject enemy in enemiesInRange)
            {
                if (enemy.GetComponent<Enemy>().type == Enemy.enemyType.left)
                {
                    enemiesInRange.Remove(enemy);
                    enemy.gameObject.SetActive(false);
                    GameManager.instance.playerPoints++;
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            foreach (GameObject enemy in enemiesInRange)
            {
                if (enemy.GetComponent<Enemy>().type == Enemy.enemyType.up)
                {
                    enemy.gameObject.SetActive(false);
                    enemiesInRange.Remove(enemy);
                    GameManager.instance.playerPoints++;
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemiesInRange.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemiesInRange.Remove(collision.gameObject);
    }
}
