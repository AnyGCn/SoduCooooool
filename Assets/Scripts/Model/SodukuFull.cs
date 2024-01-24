using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodukuFull
{
    public readonly int[,] soduku = new int[9, 9];
    
    public SodukuFull()
    {
        for (int i = 0; i < 9; i++)
        {
            int[] temp = new int[9];
            for (int j = 0; j < 9; j++)
            {
                temp[j] = j + 1;
            }
            for (int j = 0; j < 9; j++)
            {
                int index = Random.Range(0, 9 - j);
                soduku[i, j] = temp[index];
                temp[index] = temp[8 - j];
            }
        }
    }
}
