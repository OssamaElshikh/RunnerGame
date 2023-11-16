using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playermovement : MonoBehaviour
{
    private bool nextorb = false;
    public AudioSource audiodeath;
    public AudioSource audio2;
    public AudioSource audio3;
    public AudioSource audio4;
    public AudioSource audio5;
    public AudioSource audio6;
    public AudioSource error;
    private CharacterController controller;
    public tilemanager tileManager;
    private Vector3 direction;
    public float forwardspeed;
    private int desiredlane = 1;
    public float laneDistance = 3;
    public float gravity = -20;
    public int scoreadd = 1;
    public static int score, blueE, yellowE, redE = 0;
    public TMPro.TextMeshProUGUI redenergy;
    public TMPro.TextMeshProUGUI blueenergy;
    public TMPro.TextMeshProUGUI yellowenergy;
    public TMPro.TextMeshProUGUI thescore;
    public int form=0;  // 0:normal 1:red 2:blue 3:yellow
    public Material playerMaterial;
    public bool shield=false;
    public Shield shieldScript;
    public static Vector3 laneposition;
    public PausePanel pause;

    void Start()
    {
        yellowE = 0;redE = 0; blueE = 0;score = 0;

        controller = GetComponent<CharacterController>();
        form = 0;
        playerMaterial.color = Color.white;

    }

    // Update is called once per frame
    void Update()
    {

            
            direction.z = forwardspeed;
            direction.y += gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                desiredlane++;
                if (desiredlane == 3)
                    desiredlane = 2;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                desiredlane--;
                if (desiredlane == -1)
                    desiredlane = 0;
            }
            Vector3 targetposition = transform.position.z * transform.forward + transform.position.y * transform.up;

            if (desiredlane == 0)
            {
                targetposition += Vector3.left * laneDistance;
            }
            else if (desiredlane == 2)
            {
                targetposition += Vector3.right * laneDistance;
            }

            if (transform.position != targetposition)
            {
                Vector3 diff = targetposition - transform.position;
                Vector3 movedirec = diff.normalized * 25 * Time.deltaTime;

                if (movedirec.sqrMagnitude < diff.sqrMagnitude)
                    controller.Move(movedirec);
                else
                    controller.Move(diff);
            }

            handleformchange();

        handlespace();
        //laneposition = targetposition;
        //Debug.Log(laneposition);


        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (isPaused)
        //    {
        //        // If the game is already paused, resume it
        //        ResumeGame();
        //    }
        //    else
        //    {
        //        // If the game is not paused, pause it
        //        PauseGame();
        //    }
        //}




        //}
        //if (form == 0)
        //{
        //    playerMaterial.color = Color.white;
        //}






    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);



    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        // if in normal form
        if (form == 0)
        {
            if (hit.transform.tag == "obstacle")
            {
                thescore.text = "Score:" + score;
                GameOverscript.gameover = true;
                audiodeath.Play();
                score = 0;
            }

            if (hit.transform.tag == "coins")
            {
                audio6.Play();
                Destroy(hit.gameObject);
                score += scoreadd;
                if (yellowE < 5)
                { yellowE += 1; }
                yellowenergy.text = "Yellow energy: " + yellowE;
                thescore.text = "Score:" + score;

            }
            if (hit.transform.tag == "bluecoins")
            {
                audio6.Play();

                Destroy(hit.gameObject);
                score += scoreadd;
                if (blueE < 5)
                { blueE += 1; }
                blueenergy.text = "Blue energy: " + blueE;
                thescore.text = "Score:" + score;
            }
            if (hit.transform.tag == "redcoins")
            {
                audio6.Play();

                Destroy(hit.gameObject);
                score += scoreadd;
                if (redE <5)
                { redE += 1; }
                redenergy.text = "Red energy: " + redE;
                thescore.text = "Score:" + score;
            }
        }

        //red mode collisions
        //redform
        if (form == 1)
        {
            if (hit.transform.tag == "obstacle")
            {
                Destroy(hit.gameObject);
                form = 0;
                playerMaterial.color = Color.white;
            }

            if (hit.transform.tag == "coins")
            {
                audio6.Play();

                Destroy(hit.gameObject);
                score += scoreadd;
                if (yellowE < 5)
                { yellowE += 1; }
                yellowenergy.text = "Yellow energy: " + yellowE;
                thescore.text = "Score:" + score;

            }
            if (hit.transform.tag == "bluecoins")
            {
                audio6.Play();

                Destroy(hit.gameObject);
                score += scoreadd;
                if (blueE < 5)
                { blueE += 1; }
                blueenergy.text = "Blue energy: " + blueE;
                thescore.text = "Score:" + score;
            }
            if (hit.transform.tag == "redcoins")
            {
                audio6.Play();

                Destroy(hit.gameObject);
                score += 2;
               
                 if (redE < 4) { redE += 2; }
                else if (redE == 4)
                { redE += 1; }
                redenergy.text = "Red energy: " + redE;
                thescore.text = "Score:" + score;
            }
        }

        //yellow form
        if (form == 2)
          
        {

            if (hit.transform.tag == "obstacle")
            {
                Destroy(hit.gameObject);
                form = 0;
                playerMaterial.color = Color.white;
            }

            if (hit.transform.tag == "coins")
            {
                if (nextorb == true)
                {
                    audio6.Play();

                    score += 50;
                    thescore.text = "Score:" + score;
                    Destroy(hit.gameObject);
                }
                else
                {
                    audio6.Play();

                    Destroy(hit.gameObject);
                    score += 10;
                    yellowenergy.text = "Yellow energy: " + yellowE;
                    thescore.text = "Score:" + score;
                }

            }
            if (hit.transform.tag == "bluecoins")
            {
                if (nextorb == true)
                {
                    audio6.Play();

                    score += 5*5;
                  
                     blueE += 4;
                    if (blueE >= 5)
                    {
                        blueE = 5;
                    }

                    blueenergy.text = "Blue energy: " + blueE;
                    thescore.text = "Score:" + score;
                    nextorb = false;
                    Destroy(hit.gameObject);
                }
                else
                {
                    audio6.Play();

                    Destroy(hit.gameObject);
                    score += 5;
                    if (blueE == 4)
                    { blueE += 1; }
                    if (blueE < 4)
                    { blueE += 2; }
                    blueenergy.text = "Blue energy: " + blueE;
                    thescore.text = "Score:" + score;
                }
            }
            if (hit.transform.tag == "redcoins")
            {
                if (nextorb == true)
                {
                    audio6.Play();

                    score += 5*5;
                    redE += 4;
                    if (redE >= 5)
                    {
                        redE = 5;
                    }

                    blueenergy.text = "Red energy: " + redE;
                    thescore.text = "Score:" + score;
                    nextorb = false;
                    Destroy(hit.gameObject);
                }
                else
                {
                    audio6.Play();

                    Destroy(hit.gameObject);
                    score += 5;
                    if (redE == 4)
                    { redE += 1; }
                    if (redE < 4)
                    { redE += 2; }
                    redenergy.text = "Red energy: " + redE;
                    thescore.text = "Score:" + score;
                }
            }
        }

        //blueform
        if (form == 3)
        {
            if (hit.transform.tag == "obstacle" && (shield==false))
            {
                audio6.Play();

                Destroy(hit.gameObject);
                form = 0;
                shieldScript.isShieldActive = false;
                playerMaterial.color = Color.white;
            }
            else if (hit.transform.tag == "obstacle" && (shield == true))
            {
                audio2.Play();
                Destroy(hit.gameObject);
                shield = false;
                shieldScript.isShieldActive = false;
            }
            if (hit.transform.tag == "coins")
            {
                audio6.Play();

                Destroy(hit.gameObject);
                score += scoreadd;
                if (yellowE < 5)
                { yellowE += 1; }
                yellowenergy.text = "Yellow energy: " + yellowE;
                thescore.text = "Score:" + score;

            }
            if (hit.transform.tag == "bluecoins")
            {
                audio6.Play();

                Destroy(hit.gameObject);
                score += scoreadd;
                if (blueE < 4)
                { blueE += 2; }
                else if (blueE == 4 )
                { blueE += 2; }
                blueenergy.text = "Blue energy: " + blueE;
                thescore.text = "Score:" + score;
            }
            if (hit.transform.tag == "redcoins")
            {
                audio6.Play();

                Destroy(hit.gameObject);
                score += scoreadd;
                if (redE < 5)
                { redE += 1; }
                redenergy.text = "Red energy: " + redE;
                thescore.text = "Score:" + score;
            }
        }
        if (form == 4)
        {
            if ((hit.transform.tag == "obstacle") || (hit.transform.tag == "redcoins") || (hit.transform.tag == "bluecoins") || (hit.transform.tag == "coins") ){
                Destroy(hit.gameObject);
            }

        }

    }
    public void handleformchange()
    {
        if (pause.isPaused == false)
        {
            if ((Input.GetKeyDown(KeyCode.J)) && (yellowE < 5))
            {
                error.Play();
            }
            if ((Input.GetKeyDown(KeyCode.K)) && (redE < 5))
            {
                error.Play();
            }
            if ((Input.GetKeyDown(KeyCode.L)) && (blueE < 5))
            {
                error.Play();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                playerMaterial.color = Color.black;
                form = 4;
            }

            if (Input.GetKeyDown(KeyCode.J) && (yellowE >= 5) && (form != 2))
            {
                shield = false;
                shieldScript.isShieldActive = false;
                audio3.Play();
                form = 2;
                playerMaterial.color = Color.yellow;
                yellowE--;
                yellowenergy.text = "Yellow energy: " + yellowE;
                Debug.Log(form);


            }
            else if (Input.GetKeyDown(KeyCode.K) && (redE >= 5) && (form != 1))

            {
                nextorb = false;
                shield = false;
                shieldScript.isShieldActive = false;
                audio4.Play();
                form = 1;
                playerMaterial.color = Color.red;
                redE--;

                redenergy.text = "Red energy: " + redE;
                Debug.Log(form);


            }

            else if (Input.GetKeyDown(KeyCode.L) && (blueE >= 5) && (form != 3))

            {
                nextorb = false;
                audio5.Play();
                form = 3;
                playerMaterial.color = Color.blue;
                blueE--;
                shield = true;
                shieldScript.isShieldActive = true;

                blueenergy.text = "Blue energy: " + blueE;



            }
            else if ((form == 2) && (yellowE <= 0))
            {
                form = 0;

                playerMaterial.color = Color.white;
            }
            else if ((form == 1) && (redE <= 0))
            {
                form = 0;

                playerMaterial.color = Color.white;
            }
            else if ((form == 3) && (blueE <= 0))
            {
                form = 0;
                Debug.Log(form);
                playerMaterial.color = Color.white;
            }
            //else if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
            //{
            //    error.Play();
            //}
        }
    }

    public void handlespace()

    {
        if (pause.isPaused == false)
        {
            if ((Input.GetKeyDown(KeyCode.Space)) && (form == 3) && (blueE == 1))
            {
                shieldScript.isShieldActive = false;
            }
            if ((Input.GetKeyDown(KeyCode.Space)) && (2 == 3) && (yellowE == 1))
            {
                nextorb = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) & (form == 0))
            {
                error.Play();
            }
            if (Input.GetKeyDown(KeyCode.Space) & (form == 2))
            {
                audio2.Play();
                yellowE--;
                yellowenergy.text = "Yellow energy:" + yellowE;
                nextorb = true;
                Debug.Log(nextorb);
                if (yellowE == 0)
                {
                    form = 0;
                    playerMaterial.color = Color.white;
                }
            }

            else if (Input.GetKeyDown(KeyCode.Space) && (form == 1) && (redE >= 1))
            {
                audio2.Play();
                redE--;
                redenergy.text = "Red energy: " + redE;
                GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
                foreach (GameObject obstacle in obstacles)
                {
                    Destroy(obstacle);
                }
                if (redE == 0)
                {
                    form = 0;
                    playerMaterial.color = Color.white;
                }
            }

            else if (Input.GetKeyDown(KeyCode.Space) && (form == 3) && (blueE >= 1) && (shield == false))
            {

                audio2.Play();
                blueE--;
                blueenergy.text = "Blue energy:" + blueE;
                shield = true;
                shieldScript.isShieldActive = true;
                if (blueE == 0)
                {
                    shield = false;
                    shieldScript.isShieldActive = false;
                }

            }
            else if (Input.GetKeyDown(KeyCode.Space) && (form == 3) && (shield == true))
            {

            }
        }
    }
    //public void PauseGame()
    //{
    //    Time.timeScale = 0.0f; // Pause the game by setting time scale to 0
    //    isPaused = true; // Update the isPaused flag
    //    pausePanel.SetActive(true); // Show the pause panel
    //}

    //// Function to resume the game and hide the pause panel
    //public void ResumeGame()
    //{
    //    Time.timeScale = 1.0f; // Resume the game by setting time scale to 1
    //    isPaused = false; // Update the isPaused flag
    //    pausePanel.SetActive(false); // Hide the pause panel
    //}
}






