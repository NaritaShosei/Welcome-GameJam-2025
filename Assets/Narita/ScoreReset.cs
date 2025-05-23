using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReset : MonoBehaviour
{
    public void GetScoreReset()
    {
        ScoreManager.Instance.ScoreReset();
    }
}
