using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance; //�@�V���O���g��

    public int score = 0;

    private void Awake()
    {
        //���ɃC���X�^���X���Ȃ������玩�����g��
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
        Debug.Log("�X�R�A�����I���̃X�R�A;" + score);
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
