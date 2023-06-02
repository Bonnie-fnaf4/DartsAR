using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StrikeConroller : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerEnterHandler
{
    public GameObject Strike, StrikeSpawn;
    public float forseToStrike = 1;

    public Slider sliderForse;
    public float MaxForse = 1.3f, directionRawFloat, directionRawFloatMax = 100;

    public Vector3 origin, directionRaw;

    public Text Score;
    public int ScoreInt = 0;
    public GameObject WinPanel;

    public bool Ar = true;

    void Start()
    {
        Application.targetFrameRate = 120;
        Time.timeScale = 2;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            forseToStrike = 1;
            GameObject StrikeNew = Instantiate(Strike);
            Strike strike = StrikeNew.GetComponent<Strike>();
            strike.StartStrike(forseToStrike);
        }
        Score.text = "" + ScoreInt;
        if(ScoreInt >= 15)
        {
            WinPanel.SetActive(true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        forseToStrike = 1;
        sliderForse.value = sliderForse.value;

        origin = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 currentPosition = eventData.position;
        directionRaw = currentPosition - origin;

        directionRawFloat = directionRaw.x / directionRawFloatMax;

        //if (forseToStrike <= MaxForse || forseToStrike >= 1) 
            forseToStrike = directionRawFloat + 1;
            //forseToStrike += Time.deltaTime;
        if (forseToStrike > MaxForse) forseToStrike = MaxForse;
        if ( forseToStrike < 1) forseToStrike = 1;
        sliderForse.value = forseToStrike;
        //forseToStrike += Time.deltaTime;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //forseToStrike += Time.deltaTime;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject StrikeNew;
        if (Ar) StrikeNew = Instantiate(Strike, StrikeSpawn.transform);
        else StrikeNew = Instantiate(Strike);
        Strike strike = StrikeNew.GetComponent<Strike>();
        strike.strikeConroller = this;
        strike.StartStrike(forseToStrike);
        sliderForse.value = 1;
    }
}
