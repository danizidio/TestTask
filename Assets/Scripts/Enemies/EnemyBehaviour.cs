using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] EnemyAttributes _enemyAttributes;

    [SerializeField] int _currentLife;
    public int CurrentLife { get { return _currentLife; } set { _currentLife = value; } }

    float _moveSpeed;
    
    Rigidbody2D rb;

    Animator _anim;

    Transform _player;

    [SerializeField] float _distanceToAttack;
    [SerializeField] float _bufferDistance;

    float _spd;

    [SerializeField] GameObject _txtAction;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _spd = _enemyAttributes.MoveSpeed;

        CurrentLife = _enemyAttributes.HealthPoints;

        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        if (Vector2.Distance(transform.position, _player.position) > _distanceToAttack && _player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, _spd * Time.deltaTime);
        }
    }

    public void ShowInfoUI(bool show, string txt)
    {
        _txtAction.SetActive(show);
        _txtAction.GetComponentInChildren<TMPro.TMP_Text>().text = txt;
    }

    public void ReceiveDamage(int atk)
    {
        int damage = atk - _enemyAttributes.DefenseArmor;
        CurrentLife -= damage;

        if(CurrentLife <= 0)
        {
            _anim.Play("Death");
        }

        //ShowInfoUI(true, damage.ToString());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerBehaviour p = collision.gameObject.GetComponent<PlayerBehaviour>();

        if (p != null)
        {
            p.ReceiveDamage(_enemyAttributes.AtkStrength);
        }
    }

}
