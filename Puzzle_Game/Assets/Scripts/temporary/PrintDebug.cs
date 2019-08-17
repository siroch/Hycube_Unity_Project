using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintDebug : MonoBehaviour
{
    public BoardManager BoardScript;
    public bool[,] CheckBoard;
    public int Count = 1;

    public void PrintBoard()
    {
        Debug.Log(Count + " ---------------------------------------");
        Count++;
        for(int i=5; i>=0; i--)
        {
            for(int j=0; j<6; j++)
            {
                Debug.Log(i + " " + j + " " + CheckBoard[i, j]);
            }
        }
    }
}
