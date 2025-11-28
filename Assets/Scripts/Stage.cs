using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Level
{
    [Range(1,11)]
    public int partCount = 1;

    [Range(0,11)]
    public int deathPartCount = 1;
}


[CreateAssetMenu(fileName = "New Stage")]
public class Stage : ScriptableObject
{
    public Color stagebackgroundColor = Color.white;
    public Color stagelevelPartColor = Color.white;
    public Color stageBallColor = Color.white;
    
    public List<Level> levels = new List<Level>();

}
