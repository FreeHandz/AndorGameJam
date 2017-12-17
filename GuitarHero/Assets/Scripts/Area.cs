using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

    public List<GameObject> enemiesInRange;
    public AudioSource audioSource;
    public AudioClip missSound;

    // Use this for initialization
    void Start () {
        enemiesInRange = new List<GameObject>();
    }

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var found = 0;
            foreach (GameObject enemy in enemiesInRange)
            {
                if (enemy.GetComponent<Enemy>().type == Enemy.enemyType.down)
                {
                    // enemy.GetComponent<Animator>().SetTrigger("Fire");
                    enemiesInRange.Remove(enemy);
                    enemy.gameObject.SetActive(false);
                    GameManager.instance.playerPoints++;
                    found++;
                    break;
                }
            }

            if (found == 0)
            {
                audioSource.PlayOneShot(missSound);
                GameManager.instance.playerHealth--;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var found = 0;
            foreach (GameObject enemy in enemiesInRange)
            {
                if (enemy.GetComponent<Enemy>().type == Enemy.enemyType.right)
                {
                    enemiesInRange.Remove(enemy);
                    enemy.gameObject.SetActive(false);
                    GameManager.instance.playerPoints++;
                    found++;
                    break;
                }
            }


            if (found == 0)
            {
                GameManager.instance.playerHealth--;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var found = 0;
            foreach (GameObject enemy in enemiesInRange)
            {
                if (enemy.GetComponent<Enemy>().type == Enemy.enemyType.left)
                {
                    enemiesInRange.Remove(enemy);
                    enemy.gameObject.SetActive(false);
                    GameManager.instance.playerPoints++;
                    found++;
                    break;
                }
            }


            if (found == 0)
            {
                GameManager.instance.playerHealth--;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var found = 0;
            foreach (GameObject enemy in enemiesInRange)
            {
                if (enemy.GetComponent<Enemy>().type == Enemy.enemyType.up)
                {
                    enemy.gameObject.SetActive(false);
                    enemiesInRange.Remove(enemy);
                    GameManager.instance.playerPoints++;
                    found++;
                    break;
                }
            }

            if (found == 0)
            {
                GameManager.instance.playerHealth--;
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
