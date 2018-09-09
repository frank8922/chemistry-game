using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class QuizManager : MonoBehaviour
{

    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;

    [SerializeField]
    public Button TrueButton, FalseButton;


    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestions;

    [SerializeField]
    private Text trueAnswer;

    [SerializeField]
    private Text falseAnswer;

    [SerializeField]
    private Animator animator;

    public static int score = 0;
    public static int numWrong = 0;
    public SceneFader fader;
    public static int count = 0;

    [SerializeField] GameObject quizManager;

    private static int numberOfAttempts;

    private float timeThreshhold = 5.0f;

    private static Dictionary<string, int> dict = new Dictionary<string, int>();

    public string json;

    void Start()
    {
        timeThreshhold = 5.0f;

        if (count <= 0)
        {
            FindObjectOfType<AudioManager>().Play("masterylevelmusic");
        }
        count++;
        //score 15
        if (score >= 4)
        {
            if (SceneManager.GetActiveScene().name == "Level5")
            {
                if (PlayerPrefs.GetInt("levelReached") < 6)
                {
                    PlayerPrefs.SetInt("levelReached", 6);
                }
                score = 0;
                count = 0;
                numWrong = 0;
                FindObjectOfType<AudioManager>().Stop("masterylevelmusic");
                //dataBuilder(dict.Keys.ToList(),dict.Values.ToList());
                Debug.Log(dataBuilder(dict.Keys.ToList(), dict.Values.ToList()));
                postResponse("http://167.99.5.35/api/savedata", dataBuilder(dict.Keys.ToList(), dict.Values.ToList()), "0S1zkwI3pjSjdfGHLbj9FP5MfbC3", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("LevelSelect");
            }
            else if (SceneManager.GetActiveScene().name == "Level8")
            {
                if (PlayerPrefs.GetInt("levelReached") < 9)
                {
                    PlayerPrefs.SetInt("levelReached", 9);
                }
                score = 0;
                count = 0;
                numWrong = 0;
                FindObjectOfType<AudioManager>().Stop("masterylevelmusic");
                //dataBuilder(dict.Keys.ToList(),dict.Values.ToList());
                Debug.Log(dataBuilder(dict.Keys.ToList(), dict.Values.ToList()));
                postResponse("http://167.99.5.35/api/savedata", dataBuilder(dict.Keys.ToList(), dict.Values.ToList()), "0S1zkwI3pjSjdfGHLbj9FP5MfbC3", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("LevelSelect");
            }
        }

        if (numWrong >= 6)
        {
            if (SceneManager.GetActiveScene().name == "Level5")
            {
                score = 0;
                count = 0;
                numWrong = 0;
                FindObjectOfType<AudioManager>().Stop("masterylevelmusic");
                SceneManager.LoadScene("VideoAnimationLevel1234");
            }
            else if (SceneManager.GetActiveScene().name == "Level8")
            {
                score = 0;
                count = 0;
                numWrong = 0;
                FindObjectOfType<AudioManager>().Stop("masterylevelmusic");
                SceneManager.LoadScene("VideoAnimationLevel8");
            }

        }

        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();

    }

    void Update()
    {
        StartCoroutine(TimedThreshHold());
        if (timeThreshhold <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);

        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;


        //dict.Add(currentQuestion.fact,1);

        Debug.Log("Returns current question --> " + currentQuestion.fact);
        Debug.Log("true or false --> " + dict.ContainsKey(currentQuestion.fact));

        if (!dict.ContainsKey(currentQuestion.fact))
        {
            //dict[currentQuestion.fact] = 1;
            dict.Add(currentQuestion.fact, 1);

        }
        else
        {
            int value = dict[currentQuestion.fact];
            Debug.Log("The if statement runs");

            //dict.Add(currentQuestion.fact,dict[currentQuestion.fact]+1);

            dict[currentQuestion.fact] = value + 1; //Debug.Log("dict[currentQuestion.fact] --> " + dict[currentQuestion.fact]);
        }
        //dict["test"] += 2;


        dict.ToList().ForEach(x => Debug.Log(x.Key + " " + x.Value));





        if (currentQuestion.isTrue)
        {
            trueAnswer.text = "CORRECT!";
            trueAnswer.color = Color.green;
            falseAnswer.text = "INCORRECT!";
            falseAnswer.color = Color.red;

        }
        else
        {
            trueAnswer.text = "INCORRECT!";
            trueAnswer.color = Color.red;
            falseAnswer.text = "CORRECT!";
            falseAnswer.color = Color.green;
        }

    }
    IEnumerator TrasnsitionToNextQuestionTrue()
    {
        //unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestions);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator TrasnsitionToNextQuestionFalse()
    {
        yield return new WaitForSeconds(timeBetweenQuestions);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator TimedThreshHold()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeThreshhold);
            timeThreshhold--;
        }

    }


    /*
	if need multiple question make single method instead of two make what the user selected into an integer
	to determine validity possible 

	make a temp var to store previous question and check it against current question so questions dont repeat
	 */
    public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            FindObjectOfType<AudioManager>().Play("truenoise");
            score += 1;
            TrueButton.enabled = false;
            FalseButton.enabled = false;

        }
        else
        {
            FindObjectOfType<AudioManager>().Play("falsenoise");
            numWrong += 1;
            TrueButton.enabled = false;
            FalseButton.enabled = false;

        }
        timeThreshhold += 1.5f;
        StartCoroutine(TrasnsitionToNextQuestionTrue());
    }

    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        timeThreshhold = 5.0f;
        if (!currentQuestion.isTrue)
        {
            FindObjectOfType<AudioManager>().Play("truenoise");
            score += 1;
            TrueButton.enabled = false;
            FalseButton.enabled = false;
            
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("falsenoise");
            numWrong += 1;
            TrueButton.enabled = false;
            FalseButton.enabled = false;

        }
        timeThreshhold += 1.5f;
        StartCoroutine(TrasnsitionToNextQuestionFalse());
    }

    public string dataBuilder(List<string> keys, List<int> values)
    {
        string json = "{";

        for (int i = 0; i < keys.Count; i++)
        {
            if (i == keys.Count - 1)
            {
                json += "\"" + keys[i] + "\":" + values[i];

            }
            else
            {
                json += "\"" + keys[i] + "\":" + values[i] + ",";

            }
        }

        return json + "}";
    }

    public void getResponse(string uid)
    {
        string url = "http://167.99.5.35/api/info?uid=" + uid;
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
    }

    public void postResponse(string url, string data, string uid, string node)
    {
        //string url = "http://167.99.5.35:8080/API/save";
        //string data = "{\"name\":\"bob marley from unity test 2\"}";
        //string uid = "5XwCmxgUF3PY61vPclwcKoyiQJr1";

        StartCoroutine(PostRequest(url, data, uid, node));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
            json = www.text;
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    IEnumerator PostRequest(string url, string json, string uid, string node)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.SetRequestHeader("uid", uid);
        uwr.SetRequestHeader("node", node);


        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);

        }
    }

}
