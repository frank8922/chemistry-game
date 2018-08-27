using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 originalPosition;
    public bool col, cond;

    public Transform originalParent, copyOfOtherParent;
    public Vector3 otherPosition;

    public Transform DropPanel;
    public Transform DragPanel;

    [SerializeField]
    private Text questionText;
    [SerializeField]
    private string[] questionArray;

    [SerializeField]
    private GameObject[] slotArray;
    [SerializeField]
    private Sprite[] spriteArray;

    private static int count = 0;

    void Awake()
    {
        Application.targetFrameRate = 60;

    }
    //TODO RESTRUCTURE CODE FOR DECIDING OUTCOMES OF MATCHES
    void Start()
    {
        Physics2D.gravity = new Vector2(0, 0);
        originalParent = transform.parent;
        Physics2D.IgnoreLayerCollision(10, 10);
        rb = GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().name == "Level6a" || SceneManager.GetActiveScene().name == "Level7" || SceneManager.GetActiveScene().name == "Level9")
        {
            for (int i = 0; i < DragPanel.childCount; i++)
            {
                DragPanel.GetChild(i).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
            }
        }

        if (count < 1)
        {
            FindObjectOfType<AudioManager>().Play("quizgamenoise");
        }



        if (count == 1 && SceneManager.GetActiveScene().name == "Level6a")
        {
            //questionText.text = "Drag all the +2 ions above.";
            questionText.text = questionArray[1];
            DropPanel.GetChild(0).tag = "+2";
            DropPanel.GetChild(1).tag = "+2";
            DropPanel.GetChild(2).tag = "+2";
            DropPanel.GetChild(3).tag = "+2";
            DropPanel.GetChild(4).tag = "+2";
        }
        else if (SceneManager.GetActiveScene().name == "Level7")
        {
            if (count == 0)
            {
                questionText.text = questionArray[0];
            }
            else if (count == 1)
            {
                questionText.text = questionArray[1];
            }
            else if (count == 2)
            {
                questionText.text = questionArray[2];
            }


            if (questionText.text.ToString().ToLower() == questionArray[0].ToString().ToLower())
            {
                //this is the -1 question
                slotArray[0].SetActive(false);
                slotArray[1].SetActive(true);
                slotArray[2].SetActive(true);
                slotArray[3].SetActive(true);
                slotArray[4].SetActive(true);
                DropPanel.GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.MiddleCenter;
                DropPanel.GetChild(1).tag = "-1";
                DropPanel.GetChild(2).tag = "-1";
                DropPanel.GetChild(3).tag = "-1";
                DropPanel.GetChild(4).tag = "-1";
            }
            else if (questionText.text.ToString().ToLower() == questionArray[1].ToString().ToLower())
            {
                //this is the -2 question
                slotArray[0].SetActive(false);
                slotArray[1].SetActive(false);
                slotArray[2].SetActive(true);
                slotArray[3].SetActive(true);
                slotArray[4].SetActive(true);
                DropPanel.GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.MiddleCenter;
                DropPanel.GetChild(2).tag = "-2";
                DropPanel.GetChild(3).tag = "-2";
                DropPanel.GetChild(4).tag = "-2";
            }
            else if (questionText.text.ToString().ToLower() == questionArray[2].ToString().ToLower())
            {
                //this is the -3 question
                slotArray[0].SetActive(false);
                slotArray[1].SetActive(false);
                slotArray[2].SetActive(false);
                slotArray[3].SetActive(true);
                slotArray[4].SetActive(true);
                DropPanel.GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.MiddleCenter;
                DropPanel.GetChild(3).tag = "-3";
                DropPanel.GetChild(4).tag = "-3";
            }


        }
        else if (SceneManager.GetActiveScene().name == "Level9")
        {
            questionText.text = questionArray[0];
            if (count == 0)
            {
                slotArray[0].SetActive(true);
                slotArray[1].SetActive(true);
                slotArray[2].SetActive(true);
                slotArray[3].SetActive(true);
                slotArray[4].SetActive(true);
                DropPanel.GetChild(0).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
                DropPanel.GetChild(1).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
                DropPanel.GetChild(2).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
                DropPanel.GetChild(3).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
                DropPanel.GetChild(4).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
                DropPanel.GetChild(0).tag = DropPanel.GetChild(0).GetComponent<Image>().sprite.name;
                DropPanel.GetChild(1).tag = DropPanel.GetChild(1).GetComponent<Image>().sprite.name;
                DropPanel.GetChild(2).tag = DropPanel.GetChild(2).GetComponent<Image>().sprite.name;
                DropPanel.GetChild(3).tag = DropPanel.GetChild(3).GetComponent<Image>().sprite.name;
                DropPanel.GetChild(4).tag = DropPanel.GetChild(4).GetComponent<Image>().sprite.name;
            }
            else
            {
                slotArray[0].SetActive(true);
                slotArray[1].SetActive(true);
                slotArray[2].SetActive(true);
                slotArray[3].SetActive(true);
                slotArray[4].SetActive(true);
                DropPanel.GetChild(0).GetComponent<Image>().sprite = spriteArray[0];
                DropPanel.GetChild(1).GetComponent<Image>().sprite = spriteArray[1];
                DropPanel.GetChild(2).GetComponent<Image>().sprite = spriteArray[2];
                DropPanel.GetChild(3).GetComponent<Image>().sprite = spriteArray[3];
                DropPanel.GetChild(4).GetComponent<Image>().sprite = spriteArray[4];
                DropPanel.GetChild(0).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
                DropPanel.GetChild(1).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
                DropPanel.GetChild(2).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
                DropPanel.GetChild(3).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
                DropPanel.GetChild(4).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
                DropPanel.GetChild(0).tag = DropPanel.GetChild(0).GetComponent<Image>().sprite.name;
                DropPanel.GetChild(1).tag = DropPanel.GetChild(1).GetComponent<Image>().sprite.name;
                DropPanel.GetChild(2).tag = DropPanel.GetChild(2).GetComponent<Image>().sprite.name;
                DropPanel.GetChild(3).tag = DropPanel.GetChild(3).GetComponent<Image>().sprite.name;
                DropPanel.GetChild(4).tag = DropPanel.GetChild(4).GetComponent<Image>().sprite.name;
            }
        }
    }

    void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen)));
    }

    void OnMouseUp()
    {
        originalPosition = transform.position;
        if (col)
        {
            transform.position = new Vector3(otherPosition.x, otherPosition.y, otherPosition.z);
            transform.parent = copyOfOtherParent.transform;
            if (gameObject.transform.parent.childCount > 1)
            {
                gameObject.transform.parent.GetChild(1).transform.position = originalPosition;
                gameObject.transform.parent.GetChild(1).transform.parent = originalParent;
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("truenoise");
                if (DropPanel.GetChild(0).childCount == 1 && DropPanel.GetChild(1).childCount == 1 && DropPanel.GetChild(2).childCount == 1 && DropPanel.GetChild(3).childCount == 1 && DropPanel.GetChild(4).childCount == 1 && SceneManager.GetActiveScene().name.ToLower() == "level6a")
                {
                    count++;
                    Scene activeScene = SceneManager.GetActiveScene();
                    if (activeScene.name.ToLower() == "level6a" && count == 1)
                    {
                        SceneManager.LoadScene("Level6a");
                    }
                    else if (activeScene.name.ToLower() == "level6a" && count == 2)
                    {
                        //unlock level 7
                        //goto the level selector
                        if (PlayerPrefs.GetInt("levelReached") < 7 && SceneManager.GetActiveScene().name.ToLower() == "level6a")
                        {
                            PlayerPrefs.SetInt("levelReached", 7);
                        }
                        count = 0;
                        FindObjectOfType<AudioManager>().Stop("quizgamenoise");
                        SceneManager.LoadScene("LevelSelect");


                    }
                }
                else if (DropPanel.GetChild(1).childCount == 1 && DropPanel.GetChild(2).childCount == 1 && DropPanel.GetChild(3).childCount == 1 && DropPanel.GetChild(4).childCount == 1 && questionText.text.ToString().ToLower() == questionArray[0].ToLower() && SceneManager.GetActiveScene().name == "Level7")
                    {
                        //they completed the -1 question
                        count++;
                        SceneManager.LoadScene("Level7");
                    }
                    else if (DropPanel.GetChild(2).childCount == 1 && DropPanel.GetChild(3).childCount == 1 && DropPanel.GetChild(4).childCount == 1 && questionText.text.ToString().ToLower() == questionArray[1].ToLower() && SceneManager.GetActiveScene().name == "Level7")
                    {
                        //they completed the -2 question
                        count++;
                        SceneManager.LoadScene("Level7");
                    }
                    else if (DropPanel.GetChild(3).childCount == 1 && DropPanel.GetChild(4).childCount == 1 && questionText.text.ToString().ToLower() == questionArray[2].ToLower() && SceneManager.GetActiveScene().name == "Level7")
                    {
                        //they complete the -3 question
                        count++;
                        SceneManager.LoadScene("Level7");
                    }

                    if (count == 3 && SceneManager.GetActiveScene().name == "Level7")
                    {
                        if (PlayerPrefs.GetInt("levelReached") < 8)
                        {
                            PlayerPrefs.SetInt("levelReached", 8);
                        }
                        count = 0;
                        FindObjectOfType<AudioManager>().Stop("quizgamenoise");
                        SceneManager.LoadScene("LevelSelect");

                    }
                
                
               if (DropPanel.GetChild(0).childCount == 1 && DropPanel.GetChild(1).childCount == 1 && DropPanel.GetChild(2).childCount == 1 && DropPanel.GetChild(3).childCount == 1 && DropPanel.GetChild(4).childCount == 1 && SceneManager.GetActiveScene().name == "Level9")
                {
                    Debug.Log("The scene should reload");
                    if (count == 0 && SceneManager.GetActiveScene().name == "Level9")
                    {
                        SceneManager.LoadScene("Level9");
                    }
                    else
                    {
                        if (PlayerPrefs.GetInt("levelReached") < 10)
                        {
                            PlayerPrefs.SetInt("levelReached", 10);
                        }
                        count = 0;
                        FindObjectOfType<AudioManager>().Stop("quizgamenoise");
                        SceneManager.LoadScene("LevelSelect");
                    }
                }


            }

        }
        else
        {
            if (cond)
            {
                FindObjectOfType<AudioManager>().Play("falsenoise");
                cond = false;
            }

            transform.position = originalParent.position;
            transform.parent = originalParent;

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(gameObject.name + " has collided with " + other.name);

        if (other.tag == gameObject.tag)
        {
            Debug.Log("The object should snap into the slot");
            col = true;
            otherPosition = other.transform.position;
            copyOfOtherParent = other.transform;
            if (gameObject.transform.position == other.transform.position)
            {
                other.enabled = false;
            }
        }
        else
        {

            Handheld.Vibrate();
            col = false;
            other.enabled = true;
            cond = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("OnTriggerExit");
        col = false;
    }
}
