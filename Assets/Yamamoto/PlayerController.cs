using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float a;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;


        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        var ray = Physics2D.Raycast(transform.position, Camera.main.transform.forward, 10);
        if (ray.collider != null && ray.collider.CompareTag("Enemy"))
        {
            Debug.Log("çUåÇÇµÇ‹ÇµÇΩ");
        }

    }
}
