using EnemyEnum;
using UnityEngine;

public class Enemy : PoolableMono
{
    [SerializeField] private EnemyTypeSO[] _eTypeSO;
    [SerializeField] private float _spawnTime;

    [HideInInspector] public EnemyTypeSO _eType;
    [HideInInspector] public EnemyType TypeEnum;

    [Header("visual")]
    [SerializeField] private SkinnedMeshRenderer _meshRen;
    [SerializeField] private Animator _anim;
    private bool isDead = false;

    public override void Init()
    {
        SelectType();
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
        _eType._EnemyHp -= damage;
    }

    private void DieAnim()
    {

        if (_eType._EnemyHp <= 0 && !isDead)
        {
            isDead = true;
            _anim.SetTrigger("Die");
            //Ǯ�Ŵ��� 1�� �̵���
            print("�׾�"); //�׾�
        }
    }
}