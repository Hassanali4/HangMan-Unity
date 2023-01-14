using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour
{
    //The text reference from canvas field to be changed and displayed dynamically on the screen
    public Text timeField;
    public Text wordToFindField;
    public GameObject[] hangMan;
    public GameObject winText;
    public GameObject loseText;
    //user input 
    public InputField userInput;
    public GameObject body;
    // To display What was the real answer
    public Text answer;
    public Text answer_statement;
    // To display How many trys did the user have performed
    public Text noOfTrys;
    //public Text noOfTrys_statement;
    private int trys;

    //Tries
    public Text Tries_Statement;
    public Text Tries;
    //To make a Tries List 
    public Transform secondTry;
    int _j = 0;// counter for inputs

    //To show input 
    public Text showGivenInput;
    public Text showGivenInputStatement;
    private AddObjectToList addscroll;

    //A float variable to get the change in time value
    //inside the engine by each frame and display on the screen
    private float time;
    private string chosenWord;
    private string hiddenWord;
    private int fails;
    private bool gameEnd = false;

    private string[] wordsLocal = {" MATT " , " JOANNE " , " ROBERT " , " MARRY JANE " , " DENIS "}; // Commented it out to use the file system to get names from a file inside assets folder
    //private string[] words = File.ReadAllLines(@"Assets/Files/Words.txt");

    private int[] myNums = { 3 , 5 , 7 , 8 };


    private void Awake()
    {
        addscroll = GetComponent<AddObjectToList>();

    }


    void Start()
    {
        //string myName = "HARRIS";
        //if (myName.Contains("SIR"))
        //{
        //    Debug.Log("HARRIS Contains the String.");
        //}else
        //{
        //    Debug.Log("HARRIS does not Contains the String.");
        //}

        // for ( int i = 0 ; i < words Local.Length ; i ++ )
        // {
        // Debug . Log ( words Local [ i ] ) ;
        // }
        // Debug . Log ( " Amount of items inside of wordsLocal is " + words Local.Length);                                                                    ) ;

        //chosenWord = wordsLocal[Random.Range(0, wordsLocal.Length)];// Commented it out to use the file system to get names from a file inside assets folder

        //sound = GetComponent<SoundManagerScript>();
        //triesCheck = showGivenInput.text;
        chosenWord = wordsLocal[Random.Range(0, wordsLocal.Length)];
        answer.text = chosenWord;
        //chosenWord = "MATT";
        int newVal = chosenWord.IndexOf("H");
        Debug.Log(newVal);
        for(int i = 0;i<chosenWord.Length;i++)
        {
            char letter = chosenWord[i];
            //Debug.Log("This is"+i+ "th character " + chosenWord[i]);
            if(char.IsWhiteSpace(letter))
            {
                hiddenWord += " ";

            }else
            {
                hiddenWord += "_";
            }
        }
        //Debug.Log( letter);
        //wordFindField.text = chosenWord;
        //Debug.Log(chosenWord);

        wordToFindField.text = hiddenWord;
    }

    // Update is called once per frame
    void Update()
    {
        
        showGivenInput.text = userInput.text.ToString();
        if (showGivenInput.text == string.Empty)
            showGivenInputStatement.gameObject.SetActive(false);
        else if (showGivenInput.text != string.Empty)
            showGivenInputStatement.gameObject.SetActive(true);
        //Show_Input_Given.text = userInput.placeholder.ToString(); 
        if (gameEnd == false)
        {
            time += Time.deltaTime;
            timeField.text = time.ToString();
        }

    }

    public void Check()
    {
        //Event e = Event.current;

        //if(e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1)
        if(userInput.text.ToString().Length == 1)
        {
            //string pressedLetter = e.keyCode.ToString();
            string pressedLetter = userInput.text.ToString();
            //_j++;
            
            //Showing Last Try of User Logic (The First Last attempt of user)
            Tries.text = pressedLetter;
            if (Tries.text != string.Empty)
                Tries_Statement.gameObject.SetActive(true);
            addscroll.AddButton_Click();
            //Getting the 2nd Output Try Fields Privatly
            //secondTry.Find("No_Of_Inputs_Provided_StatementText").GetComponent<Text>().text = "1";
            //secondTry.Find("No_Of_Inputs_Provided").GetComponent<Text>().text = "2";
            
            Debug.Log("KeyDown event was triggered " + pressedLetter);
            //check if pressed letter is contained in chosen word
            if(chosenWord.Contains(pressedLetter))
            {
                // hiddenword = _ _ _ _ _      D // DENIS
                // chosenword = D E N I S
                // DENIS
                int i = chosenWord.IndexOf(pressedLetter);
                while (i != -1)
                {
                    //Set new hidden word to everything before the i,
                    //change the i to the letter pressed, everything after the i
                    hiddenWord = hiddenWord.Substring(0, i) + pressedLetter + hiddenWord.Substring(i + 1);
                    Debug.Log(hiddenWord);

                    chosenWord = chosenWord.Substring(0, i) + "_" + chosenWord.Substring(i + 1);
                    Debug.Log(chosenWord);

                    i = chosenWord.IndexOf(pressedLetter);
                }

                wordToFindField.text = hiddenWord;

            }
            else
            {
                hangMan[fails].SetActive(true);
                fails++;
                int count = 6 - fails;
                noOfTrys.text = count.ToString();

            }
            //case Lost Game
            if (fails == hangMan.Length)
            {
                body.GetComponent<Rigidbody>().AddForce(11000f,0f,0f);
                loseText.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Diying_Sound");
                gameEnd = true;
                FindObjectOfType<AudioManager>().Play("Lose");
                answer.gameObject.SetActive(true);
                answer_statement.gameObject.SetActive(true);
            }
            //case Win Game
            //if(fails < hangMan.Length)
            if (!hiddenWord.Contains("_"))
            {
                winText.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Win");
                gameEnd = true;
                answer.gameObject.SetActive(true);
                answer_statement.gameObject.SetActive(true);
            }
        } // Event Input Checking if from keyboard
    } // On GUI
}
