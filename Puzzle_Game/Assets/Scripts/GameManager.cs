using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BoardManager BoardScript;

    public static bool[,] CheckBoard = new bool[6, 6];
    public static bool[,] OnlyResetBoard = new bool[6, 6];

    private GameObject target;      // 클릭한 타일
    private GameObject DirTarget;   // 클릭한 타일에서 상, 하, 좌, 우의 타일

    void Awake() // awake를 먼저 해야 타일이 배치됨, 한번밖에 실행 안됨
    {
        BoardScript = GetComponent<BoardManager>();
        target = GetComponent<GameObject>();

        InitGame();
        MakeTileArray();
    }

    void MakeTileArray()
    {
        GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Tile");
        
        foreach(GameObject t in Tiles)
        {
            Vector3 pos = t.transform.position;

            int x = (int)pos.x;
            int y = 5 - (int)pos.y;

            if(t.name.Equals("Tile1(Clone)"))
            {
                CheckBoard[y, x] = true;
                OnlyResetBoard[y, x] = true;
            }
            else if (t.name.Equals("Tile2(Clone)"))
            {
                CheckBoard[y, x] = false;
                OnlyResetBoard[y, x] = false;
            }
        }
    }

    void InitGame()
    {
        BoardScript.SetupScene();
    }

    void Update() // 매 프레임마다 화면의 상태를 업데이트 해줌
    {
        GetClickedObj();
        AllCheckTile();
    }

    private void GetClickedObj() // 클릭해서 타일을 바꾸는 함수
    {
        if(Input.GetMouseButtonDown(0))
        {
            target = null;

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(pos, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                target = hit.collider.gameObject;
                Vector3 targetPos = target.transform.position;

                ChangeTile(targetPos, target);
                GetDirTile(targetPos);
            }
        }
    }

    void ChangeTile(Vector3 tPos, GameObject SelectedTile) // 인자는 클릭된 타일의 좌표, 클릭된 타일
    {
        int x = (int)tPos.x;
        int y = 6 - (int)tPos.y - 1;

        if (SelectedTile.name.Equals("Tile1(Clone)"))
        {
            Transform TileHolder2 = BoardManager.TileHolder2;
            GameObject toInstantiate = Resources.Load("Prefabs/Tile2") as GameObject;

            GameObject instance = Instantiate(toInstantiate, tPos, Quaternion.identity) as GameObject;

            CheckBoard[y, x] = false;

            instance.transform.SetParent(TileHolder2);
        }
        else if(SelectedTile.name.Equals("Tile2(Clone)"))
        {
            Transform TileHolder1 = BoardManager.TileHolder1;
            GameObject toInstantiate = Resources.Load("Prefabs/Tile1") as GameObject;

            GameObject instance = Instantiate(toInstantiate, tPos, Quaternion.identity) as GameObject;

            CheckBoard[y, x] = true;

            instance.transform.SetParent(TileHolder1);
        }
        Destroy(SelectedTile);
    }

    void GetDirTile(Vector3 tPos) // 인자는 클릭된 타일의 좌표, 얘는 상, 하, 좌, 우의 타일들의 정보를 가져오는 함수
    {
        int[,] dir = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
        bool onSelect = false;

        for(int i=0; i<4; i++)
        {
            Vector3 nPos = new Vector3(tPos.x + dir[i, 0], tPos.y + dir[i, 1], 0f);
            GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Tile");

            if((-0.5 <= nPos.x && nPos.x <= 6.5) && (-0.5 <= nPos.y && nPos.y <= 6.5))
            {
                foreach(GameObject t in Tiles)
                {
                    Vector3 stPos = t.transform.position;
                    if((stPos.x - 0.5 <= nPos.x && nPos.x <= stPos.x + 0.5) &&
                        (stPos.y - 0.5 <= nPos.y && nPos.y <= stPos.y + 0.5))
                    {
                        DirTarget = t;
                        onSelect = true;
                    }
                }
            }

            if(onSelect)
            {
                ChangeTile(DirTarget.transform.position, DirTarget);
                onSelect = false;
            }
        }
    }

    void AllCheckTile() // 게임을 끝낼만한 조건을 갖췄는지
    {
        bool Done = true;
        bool first = CheckBoard[0, 0];

        for(int i=0; i<6; i++)
        {
            for(int j=0; j<6; j++)
            {
                if(first != CheckBoard[i, j])
                {
                    Done = false;
                    break;
                }
            }
            if(!Done)
            {
                break;
            }
        }

        if(Done)
        {
            Debug.Log("Finished Game!!!");
            SceneManager.LoadScene("End");
        }
    }

    public void BoardReset() // reset버튼을 눌렀을때 보드가 처음 상태로 돌아감
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        foreach (GameObject t in tiles)
        {
            Vector3 pos = t.transform.position;

            int x = (int)pos.x;
            int y = 6 - (int)pos.y - 1;

            CheckBoard[y, x] = OnlyResetBoard[y, x];

            if (OnlyResetBoard[y, x] == true)
            {
                Transform TileHolder1 = BoardManager.TileHolder1;
                GameObject toInstantiate = Resources.Load("Prefabs/Tile1") as GameObject;

                GameObject instance = Instantiate(toInstantiate, pos, Quaternion.identity) as GameObject;

                instance.transform.SetParent(TileHolder1);
            }
            else
            {
                Transform TileHolder2 = BoardManager.TileHolder2;
                GameObject toInstantiate = Resources.Load("Prefabs/Tile2") as GameObject;

                GameObject instance = Instantiate(toInstantiate, pos, Quaternion.identity) as GameObject;

                instance.transform.SetParent(TileHolder2);
            }

            Destroy(t);
        }
    }
}