using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoardManager BoardScript;
    public bool[,] CheckBoard;

    private GameObject target;      // 클릭한 타일
    private GameObject DirTarget;   // 클릭한 타일에서 상, 하, 좌, 우의 타일

    void Awake() // awake를 먼저 해야 타일이 배치됨, 한번밖에 실행 안됨
    {
        BoardScript = GetComponent<BoardManager>();
        target = GetComponent<GameObject>();
        CheckBoard = BoardScript.CheckBoard;
        InitGame();
    }

    void InitGame()
    {
        BoardScript.SetupScene();
    }

    void Update() // 매 프레임마다 화면의 상태를 업데이트 해줌
    {
        GetClickedObj();
    }

    private void GetClickedObj()
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

                ChangeTile(targetPos);
            }
        }
    }

    void ChangeTile(Vector3 tPos)
    {
        if (target.name.Equals("Tile1(Clone)"))
        {
            Transform TileHolder2 = BoardScript.TileHolder2;
            GameObject toInstantiate = Resources.Load("Prefabs/Tile2") as GameObject;

            GameObject instance = Instantiate(toInstantiate, tPos, Quaternion.identity) as GameObject;

            instance.transform.SetParent(TileHolder2);
        }
        else if(target.name.Equals("Tile2(Clone)"))
        {
            Transform TileHolder1 = BoardScript.TileHolder1;
            GameObject toInstantiate = Resources.Load("Prefabs/Tile1") as GameObject;

            GameObject instance = Instantiate(toInstantiate, tPos, Quaternion.identity) as GameObject;

            instance.transform.SetParent(TileHolder1);
        }
        Destroy(target);
    }

    void GetDirTile(Vector3 tPos)
    {

        int[,] dir = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };

        for(int i=0; i<4; i++)
        {
            Vector3 nPos = new Vector3(tPos.x + dir[i, 0], tPos.y + dir[i, 1], 0f);

            if((-0.5 <= nPos.x && nPos.x <= 6.5) && (-0.5 <= nPos.y && nPos.y <= 6.5))
            {

            }
        }
    }
}
