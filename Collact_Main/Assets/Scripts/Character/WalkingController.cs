using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingController : MonoBehaviour
{
    private float moveSpeed;
    private float rotSpeed;

    private bool isStart = false;
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    private float MaxDistance = 1f;
    RaycastHit hit;
    private IEnumerator coroutine;

    public void walk() {
        isStart = true;
        moveSpeed = Random.Range(1, 2) * 1f;
        rotSpeed = Random.Range(10, 50) * 1f;
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.blue, 0.3f);
        if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance)) {
            if (hit.transform.tag == "wall") {
                transform.Rotate(transform.up * 180);
            }
        }
        if (isStart) {
            if (!isWandering) {
                    coroutine = Wander();
                    StartCoroutine(coroutine);
            }
            if (isWalking) {
                transform.position += transform.forward * Time.deltaTime * moveSpeed;
            }
            if (isRotatingLeft) {
                transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
            } else if (isRotatingRight) {
                transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
            }
        }
    }

    IEnumerator Wander() {
        int rotTime = Random.Range(1, 2);
        int rotateWait = Random.Range(0, 1);
        int rotateLorR = Random.Range(0, 3);
        int walkWait = Random.Range(0, 1);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        // isWalking = false;
        // yield return new WaitForSeconds(rotateWait);
        if(rotateLorR == 1) {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        } else if (rotateLorR == 2) {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;
    }
}
