using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInMenus : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Update()
    {
        animator.Play("idle");

    }
}
