using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMovementType : FollowPath
{
    [SerializeField] public GameObject Object;
    [SerializeField] public MovementType movementTypeNext;
    private Animator animator;

    private void Start()
    {
        animator = Object.GetComponent<Animator>();
    }

    private void Update()
    {
        var distancrSqure = (transform.position - Object.transform.position).sqrMagnitude;
        if (distancrSqure < maxDistance)
        {
            Type = movementTypeNext;
            if(movementTypeNext == MovementType.Walk)
            {
                animator.SetBool("RunTrigger", false);
            }
            else if (movementTypeNext == MovementType.Run)
            {
                animator.SetBool("RunTrigger", true);
            }
        }
    }


}
