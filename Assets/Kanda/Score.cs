using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance; //　シングルトン

    public int score = 0;

    private void Awake()
    {
        //他にインスタンスがなかったら自分を使う
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("スコア増加！今のスコア;" + score);
    }

    public void ScoreReset()
    {
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
