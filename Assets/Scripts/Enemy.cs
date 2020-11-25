using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 10f;
    public Transform target;

    public bool FreezeY = true;
    private Vector3 originPos;

    public static bool GameIsPaused = false;
    public GameObject GameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 pos = target.position - transform.position; //enemy follows the player
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;

        Vector3 currentPos = transform.position; //fix the poistion on the y axis
        if (FreezeY)
            currentPos.y = originPos.y;
        transform.position = currentPos;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) //destroy if in contact with the player
        {
            Destroy(gameObject);
            GameOver();
        }

        if (collision.gameObject.CompareTag("Destroy")) //destroy if in contact with others: wall, marble, bomb, shield, barrier
        {
            Destroy(gameObject);
        }

        //if (collision.gameObject.CompareTag("Barrier"))
        //{
        //    Destroy(gameObject);
        //}
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
