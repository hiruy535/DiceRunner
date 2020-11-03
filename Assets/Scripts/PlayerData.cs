using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int scores;


    public PlayerData(collision col)
    {
        scores = col.scores;  
    }
}
