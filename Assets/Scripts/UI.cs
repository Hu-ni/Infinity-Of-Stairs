using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Slider hp;
    public Text score;
    private float damage = 0.01f;
    private float time = 0.0f;

	public bool DecreaseHp () {
        if (hp.value <= 0) return false; 
        if((time+=Time.deltaTime) > 1 && damage < 20.0f)
        {
            time = 0.0f;
            damage += 0.01f;
        }
        hp.value -= damage;
        return true;
	}

    public void IncreaseHP()
    {
        hp.value += 20.0f;
    }

    public void UpdateScore(int score)
    {
        this.score.text = score.ToString();
    }
}
