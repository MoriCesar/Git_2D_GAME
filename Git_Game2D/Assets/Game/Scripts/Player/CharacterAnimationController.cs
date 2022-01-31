using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

public static class CharacterMovementAnimationKeys
{ 
    public const string IsCrouching = "IsCrouching";
    public const string HorizontalSpeed = "HorizontalSpeed";
    public const string VerticalSpeed = "VerticalSpeed";
    public const string IsGrounded ="IsGrounded";
    public const string TriggerDead = "Dead";
    public const string IsAttacking = "IsAttacking";
}

public static class EnemyAnimationKeys
{ 
    public const string IsChasing = "IsChasing";
}


public class CharacterAnimationController : MonoBehaviour
{
    private IDamageable damageable;
   protected Animator animator;
   protected CharacterMovement2D characterMovement;
   
   
   protected virtual void Awake()
   { 
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement2D>();
        damageable = GetComponent<IDamageable>();
        damageable.DeathEvent += OnDeath;
   }

   private void OnDestroy()
    { 
        damageable.DeathEvent -= OnDeath;
    }

   protected virtual void Update()
   { 
       animator.SetFloat(CharacterMovementAnimationKeys.HorizontalSpeed,characterMovement.CurrentVelocity.x / characterMovement.MaxGroundSpeed);   
   }

   private void OnDeath()
    { 
        animator.SetTrigger(CharacterMovementAnimationKeys.TriggerDead);
    }

}
