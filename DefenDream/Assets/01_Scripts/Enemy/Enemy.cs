using EnemyEnum;
using UnityEngine;
using System.Collections;

public class Enemy : PoolableMono
{
    [SerializeField] private EnemyTypeSO[] _eTypeSO;
    [SerializeField] private float _spawnTime;

    [HideInInspector] public EnemyTypeSO _eType;
    [HideInInspector] public EnemyType TypeEnum;

    [Header("Visual")]
    [SerializeField] private SkinnedMeshRenderer _meshRen;
    [SerializeField] private Animator _anim;

    [SerializeField] private float _hp;

    public bool isDead = false;

    public override void Init()
    {
        SelectType();
        _hp = _eType._EnemyHp;
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
                    Melee();
                }
                break;
            case EnemyType.Range:
                {
                    //print("���Ÿ�");

                    _eType = _eTypeSO[(int)EnemyType.Range];
                    Range();
                }
                break;
            case EnemyType.Magic:
                {
                    //print("����");

                    _eType = _eTypeSO[(int)EnemyType.Magic];
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
        _meshRen.material = _eType._material;
    }

    private void Range()
    {
        TypeEnum = EnemyType.Range;
        _meshRen.material = _eType._material;
    }

    private void Magic()
    {
        TypeEnum = EnemyType.Magic;
        _meshRen.material = _eType._material;
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
        _anim.SetTrigger("Die");
        print("�׾�"); //�׾�
        yield return new WaitForSeconds(2);
        PoolManager.Instance.Push(this);
    }
}