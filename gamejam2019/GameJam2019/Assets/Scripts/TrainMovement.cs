using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrainMovement : MonoBehaviour
{
    private float speed = 3;
    private float angleInc = 0;
    private Rigidbody rb;
    private bool isRight = false;
    private float cooldown;
    private Vector3 defaultPos;
    private Vector3 defaultRot;
    private enum Cargo { none, red, blue, yellow}
    private Cargo myCargo;
    private GameObject scoreObject;
    private Text scoreText;
    private float scoreValue = 0;
    [SerializeField] private GameObject redCargoPrefab;
    [SerializeField] private GameObject blueCargoPrefab;
    [SerializeField] private GameObject yellowCargoPrefab;
    private GameObject cargoInst;



    private void Start()
    {
        scoreObject = GameObject.FindWithTag("score");
        scoreText = scoreObject.GetComponent<Text>();
        
        switch (Random.Range(1, 3))
        {
            case 1:
                myCargo = Cargo.red;
                cargoInst = Instantiate(redCargoPrefab, transform.position - transform.forward * 3, Quaternion.identity);
                cargoInst.transform.SetParent(transform);
                break;
            case 2:
                myCargo = Cargo.blue;
                cargoInst = Instantiate(blueCargoPrefab, transform.position - transform.forward * 3, Quaternion.identity);
                cargoInst.transform.SetParent(transform);
                break;
            case 3:
                myCargo = Cargo.yellow;
                cargoInst = Instantiate(yellowCargoPrefab, transform.position - transform.forward * 3, Quaternion.identity);
                cargoInst.transform.SetParent(transform);
                break;
        }
        defaultPos = transform.position;
        defaultRot = transform.eulerAngles;
        rb = transform.GetComponent<Rigidbody>();
        cooldown = Time.time;
    }

    public void FixedUpdate()
    {
        UpdateSpeed();
        UpdateAngle();
    }
    public void Update()
    {
        TakeInput();
    }
    private void TakeInput()
    {
        //increase speed when button is pressed and/or held 
        if (Input.GetKey(KeyCode.W))
        {
            speed += 0.5f;
            if (speed >= 30)
            {
                speed = 30;
            }
        }
        //reduce speed when button is pressed and/or held
        if (Input.GetKey(KeyCode.S))
        {
            speed -= 0.5f;
            if (speed <= 0)
            {
                speed = 0;
            }
        }
    }
    private void UpdateSpeed()
    {
        Vector3 move = transform.forward * speed;
        rb.velocity = move;
    }
    private void UpdateAngle()
    {
        //Debug.Log(isRight);
        cooldown = Time.time + 1;
        Vector3 rot = transform.eulerAngles;
        if (!isRight)//if left is true
        {
            rot.y -= angleInc / 50 * speed;
            //change angle by speed
        }
        if (isRight)//if right is true
        {
            rot.y += angleInc / 50 * speed;
            //change angle by speed
        }
        transform.eulerAngles = rot;
    }
    public void SetAngle(float aAngleInc)
    {
        angleInc = aAngleInc;
    }
    public void SetTurn(bool aIsRight)
    {
        isRight = aIsRight;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "cargo":
                transform.position = defaultPos;
                transform.eulerAngles = defaultRot;
                speed = 3;
                angleInc = 0;
                switch(other.name)
                {
                    case "Red":
                        if (myCargo == Cargo.red)
                        {
                            scoreValue += 100;
                            scoreText.text = "Score: " + scoreValue;
                        }
                        break;
                    case "Blue":
                        if (myCargo == Cargo.blue)
                        {
                            scoreValue += 100;
                            scoreText.text = "Score: " + scoreValue;
                        }
                        break;
                    case "Yellow":
                        if (myCargo == Cargo.yellow)
                        {
                            scoreValue += 100;
                            scoreText.text = "Score: " + scoreValue;
                        }
                        break;

                }//end switch
                Destroy(cargoInst.gameObject);
                switch(Random.Range(1, 3))
                {
                    case 1:
                        myCargo = Cargo.red;
                        cargoInst = Instantiate(redCargoPrefab, transform.position - transform.forward * 3, Quaternion.identity);
                        cargoInst.transform.SetParent(transform);
                        break;
                    case 2:
                        myCargo = Cargo.blue;
                        cargoInst = Instantiate(blueCargoPrefab, transform.position - transform.forward * 3, Quaternion.identity);
                        cargoInst.transform.SetParent(transform);
                        break;
                    case 3:
                        myCargo = Cargo.yellow;
                        cargoInst = Instantiate(yellowCargoPrefab, transform.position - transform.forward * 3, Quaternion.identity);
                        cargoInst.transform.SetParent(transform);
                        break;
                }
                break;//end cargo
            case "enemy":
                Debug.Log("You Ded");
                SceneManager.LoadScene("StartMenu");
                SceneManager.UnloadSceneAsync(1);
                break;
        }
    }
}
