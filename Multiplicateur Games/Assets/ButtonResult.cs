using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonResult : MonoBehaviour
{

    [SerializeField] Button[] buttons;
    public Multiplicator Multiplicator;
     [SerializeField] int randomSelect;
    [SerializeField] int badAnswerRandom;
    [SerializeField] TextMeshProUGUI text;

    private void Awake()
    {
        StartGame();
      
    }

    private void Update()
    {
       
        buttons[randomSelect].GetComponentInChildren<TextMeshProUGUI>().text = Multiplicator.result.ToString();
        for(int i = 0; i < buttons.Length; i++)
        {
            if (randomSelect != i)
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = badAnswerRandom.ToString();

          
           
        }
      



    }

    public void StartGame()
    {
        randomSelect = Random.Range(0, buttons.Length);
        badAnswerRandom = Random.Range(1, 101);
        Multiplicator.ChangeFactors();
        text.text = "Combien font " + Multiplicator.facterA + " x " + Multiplicator.facterB + " ?";
    }

    public IEnumerator randomChoiceSelected()
    {
        yield return new WaitForSeconds(0.5f);
        randomSelect = Random.Range(0, buttons.Length);
        badAnswerRandom = Random.Range(1, 101);
        Multiplicator.ChangeFactors();
        text.text = "Combien font " + Multiplicator.facterA + " x " + Multiplicator.facterB + " ?";
        Multiplicator.previousResult.Add(Multiplicator.result);
        for (int i = 0; i < buttons.Length; i++)
        {
           
                buttons[i].GetComponentInChildren<Image>().color = Color.white;



        }

      
    }


   

    public void wknowtheAnswerin1()
    {
        if (buttons[0].GetComponentInChildren<TextMeshProUGUI>().text == Multiplicator.result.ToString())
        {
            var buttonColors = buttons[0].GetComponent<Image>().color;
            buttonColors = Color.green;
            buttons[0].GetComponent<Image>().color = buttonColors;
            Win();
        }
        else
        {


            lose();
        }
    }
    public void wknowtheAnswerin2()
    {
        if (buttons[1].GetComponentInChildren<TextMeshProUGUI>().text == Multiplicator.result.ToString())
        {
           
            Win();
            var buttonColors = buttons[1].GetComponent<Image>().color;
            buttonColors = Color.green;
            buttons[1].GetComponent<Image>().color = buttonColors;
        }
        else
        {
            lose();

        }
    }
    public void Win()
    {
        text.text = "Bonne reponse";
        StartCoroutine(randomChoiceSelected());
    }
    public void lose( )
    {
        text.text = "Mauvaise reponse";
        StartCoroutine(randomChoiceSelected());
        Debug.Log("ta rater");
    }
}
