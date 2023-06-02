using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public void Win()
    {
        int ThisScene = Application.loadedLevel;
        Application.LoadLevel(ThisScene);
    }
}
