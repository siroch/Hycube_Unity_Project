using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public int columns = 6;
    public int rows = 6;
    private int tileCount1 = StageManager.CallStage;

    private bool Difficulty = SceneChanger.Difficulty; // 난이도가 뭔지

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
        Debug.Log(Difficulty);
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

        for (int i = 0; i < tileCount1; )
        {
            Vector3 ranPos = RandomPosition();
            int x = (int)ranPos.x;
            int y = rows - (int)ranPos.y - 1;

            if(CheckBoard[y, x] == false)
            {
                CheckBoard[y, x] = true;

                GameObject toInstantiate = Resources.Load("Prefabs/Tile1") as GameObject;
                GameObject instance = Instantiate(toInstantiate, ranPos, Quaternion.identity) as GameObject;

                instance.transform.SetParent(TileHolder1);
                i++;
            }
        }
    }

    void FilltheTile2()
    {
        TileHolder2 = new GameObject("Tile2").transform;

        for (int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                if(CheckBoard[i, j] == false)
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
        FilltheTile2();
    }
}
