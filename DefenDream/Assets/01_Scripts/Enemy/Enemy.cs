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

    public bool isDead = false;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }
    public override void Init()
    {
        SelectType();
        _hp = _eType._EnemyHp;
        enemyMovement.enabled = true;

        for (int i = 0; i < _meshRens.Length; i++)
        {
            _meshRens[i].transform.parent.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        DieAnim();
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
                    //print("�ٰŸ�");
                    _eType = _eTypeSO[(int)EnemyType.Melee];
                    _meshRens[(int)EnemyType.Melee].transform.parent.gameObject.SetActive(true);
                    _anim = _meshRens[(int)EnemyType.Melee].transform.parent.GetComponent<Animator>();
                    Melee();
                }
                break;
            case EnemyType.Range:
                {
                    //print("���Ÿ�");
                    _meshRens[(int)EnemyType.Range].transform.parent.gameObject.SetActive(true);
                    _eType = _eTypeSO[(int)EnemyType.Range];
                    _anim = _meshRens[(int)EnemyType.Range].transform.parent.GetComponent<Animator>();
                    Range();
                }
                break;
            case EnemyType.Magic:
                {
                    //print("����");
                    _meshRens[(int)EnemyType.Magic].transform.parent.gameObject.SetActive(true);
                    _eType = _eTypeSO[(int)EnemyType.Magic];
                    _anim = _meshRens[(int)EnemyType.Magic].transform.parent.GetComponent<Animator>();
                    Magic();
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
        print(_meshRens[(int)EnemyType.Melee].material);
    }

    private void Range()
    {
        TypeEnum = EnemyType.Range;
        _meshRens[(int)EnemyType.Range].material = _eType._material;
        print(_meshRens[(int)EnemyType.Range].material);
    }

    private void Magic()
    {
        TypeEnum = EnemyType.Magic;
        _meshRens[(int)EnemyType.Magic].material = _eType._material;
        print(_meshRens[(int)EnemyType.Magic].material);
    }

    public void DecHp(float damage)
    {
        _hp -= damage;
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
        isDead = true;
        enemyMovement.freeze();
        _anim.SetTrigger("Die");
        print("�׾�"); //�׾�
        yield return new WaitForSeconds(2);
        PoolManager.Instance.Push(this);
    }
}