using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public void Die()
    {
        // TODO : 죽었을 때 애니메이션 등의 효과 추과
        // TODO : 경험치 제공 로직 추가
        gameObject.SetActive(false);
    }
}
