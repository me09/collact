using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }
    
    public void animate(string trigger) {
        animator.SetTrigger(trigger);
    }

    public void walk(float moveSpeed) {
        animator.enabled = true;
        animator.speed = moveSpeed;
        animator.SetTrigger("Walk");
    }

    public void hello() {
        animator.SetTrigger("Hello");
    }

    public void surprise() {
        animator.SetTrigger("Surprise");
    }

    public void dancing() {
        animator.SetTrigger("Dancing");
    }

    public void stop() {
        animator.enabled = false;
    }
}
