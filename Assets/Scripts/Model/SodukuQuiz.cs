using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodukuQuiz
{
    public SodukuFull Full;
    
    public readonly int[,] soduku = new int[9, 9];
    
    public SodukuQuiz()
    {
        Full = new SodukuFull();
    }
}
