using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Item : MonoBehaviour
{
    public static int item = 0;
    public Text itemAmount;

    public GameObject Button1, Button5, Button10, Button20,
        Button30, Button50, Button75, Button100, Button115, Button145, Button150, Button180, Button200;

    int objects;
    public GameObject[] randomObject;

    public static bool ButtonIsPressed = false;

    public GameObject player;
    public GameObject wall;
    public GameObject marble;
    public GameObject Shield;
    public GameObject[] spawner;
    public GameObject[] falling;
    public CapsuleCollider coll;
    public GameObject decoy;
    public GameObject[] fort;
    public GameObject[] deadlyspawner;
    public GameObject[] bombspawner;
    public GameObject barrier;

    public GameObject shieldCounter;
    public GameObject barrierCounter;
    public GameObject invisibleCounter;

    // Start is called before the first frame update
    void Start()
    {
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<Renderer>().material.color = newColor;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        item = PlayerPrefs.GetInt("Item", item);
        ItemBonuses();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            item++;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);
        }

        if (gameObject.CompareTag("Shield") && collision.gameObject.CompareTag("Object") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        //if(gameObject.CompareTag("Barrier") && collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Object"))
        //{
        //    Destroy(collision.gameObject);
        //}

    }

    private void ItemBonuses()
    {
        if (item >= 1)
        {
            Button1.SetActive(true);
        }
        if (item >= 5)
        {
            Button5.SetActive(true);
        }
        if (item >= 10)
        {
            Button10.SetActive(true);
        }
        if (item >= 20)
        {
            Button20.SetActive(true);
        }
        if (item >= 30)
        {
            Button30.SetActive(true);
        }
        if (item >= 50)
        {
            Button50.SetActive(true);
        }
        if (item >= 75)
        {
            Button75.SetActive(true);
        }
        if (item >= 100)
        {
            Button100.SetActive(true);
        }
        if (item >= 115)
        {
            Button115.SetActive(true);
        }
        if (item >= 145)
        {
            Button145.SetActive(true);
        }
        if (item >= 150)
        {
            Button150.SetActive(true);
        }
        if (item >= 180)
        {
            Button180.SetActive(true);
        }
        if (item >= 200)
        {
            Button200.SetActive(true);
        }

        if (item == 0)
        {
            Button1.SetActive(false);
        }
        if (item < 5)
        {
            Button5.SetActive(false);
        }
        if (item < 10)
        {
            Button10.SetActive(false);
        }
        if (item < 20)
        {
            Button20.SetActive(false);
        }
        if (item < 30)
        {
            Button30.SetActive(false);
        }
        if (item < 50)
        {
            Button50.SetActive(false);
        }
        if (item < 75)
        {
            Button75.SetActive(false);
        }
        if (item < 100)
        {
            Button100.SetActive(false);
        }
        if (item < 115)
        {
            Button115.SetActive(false);
        }
        if (item < 145)
        {
            Button145.SetActive(false);
        }
        if (item < 150)
        {
            Button150.SetActive(false);
        }
        if (item < 180)
        {
            Button180.SetActive(false);
        }
        if (item < 200)
        {
            Button200.SetActive(false);
        }
    }

    public void Item1()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 1;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            objects = Random.Range(0, 8);
            Vector3 spawnPosition = new Vector3(Random.Range(1f, 3f), Random.Range(0.5f, 1.9f), Random.Range(1f, 3f));
            Instantiate(randomObject[objects], player.transform.position + spawnPosition, gameObject.transform.rotation);
        }

    }

    public void Item5()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 5;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            Vector3 spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(0.5f, 1.9f), Random.Range(-2.5f, 2.5f));
            Instantiate(wall, player.transform.position + spawnPosition, gameObject.transform.rotation);
        }
    }

    public void Item10()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 10;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            for (float i = 0; i < 20; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(1f, 2.5f), Random.Range(0.5f, 1.9f), Random.Range(1f, 2.5f));
                Instantiate(marble, player.transform.position + spawnPosition, gameObject.transform.rotation);
            }
        }
    }

    public void Item20()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 20;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            objects = Random.Range(0, 3);
            Vector3 spawnPosition = new Vector3(Random.Range(-2f, 2f), Random.Range(0.5f, 1f), Random.Range(-2f, 2f));
            Instantiate(spawner[objects], player.transform.position + spawnPosition, gameObject.transform.rotation);
        }

    }

    public void Item30()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 30;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            Shield.SetActive(true);

            coll = GetComponent<CapsuleCollider>();
            coll.enabled = false;

            shieldCounter.SetActive(true);
            Invoke("ShieldOff", 15f);

        }
    }

    private void ShieldOff()
    {
        ButtonIsPressed = false;

        if (ButtonIsPressed == false)
        {
            Shield.SetActive(false);
            coll.enabled = true;
            shieldCounter.SetActive(false);
        }
    }

    public void Item50()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 50;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            coll = GetComponent<CapsuleCollider>();
            coll.enabled = false;

            invisibleCounter.SetActive(true);
            Invoke("Invisible", 30f);

        }
    }

    private void Invisible()
    {
        ButtonIsPressed = false;

        if (ButtonIsPressed == false)
        {
            coll.enabled = true;
            invisibleCounter.SetActive(false);
        }
    }

    public void Item75()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 75;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            for (float i = 0; i < 10; i++)
            {
                objects = Random.Range(0, 2);
                Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 10, Random.Range(-5f, 5f));
                Instantiate(falling[objects], player.transform.position + spawnPosition, gameObject.transform.rotation);
            }
        }
    }

    public void Item100()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 100;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            Invoke("Bomb", 1f);
        }
    }

    private void Bomb()
    {
        for (float i = 0; i < 15; i++)
        {
            objects = Random.Range(0, 8);
            Vector3 spawnPosition = new Vector3(Random.Range(5f, 10f), Random.Range(0.5f, 1.9f), Random.Range(5f, 10f));
            Instantiate(randomObject[objects], player.transform.position + spawnPosition, gameObject.transform.rotation);
        }

    }

    public void Item115()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 115;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            Vector3 spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), 0, Random.Range(1f, 2.5f));
            Instantiate(decoy, player.transform.position + spawnPosition, gameObject.transform.rotation);
        }
    }

    public void Item145()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 145;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            objects = Random.Range(0, 3);
            Vector3 spawnPosition = new Vector3(Random.Range(-1f, 1f), 0.5f, Random.Range(-2f, 2f));
            Instantiate(fort[objects], player.transform.position + spawnPosition, gameObject.transform.rotation);
        }
    }

    public void Item150()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 150;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            objects = Random.Range(0, 3);
            Vector3 spawnPosition = new Vector3(Random.Range(1f, 5f), Random.Range(0.5f, 1f), Random.Range(1f, 5f));
            Instantiate(deadlyspawner[objects], player.transform.position + spawnPosition, gameObject.transform.rotation);
        }
    }

    public void Item180()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 180;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            Vector3 spawnPosition = new Vector3(0, 0, 0);
            Instantiate(barrier, player.transform.position + spawnPosition, gameObject.transform.rotation);

            barrierCounter.SetActive(true);
            Invoke("BarrierOff", 180f);

        }

    }

    private void BarrierOff()
    {
        ButtonIsPressed = false;

        if (ButtonIsPressed == false)
        {
            Destroy(gameObject);
            barrierCounter.SetActive(false);
        }
    }

    public void Item200()
    {
        ButtonIsPressed = true;

        if (ButtonIsPressed == true)
        {
            item -= 200;
            itemAmount.text = item.ToString();
            PlayerPrefs.SetInt("Item", item);

            objects = Random.Range(0, 3);
            Vector3 spawnPosition = new Vector3(Random.Range(1f, 3f), Random.Range(0.5f, 5f), Random.Range(1f, 5f));
            Instantiate(bombspawner[objects], player.transform.position + spawnPosition, gameObject.transform.rotation);
        }
    }

}
