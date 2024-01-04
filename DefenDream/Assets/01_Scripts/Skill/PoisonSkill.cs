using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSkill : PoolableMono
{
    private float _curTime;
    [SerializeField] private float _duration;
    [SerializeField] private float _tickTime;

    [SerializeField] private float DMG;

	private void Awake()
	{
		gameObject.SetActive(false);
	}

	public override void Init()
    {
    }

    private void OnEnable()
    {
        StartCoroutine(WaitPool());
    }

    private IEnumerator WaitPool()
    {
        SoundManager.Instance.Poision();
        yield return new WaitForSeconds(_duration);
        PoolManager.Instance.Push(this);
    }
        
    private void Update()
    {
        if (0 < _curTime)
        {
            _curTime -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (_curTime <= 0)
            {
                other.gameObject.GetComponent<Enemy>().DecHp(DMG);

                _curTime = _tickTime;
            }
        }
    }
}
