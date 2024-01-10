using EnemyEnum;
using UnityEngine;
using System.Collections;

public class Enemy : PoolableMono
{
    [SerializeField] private EnemyTypeSO[] _eTypeSO;
    [SerializeField] private float _spawnTime;

    [HideInInspector] public EnemyTypeSO _eType;
    [HideInInspector] public EnemyType TypeEnum;

    private EnemyMovement enemyMovement;

    [Header("Visual")]
    [SerializeField] private SkinnedMeshRenderer[] _meshRens;
    [SerializeField] private Animator _anim;

    [SerializeField] private float _hp;

    private EntityHP hpbar;
    private EnemyMovement _eMove;

    private GameObject healthGauge;

    public bool isDead = false;

    [SerializeField] private GameObject coin;

    private void Awake()
    {
        _eMove = GetComponent<EnemyMovement>();
        enemyMovement = GetComponent<EnemyMovement>();
        hpbar = GetComponent<EntityHP>();
        healthGauge = hpbar.HealthBar.gameObject;
    }

    public override void Init()
    {
        enemyMovement.enabled = true;

        for (int i = 0; i < _meshRens.Length; i++)
        {
            _meshRens[i].transform.parent.gameObject.SetActive(false);
        }
        SelectType();
        _hp = _eType._EnemyHp;
        isDead = false;
        healthGauge.SetActive(true);

        hpbar.SetHP(_hp);
        hpbar.ResetHP();
    }

    private void Update()
    {
        DieAnim();
        if (Input.GetKeyDown(KeyCode.V))
        {
            print("vvv");
            _anim.SetTrigger("Die");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            print("bbb");
            _anim.SetTrigger("Init");
            _anim.SetTrigger("Move");
        }
    }

    private int RandomSpawn()
    {
        int i = Random.Range(0, 3);

        return i;
    }

    private void SelectType()
    {
        switch ((EnemyType)RandomSpawn())
        {
            case EnemyType.Melee:
                {
                    //print("근거리");
                    _eType = _eTypeSO[(int)EnemyType.Melee];
                    _meshRens[(int)EnemyType.Melee].transform.parent.gameObject.SetActive(true);
                    _anim = _meshRens[(int)EnemyType.Melee].transform.parent.GetComponent<Animator>();
                    Melee();
                    _meshRens[(int)EnemyType.Melee].transform.parent.transform.rotation = Quaternion.Euler(0, -90, 0);
                }
                break;
            case EnemyType.Range:
                {
                    //print("원거리");
                    _meshRens[(int)EnemyType.Range].transform.parent.gameObject.SetActive(true);
                    _eType = _eTypeSO[(int)EnemyType.Range];
                    _anim = _meshRens[(int)EnemyType.Range].transform.parent.GetComponent<Animator>();
                    Range();
                    _meshRens[(int)EnemyType.Range].transform.parent.transform.rotation = Quaternion.Euler(90, -90, 0);
                }
                break;
            case EnemyType.Magic:
                {
                    //print("마법");
                    _meshRens[(int)EnemyType.Magic].transform.parent.gameObject.SetActive(true);
                    _eType = _eTypeSO[(int)EnemyType.Magic];
                    _anim = _meshRens[(int)EnemyType.Magic].transform.parent.GetComponent<Animator>();
                    Magic();
                    _meshRens[(int)EnemyType.Magic].transform.parent.transform.rotation = Quaternion.Euler(90, -90, 0);
                }
                break;
            default:
                break;
        }
    }

    private void Melee()
    {
        TypeEnum = EnemyType.Melee;
        _meshRens[(int)EnemyType.Melee].material = _eType._material;
    }

    private void Range()
    {
        TypeEnum = EnemyType.Range;
        _meshRens[(int)EnemyType.Range].material = _eType._material;
    }

    private void Magic()
    {
        TypeEnum = EnemyType.Magic;
        _meshRens[(int)EnemyType.Magic].material = _eType._material;
    }

    public void DecHp(float damage)
    {
        _hp -= damage;
        _hp = Mathf.Clamp(_hp, 0, _eType._EnemyHp);
        hpbar.OnDamage(damage);
    }

    private void DieAnim()
    {
        if (_hp <= 0 && !isDead)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        Instantiate(coin, transform.position, Quaternion.identity);
        isDead = true;
        enemyMovement._speed = 0;
        enemyMovement.enabled = false;
        _anim.SetTrigger("Die");
        healthGauge.SetActive(false);

        yield return new WaitForSeconds(2);
        _anim.SetTrigger("Init");
        _anim.SetTrigger("Move");
        _meshRens[(int)EnemyType.Melee].transform.parent.transform.rotation = Quaternion.Euler(0, -90, 0);
        //_meshRens[(int)EnemyType.Magic].transform.parent.transform.rotation = Quaternion.Euler(90, -90, 0);
        _meshRens[(int)EnemyType.Range].transform.parent.transform.rotation = Quaternion.Euler(0, -90, 0);

        PoolManager.Instance.Push(this);
    }
}
