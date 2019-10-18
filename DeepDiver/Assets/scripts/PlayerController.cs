using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private float moveSpeedX = 5f;
    private float moveSpeedY = 3f;
    private float vcontrol = 0.5f;
    private float velX;
    private float velY;
    Rigidbody2D rb;
    public GameObject playerSprite;
    public GameObject playerSlow;
    //public GameObject playerAttention;
    public GameObject playerFast;
    public GameObject playerItem;
    public int numPlayer=1;

    //Bullet variables
    public GameObject Bullet;
    Vector2 bulletPos;
    private float fireRate = 1f;
    private float nextFire = 0.0f;
    public static int ammo;
    private float timer = 0;
    private float nextAttack = 0.0f;
    bool timerReached = false;
    //end bullet variables


    //attacks variables
    public AttackPanel attackPanel;
    private float recharge = 4.0f;
    //end attacks variables

    //lifes variables
    public LifePanel lifePanel;
    public BlueLife bluelife;
    public static int numberLifes;
    public int lifesItem2=0;
    public AudioSource audioSource;
    public AudioClip audioClip;
    //end lifes variables

    //bubble variables
    public AirPanel airPanel;
    public Image airBarEmpty;
    public GameObject empty;
    public GameObject airblink;
    public GameObject airblink2;
    public Color color;
    public Color color2;

    //end bubble variables

    //timer variables
    public TimerUI timerUI;
    //end timer variables
    
    //items
    public GameObject imgItem1;
    public GameObject imgItem2;
    public GameObject imgItem3;
    public Color tmp;
    public GameObject blood;
    public GameObject blood2;
    public GameObject airborder;
    //end items
    public bool choca = false;

    public string enemy;
    public string SecondLevel;


    void Start () {
        rb = GetComponent<Rigidbody2D>();
        lifePanel.setHealth(numberLifes);
        //playerAttention.SetActive(false);
        playerItem.SetActive(false);
        blood.SetActive(false);
        blood2.SetActive(false);
        attackPanel.setAttack(ammo);
        playerFast.SetActive(false);
        playerSlow.SetActive(false);
        imgItem1 = GameObject.Find("item1");
        imgItem2 = GameObject.Find("item2");
        imgItem3 = GameObject.Find("item3");
        //airPanel.setAir(nAir);
        if (PlayerPrefs.GetInt("ChooseItem3")==1)
        {
            imgItem3.SetActive(true);
            recharge = 2.0f;
            Debug.Log("change recharge\n\n\n");
        }
        else
        {
            imgItem3.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ChooseItem2") == 1)
        {
            imgItem2.SetActive(true);
            lifesItem2 = 2;
        }
        else
        {
            imgItem2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ChooseItem1") == 1)
        {
            imgItem1.SetActive(true);
            playerItem.SetActive(true);
            /*tmp = playerItem.GetComponent<SpriteRenderer>().color;
            tmp.a = 0.0f;
            playerItem.GetComponent<SpriteRenderer>().color = tmp;
            */
        }
        else
        {
            imgItem1.SetActive(false);
            playerItem.SetActive(false);
        }
        bluelife.setHealth(lifesItem2);

    }
	
	// Update is called once per frame
	void Update () {
        //movement
        velX = Input.GetAxis("Horizontal");
        velY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(velX * moveSpeedX, velY * moveSpeedY * vcontrol - moveSpeedY);

        /*if (numberLifes < 2)
        {
            //playerAttention.SetActive(true);
            numPlayer = 4;
        }
        */

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("tecla UP");
            playerSprite.SetActive(false);
            playerSlow.SetActive(true);
            numPlayer = 1;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("tecla UP");
            playerSlow.SetActive(false);
            playerSprite.SetActive(true);
            numPlayer = 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("tecla DWN");
            playerSprite.SetActive(false);
            playerFast.SetActive(true);
            numPlayer = 3;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            Debug.Log("tecla DWN");
            playerFast.SetActive(false);
            playerSprite.SetActive(true);
            numPlayer = 1;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            if (GlobalVariables.ChosenLevel == 1)
            {
                Application.LoadLevel(1);
            }
            if (GlobalVariables.ChosenLevel == 2)
            {
                Application.LoadLevel(14);
            }
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && playerSprite.transform.rotation.y == 1)
        {
            playerSprite.transform.Rotate(Vector3.up*-180);
            airPanel.Bubbles.transform.Rotate(Vector3.up * -180);
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && playerSprite.transform.rotation.y == 0)
        {
            playerSprite.transform.Rotate(Vector3.up *180);
            airPanel.Bubbles.transform.Rotate(Vector3.up * 180);
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && playerFast.transform.rotation.y == 1)
        {
            playerFast.transform.Rotate(Vector3.up * -180);
            airPanel.Bubbles.transform.Rotate(Vector3.up * -180);
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && playerFast.transform.rotation.y == 0)
        {
            playerFast.transform.Rotate(Vector3.up * 180);
            airPanel.Bubbles.transform.Rotate(Vector3.up * 180);
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && playerSlow.transform.rotation.y == 1)
        {
            playerSlow.transform.Rotate(Vector3.up * -180);
            airPanel.Bubbles.transform.Rotate(Vector3.up * -180);
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && playerSlow.transform.rotation.y == 0)
        {
            playerSlow.transform.Rotate(Vector3.up * 180);
            airPanel.Bubbles.transform.Rotate(Vector3.up * 180);
        }


        //fire
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire && ammo > 0) {
            nextFire = Time.time + fireRate;
            fire();
            nextAttack = 0;
            ammo = ammo - 1;
            attackPanel.setAttack(ammo);
        }
        nextAttack += Time.deltaTime;
        //recharge attack
        if (nextAttack > recharge && ammo < PlayerPrefs.GetInt("Nattacks") && ammo != 0)
        {
            ammo = PlayerPrefs.GetInt("Nattacks");
            Debug.Log(ammo);
            attackPanel.setAttack(ammo);
            nextAttack = 0;
        }
        if (ammo == 0)
        {
            Debug.Log("ammo = 0");
            if (!timerReached) {
                timer += Time.deltaTime;
            }
            if (!timerReached && timer > recharge)
            {
                Debug.Log("Done waiting");
                ammo = PlayerPrefs.GetInt("Nattacks");
                attackPanel.setAttack(ammo);
                timerReached = false;
                timer = 0;
            }    
        }
        Debug.Log("ES MAS PEQUEE");
        //empty = GameObject.Find("empty");
        RectTransform rt = (RectTransform)empty.transform;
        float posx = rt.position.x;
        Debug.Log(posx);
        if (posx>600)
        {
            Debug.Log("ES MAS PEQUEE");
            //Proba();
        }
       
    }

    //bullet function
    void fire() {
        bulletPos = transform.position;
        bulletPos += new Vector2(0f, -1f);
        Instantiate(Bullet, bulletPos, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag.Equals("Enemy"))
        {
            if (choca == false)
            {
                if (lifesItem2 > 0)
                {
                    lifesItem2--;
                    bluelife.setHealth(lifesItem2);
                }
                else
                {
                    if (numberLifes > 2)
                    {
                        blood.SetActive(true);
                        StartCoroutine(playerBlink());
                        StartCoroutine(processTask());
                        imgItem2.SetActive(false);
                        numberLifes--;
                        checkGameOver();
                        lifePanel.setHealth(numberLifes);
                        Destroy(col.gameObject);
                    }
                    else
                    {
                        blood.SetActive(true);
                        
                        if (numberLifes == 1)
                        {
                          
                            blood2.SetActive(true);
                            
                        }
                        
                        StartCoroutine(playerBlink());
                        StartCoroutine(processTask2());
                        imgItem2.SetActive(false);
                        numberLifes--;
                        checkGameOver();
                        lifePanel.setHealth(numberLifes);
                        Destroy(col.gameObject);
                    }

                }
            }
            playClip();

        }

    }
    IEnumerator processTask()
    {
        choca = true;
       
        yield return new WaitForSeconds(2);
       

        blood.SetActive(false);
        //yield return new WaitForSeconds(1);
        choca = false;

    }
    IEnumerator processTask2()
    {
        choca = true;
        yield return new WaitForSeconds(2);
        
        choca = false;

    }
    public void Proba()
    {
        StartCoroutine(BlinkAir());

    }

    IEnumerator BlinkAir()
    {
        //airblink = GameObject.Find("bar");
        Debug.Log(airblink);
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("blink air");
           

            //color2 = airblink.GetComponent<Image>().material.color;
            color = color2;
            color.a = 0;
            airblink.SetActive(false);
            airblink2.SetActive(false);
            // airblink.GetComponent<Image>().material.color=color;
            yield return new WaitForSeconds(0.5f);
            Debug.Log("blink air 222222222");
            airblink.SetActive(true);
            airblink2.SetActive(true);
            color.a = 1;
            //airblink.GetComponent<Image>().material.color = color;
            yield return new WaitForSeconds(0.5f);
        }


    }

    IEnumerator playerBlink()
    {
        for (int i = 0; i < 10; i++)
        {
           
            switch (numPlayer)
            {
                case 1:
                    
                    playerSlow.SetActive(false);
                    playerFast.SetActive(false);
                    playerSprite.SetActive(false);
                    yield return new WaitForSeconds(0.1f);
                    playerSprite.SetActive(true);
                    yield return new WaitForSeconds(0.1f);

                    break;
                case 2:
                    playerSprite.SetActive(false);
                    playerFast.SetActive(false);
                    playerSlow.SetActive(false);
                    yield return new WaitForSeconds(0.1f);
                    playerSlow.SetActive(true);
                    yield return new WaitForSeconds(0.1f);
                    break;
                case 3:
                    playerSlow.SetActive(false);
                    playerSprite.SetActive(false);
                    playerFast.SetActive(false);
                    yield return new WaitForSeconds(0.1f);
                    playerFast.SetActive(true);
                    yield return new WaitForSeconds(0.1f);
                    break;
                
            }
        }
       
    }
    void OnCollisionEnter2D(Collision2D col1) {
        
        if (col1.gameObject.tag.Equals("wall"))
        {
            if (choca==false)
            {
                
                if (lifesItem2 > 0 && choca== false)
                {
                    
                    lifesItem2--;
                    StartCoroutine(processTask());
                    StartCoroutine(playerBlink());
                    bluelife.setHealth(lifesItem2);

                }
                else
                {
                    if (numberLifes > 2)
                    {
                        blood.SetActive(true);
                        StartCoroutine(playerBlink());
                        StartCoroutine(processTask());
                        imgItem2.SetActive(false);
                        numberLifes--;
                        checkGameOver();
                        lifePanel.setHealth(numberLifes);
                    }
                    else
                    {
                        blood.SetActive(true);
                        if (numberLifes == 1)
                        {
                            blood2.SetActive(true);
                        }
                        StartCoroutine(playerBlink());
                        StartCoroutine(processTask2());
                        imgItem2.SetActive(false);
                        numberLifes--;
                        checkGameOver();
                        lifePanel.setHealth(numberLifes);
                    }
                   

                }
                playClip();
            }
        }
            
            
            

        
        if (col1.gameObject.tag.Equals("Bubble"))
        {

            airPanel.plusAir(airBarEmpty);


        }
        if (col1.gameObject.tag.Equals("FinalWall"))
        {

            timerUI.stopTime();
            Debug.Log("You Win");
            CoinPanel.coinAmount += 5;
            if (GlobalVariables.ChosenLevel == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
            if (GlobalVariables.ChosenLevel == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 11);
            }

        }
    }

    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    void checkGameOver() {
        if (numberLifes <= 0 /*|| nAir <= 0*/) {
            Debug.Log("Game Over");
            timerUI.stopTime();
            if (GlobalVariables.ChosenLevel == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (GlobalVariables.ChosenLevel == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 12);
            }
        }

    }
}

