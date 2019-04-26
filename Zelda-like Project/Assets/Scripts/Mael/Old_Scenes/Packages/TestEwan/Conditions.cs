//Copyright (c) Ewan Argouse - http://narudgi.github.io/

//using System.Collections;
//using System.Collections.Generic;
//using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystem
{
    public enum ConditionEnemy
    {
        DistanceToPlayer,
        Cooldown,
        Number,
        TakeDamage,
        IsAttacked,
        PlayerUseSmth,
        FKDSLMKF
    }

    public enum ConditionType
    {
        Greater,
        Lesser
    }

    [System.Serializable]
    public class MyClass
    {
        public ConditionEnemy conditionEnemy;
        public ConditionType conditionType;
        public float value;
        public UnityEvent @event;
    }

    [ExecuteInEditMode]
    public class Conditions : MonoBehaviour
    {
        [SerializeField] private MyClass[] myClasses = default;
        public UnityEvent isAttacked;
        public UnityEvent takeDamage;
        [SerializeField] private Transform target = default;
        [SerializeField] private string conditionDistance = "DistanceToPlayer";
        [SerializeField] private string attackParamater = "Attack";
        [SerializeField] Animator animator;

        private void Update()
        {
            if (animator == null) return;
            animator.SetFloat(conditionDistance, Vector3.Distance(target.position, transform.position));
            int numberOfAttack = 2;
            int attackRandom = Random.Range(1, numberOfAttack + 1);
            for (int i = 1; i < numberOfAttack + 1; i++)
            {
                bool isAttacking = attackRandom == i;
                animator.SetBool(attackParamater + i.ToString(), isAttacking);
            }
        }

        private bool CheckConditions()
        {
            for (int i = 0; i < myClasses.Length; i++)
            {
                MyClass myClass = myClasses[i];
                switch (myClass.conditionEnemy)
                {
                    case ConditionEnemy.DistanceToPlayer:
                        if (myClass.conditionEnemy.Equals(ConditionType.Greater))
                        {
                            return false;
                        }
                        else
                        {
                            if (Vector3.Distance(target.position, transform.position) < myClass.value) return true;
                            return false;
                        }
                    case ConditionEnemy.Cooldown:
                        break;
                    case ConditionEnemy.Number:
                        break;
                    case ConditionEnemy.IsAttacked:
                        if (myClass.conditionEnemy.Equals(ConditionType.Greater))
                        {
                            if (Vector3.Distance(target.position, transform.position) > myClass.value) return true;
                            return false;
                        }
                        else
                        {
                            if (Vector3.Distance(target.position, transform.position) < myClass.value) return true;
                            return false;
                        }
                    case ConditionEnemy.TakeDamage:
                        break;
                    case ConditionEnemy.PlayerUseSmth:
                        break;
                    default:
                        break;
                }
            }
            return false;
        }
    }
}