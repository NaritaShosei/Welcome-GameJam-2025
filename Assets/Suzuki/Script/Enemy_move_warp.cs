using System.Collections.Generic;
using UnityEngine;



public class Enemy_warp : MonoBehaviour
{
    float timer;
    [SerializeField] float _interval = 1;//���[�v�̃N�[���^�C��
    [SerializeField] Vector2[] _positions;
    void Start()
    {

    }
    private void Update()
    {
        var index = Random.Range(0, _positions.Length);�@// �� �ݒ肵�����[�v�|�W�V�������͈̔͂Ń����_���Ȑ����l���Ԃ�
        timer += Time.deltaTime;//timer��Time.deltaTime�����Z����
        if (timer >= _interval) //timer���C���^�[�o���ȏ�Ȃ�
        {
            transform.position= _positions[index];//�|�W�V�������ړ�
            timer = 0;//timer�����Z�b�g
        }
    }
}