using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    public GameObject platform;	//발판
    private int cnt = 0;	// 생성할 오브젝트의 y좌표를 설정하기 위한 수
    private int x = 0;	// 생성할 오브젝트의 x좌표를 설정하기 위한 수

// 게임 시작시 맵 생성
	void Start () {
        CreateMap();
	}
	
	//맵 생성을 위한 코드
    public void CreateMap()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject gobj = Instantiate(platform);
			// Random 객체를 이용해서 랜덤으로 x좌표를 증가하거나 감소한다.
            if (Random.Range(0, 2) == 0) x++;
            else x--;
            gobj.transform.position = new Vector3(x,(++cnt),0);
			//생성된 오브젝트를 구별하기 위해 cnt의 값을 넣어줌.
            gobj.name = cnt.ToString();
        }
    }
}
