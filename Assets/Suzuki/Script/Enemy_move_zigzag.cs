using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int _index;
    [SerializeField] float speed; //�G�̃X�s�[�h
    [SerializeField] Vector2[] _positions; //�ړ�����ʒu

    void Update()
    {
        var dir = ((Vector3)_positions[_index] - transform.position).normalized;//vector�R�̌^�ɕϊ����Č��݈ʒu���擾���ăm�[�}���C�Y����
        transform.position += dir * speed * Time.deltaTime;//speed�ƃf���^�^�C����dir�����������l���ړ�����

        if (Vector2.Distance(_positions[_index], transform.position) <= 0.3f)//���݂̈ʒu��0.3f�ȉ��Ȃ�
        {
            _index = (_index + 1) % _positions.Length;//���̈ړ��ʒu��ύX���A�Ō�̈ʒu�Ȃ猳�̈ʒu�ɖ߂�
        }

    }


}
