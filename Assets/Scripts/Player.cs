using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	//현제 게임이 진행되고 있는 상태를 정의
    public enum State
    {
        Over, Ready, Play
    }

    public Map map;
    public State state;

    private UI ui;
    private Animator myAnim;
    private int height = 0;

	void Start () {
        map = GameObject.FindGameObjectWithTag("map").GetComponent<Map>();
        ui = GameObject.Find("GameManager").GetComponent<UI>();
        myAnim = GetComponent<Animator>();
        state = State.Ready;
	}
	
	void Update () {
        if (state == State.Over)
        {
            if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene("SampleScene");
            return;
        }
        else if (state == State.Play) ui.DecreaseHp();
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (state == State.Ready) state = State.Play;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            Move();
        }
    }

    private void Move()
    {
        myAnim.SetTrigger("JUMP");
        transform.Translate(new Vector3(1, 1, 0));
        if (transform.position.y % 10 == 0) map.CreateMap();
		// 현재 이동한 위치가 올바른 위치에 이동했는지 검사하기 위한 조건문
        if (transform.localPosition.x != GameObject.Find((++height).ToString()).transform.localPosition.x)
        {
            state = State.Over;
            myAnim.SetTrigger("DEAD");
        }
        ui.UpdateScore(height);
        ui.IncreaseHP();
    }
}
