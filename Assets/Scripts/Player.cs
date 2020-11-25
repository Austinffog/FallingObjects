using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class Player : MonoBehaviour
{
    public float speed = 15f;

    public static bool GameIsPaused = false;
    public GameObject GameOverMenu;

    public int item;

    [HideInInspector]
    public bool FreezeY = true;
    private Vector3 originPos;

    protected Joystick joystick;

    //private string storeID = "3522631";
    //private string rewardedVideoID = "rewardedVideo";

    //private int no;

    public Transform player;

    void Start()
    {
        //Advertisement.Initialize(storeID, false);
        originPos = transform.position;
        joystick = FindObjectOfType<Joystick>();

        //no = Random.Range(1, 4);
    }


    void FixedUpdate()
    {
        var rigidbody = GetComponent<Rigidbody>();
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        //rigidbody.velocity = new Vector3(horizontal * speed, rigidbody.velocity.y,
        //    vertical * speed);

        //if (horizontal != 0f || vertical != 0f)
        //{
        //    //Create a new vector of the horizontal and vertical inputs.
        //    Vector3 targetDirection = new Vector3(horizontal, 0, vertical);

        //    //Create a rotation based on this new vector assuming that up is the global y axis.
        //    Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        //    //Create a rotation that is an increment closer to the target rotation from the player's rotation.
        //    Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, 5f * Time.deltaTime);

        //    //Change the players rotation to this new rotation.
        //    rigidbody.MoveRotation(newRotation);
        //}

        //CharacterController controller = GetComponent<CharacterController>();
        //Vector3 move = new Vector3(joystick.Horizontal * Time.deltaTime, 0, joystick.Vertical * Time.deltaTime);
        //move = transform.TransformDirection(move);
        //controller.Move(move * speed);

        rigidbody.velocity = new Vector3(joystick.Horizontal * speed, rigidbody.velocity.y, joystick.Vertical * speed);

        if (joystick.Horizontal != 0f || joystick.Vertical != 0f)
        {
            //Create a new vector of the horizontal and vertical inputs.
            Vector3 targetDirection = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);

            //Create a rotation based on this new vector assuming that up is the global y axis.
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

            //Create a rotation that is an increment closer to the target rotation from the player's rotation.
            Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, 5f * Time.deltaTime);

            //Change the players rotation to this new rotation.
            rigidbody.MoveRotation(newRotation);
        }

        Vector3 currentPos = transform.position;
        if (FreezeY)
            currentPos.y = originPos.y;
        transform.position = currentPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Player") && collision.gameObject.CompareTag("Object"))
        {
            Destroy(collision.gameObject);
            GameOver();
        }
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;


    }

    //public void Reward()
    //{

    //    if (Advertisement.IsReady(rewardedVideoID))
    //    {

    //        var options = new ShowOptions { resultCallback = Options };
    //        Advertisement.Show(rewardedVideoID, options);

    //    }

    //}

    //private void Options(ShowResult result)
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //    GameOverMenu.SetActive(false);
    //    Time.timeScale = 1f;
    //    GameIsPaused = false;



    //    switch (result)
    //    {
    //        case ShowResult.Finished:

    //            if (no == 1)
    //            {
    //                item = 30;
    //                PlayerPrefs.SetInt("Item", item);
    //            }
    //            else if (no == 2)
    //            {
    //                item = 100;
    //                PlayerPrefs.SetInt("Item", item);
    //            }
    //            else if (no == 3)
    //            {
    //            }
    //            break;
    //    }
    //}

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        item = 0;
        PlayerPrefs.SetInt("Item", item);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        item = 0;
        PlayerPrefs.SetInt("Item", item);
    }

}
