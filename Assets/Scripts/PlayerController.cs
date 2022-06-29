using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class PlayerController : MonoBehaviour
{
    private InterstitialAd interstitial;
    private Rigidbody myRigidBody;
    public GameObject confettiPos;
    public Transform partcilePrefab;
    private Vector3 lastMousePos;
    public GameObject line;
    [SerializeField]
    private float sensitivity = .5f,
                                    clampDelta = 50f,
                                        bounds = 5f;

    [HideInInspector]
    public bool canMove, gameOver, finish;
    [HideInInspector]
    public int m_playerPrefScene;
    // private ADManager adManager;
    [SerializeField]
    private GameObject breakablePlayer;


    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        //line.gameObject.GetComponent<TrailRenderer>().emitting = true;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds, bounds), transform.position.y, transform.position.z);
        if (canMove)
        {
            transform.position += FindObjectOfType<CameraMovement>().camVelocity;
        }

        if (!canMove && gameOver)
        {

            if (Input.GetMouseButtonDown(0))
            {

                GameManager.instance.RestartGame();
                Time.timeScale = 1;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
        }
        else if (!canMove && !finish)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<GameManager>().RemoveUI();
                canMove = true;
            }

        }

    }



    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;

        }

        if (canMove)
        {
            if (Input.GetMouseButton(0)) //left mouse button or mobile device touch
            {
                Vector3 vector = lastMousePos - Input.mousePosition;
                lastMousePos = Input.mousePosition;
                vector = new Vector3(vector.x, 0, vector.y);

                Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta);

                myRigidBody.AddForce(Vector3.forward * 2 + (-moveForce * sensitivity - myRigidBody.velocity), ForceMode.VelocityChange);

            }
        }

        myRigidBody.velocity.Normalize();

    }

    public void GameOver()
    {
        GameObject shatterSphere = Instantiate(breakablePlayer, transform.position, Quaternion.identity);

        foreach (Transform o in shatterSphere.transform)
        {
            o.GetComponent<Rigidbody>().AddForce(Vector3.forward * 4, ForceMode.Impulse);
           
        }


        canMove = false;
        gameOver = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        Time.timeScale = .3f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        StartCoroutine(ShowAds());

    }
    private IEnumerator ShowAds(float time = 0.3f)
    {
        yield return new WaitForSeconds(time);
        ADManager.Instance.SetInterstitialAd();
        StartCoroutine(GameoverCoroutine());

    }

    IEnumerator GameoverCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        GameManager.instance.GameOver();
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            if (!gameOver)
                GameOver();
        }
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.name == "Finish")
        {
            DataManager.Clear();
            FinishParticle();
            GameOver();    
        }
    }
    void FinishParticle()
    {

        Transform partcile = Instantiate(partcilePrefab, confettiPos.transform.position, Quaternion.identity);
    }

}
