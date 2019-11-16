using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFadeout : MonoBehaviour
{
    public EventManager eventManager;
    private Animator wallanim;

    void OnEnable() {
        eventManager.changeSceneEvent += setWall;
    }

    void OnDisable() {
        eventManager.changeSceneEvent -= setWall;
    }

    void Start() {
        wallanim = GetComponent<Animator>();
    }

    private void setWall(int currentScene) {
        if (currentScene == 5) {
            StartCoroutine(delay());
        } else {
            wallanim.Rebind();
        }
    }

    IEnumerator delay() {
        yield return new WaitForSeconds(7);
        wallanim.Play("WallFadeout");
    }
}
