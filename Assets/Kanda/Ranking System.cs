using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{

    // [SerializeField]RankingManager
    public static List<int> ranking = new List<int> { 0, 0, 0, 0, 0 };

    public const int maxRank = 5;

    [SerializeField] Text[] _texts;
    private void Start()
    {
        ranking.Sort();
        ranking.Reverse();

        for (int i = 0; i < _texts.Length; i++)
        {
            _texts[i].text = $"{i + 1}.{ranking[i]:000000}";
        }
    }
}
