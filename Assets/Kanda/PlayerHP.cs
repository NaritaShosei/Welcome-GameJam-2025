using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] int _hp = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddDamage()
    {
        _hp -= 1;
        if (_hp <= 0)
        {
            Dead();
        }
    }
    private void Dead()
    {
        //Œã‚ÅŽ€–Sˆ—ì‚é
    }
}
