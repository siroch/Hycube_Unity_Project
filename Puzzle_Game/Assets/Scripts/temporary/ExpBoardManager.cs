using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBoardManager : MonoBehaviour
{
    public int columns = 6;
    public int rows = 6;
    public int tileCount1 = 18;
    public int tileCount2 = 18;

    public static Transform TileHolder1;
    public static Transform TileHolder2;
    private List<Vector3> gridPos = new List<Vector3>();

    // tile1은 true, tile2는 false
    public bool[,] CheckBoard = new bool[6, 6] { { false, false, false, false, false, false },
                                                 { false, false, false, false, false, false },
                                                 { false, false, false, false, false, false },
                                                 { false, false, false, false, false, false },
                                                 { false, false, false, false, false, false },
                                                 { false, false, false, false, false, false } };

    void InitializeList() // gridPos를 비워놓기 위한 함수, 리스트 초기화
    {
        gridPos.Clear();

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                gridPos.Add(new Vector3(i, j, 0f));
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIdx = Random.Range(0, gridPos.Count);
        Vector3 randomPos = gridPos[randomIdx];
        return randomPos;
    }

    void FilltheTile1() // tile1을 board에 채워주는 함수
    {
        TileHolder1 = new GameObject("Tile1").transform;

        Vector3 mainPos = new Vector3(2, 2, 0f);
        int[,] Dir = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };

        int xx = 2;
        int yy = 6 - 2 - 1;

        GameObject ins = Resources.Load("Prefabs/Tile1") as GameObject;
        GameObject instance = Instantiate(ins, mainPos, Quaternion.identity) as GameObject;

        instance.transform.SetParent(TileHolder1);
        CheckBoard[yy, xx] = true;

        for (int i = 0; i < tileCount1; i++)
        {
            int x = (int)mainPos.x + Dir[i, 0];
            int y = (int)mainPos.y + Dir[i, 1];
            Vector3 npos = new Vector3(x, y, 0f);

            xx = x;
            yy = 6 - y - 1;
            CheckBoard[yy, xx] = true;

            instance = Instantiate(ins, npos, Quaternion.identity) as GameObject;

            instance.transform.SetParent(TileHolder1);
        }
    }

    void FilltheTile2(int level)
    {
        TileHolder2 = new GameObject("Tile2").transform;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                if (CheckBoard[i, j] == false)
                {
                    int x = j;
                    int y = rows - i - 1;

                    GameObject toInstantiate = Resources.Load("Prefabs/Tile2") as GameObject;
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                    instance.transform.SetParent(TileHolder2);
                }
            }
        }
    }

    public void SetupScene()
    {
        InitializeList();
        FilltheTile1();
        FilltheTile2(tileCount2);
    }
}
