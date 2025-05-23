using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float specialGauge = 0f;            // 必殺技ゲージ
    [SerializeField] float gaugeMax = 100f;        // ゲージ最大値
    [SerializeField] float gaugeGain = 5f;        // 1回の攻撃で増える量
    //const float gaugeGainDestroy = 10f;     //敵を倒したときに得る量
    [SerializeField] ColorChanger _colorChanger;
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] SpecialGauge _gauge;

    CameraShake _cameraShake;
    [SerializeField]
    AnimationCurve _curve;
    [SerializeField] float _duration;
    bool _isPlaying;
    float _timer;
    int _spCount;

    [SerializeField] SpriteRenderer[] _sprites;

    [SerializeField] AudioClip _attackClip;
    [SerializeField] AudioClip _spClip;
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _cameraShake = FindAnyObjectByType<CameraShake>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _sr.color = _colorChanger.Color;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;

        //攻撃を左クリックで発動

        if (Input.GetMouseButtonDown(0))
        {
            if (_audioSource != null)
            {
                _audioSource.PlayOneShot(_attackClip);
            }
            Attack();
        }

        if (specialGauge >= gaugeMax)
        {
            if (_spCount < _sprites.Length)
            {
                _sprites[_spCount].enabled = true;
                _spCount = Mathf.Min(_spCount + 1, _sprites.Length);
                specialGauge = 0;
                // ゲージをリセット
                specialGauge = 0f;
                _gauge.UpdateGaugeBar(gaugeMax, specialGauge);
            }
        }

        //必殺技をマウスの中央ボタンで発動

        if (Input.GetMouseButtonDown(2) && _spCount > 0)
        {
            if (_audioSource != null)
            {
                _audioSource.PlayOneShot(_spClip);
            }
            _spCount--;
            _sprites[_spCount].enabled = false;
            _isPlaying = true;
        }

        if (_isPlaying)
        {
            _timer += Time.unscaledDeltaTime;
            float t = Mathf.Clamp01(_timer / _duration);
            Time.timeScale = _curve.Evaluate(t);

            if (t >= 1)
            {
                _isPlaying = false;
                UseSpecialMove();
                _timer = 0f;
            }

        }
        // 必殺技ゲージの状態を表示（デバッグ用）
        Debug.Log($"必殺技ゲージ: {specialGauge}/{gaugeMax}");


        //敵を倒すと必殺技がたまる
        //if () 
        {


        }

        void Attack()
        {
            var ray = Physics2D.Raycast(transform.position, Camera.main.transform.forward, 10);
            if (ray.collider != null && ray.collider.CompareTag("Enemy"))
            {

                var target = ray.collider.gameObject.GetComponent<ConflictColorSystem>();
                Debug.Log(target.name);
                if (target.Hit(_colorChanger.Color))
                {
                    // ゲージを増加（最大値を超えないように）
                    specialGauge += gaugeGain;
                    specialGauge = Mathf.Min(specialGauge, gaugeMax);
                    _gauge.UpdateGaugeBar(gaugeMax, specialGauge);
                }

            }
        }



        void UseSpecialMove()
        {
            Debug.Log("必殺技 発動！！");
            _cameraShake.Shake(0.6f);
            // 敵を全滅させる処理（例：タグが Enemy の全オブジェクトを Destroy）
            var targets = FindObjectsByType<ConflictColorSystem>(FindObjectsSortMode.None);
            foreach (var target in targets)
            {
                target.SPHit(Random.Range(0, 0.3f));
            }


        }
    }
}
