using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingController : MonoBehaviour
{
    private float moveSpeed;
    private float rotSpeed;

    private bool isStart = false;
    private bool isGoingToCenter = false;
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    private float MaxDistance = 1f;
    private Vector3 destination = new Vector3(0, 0, 13f);
    RaycastHit hit;

    public void walk() {
        isStart = true;
        moveSpeed = Random.Range(0.5f, 1.5f);
        rotSpeed = Random.Range(10, 50) * 1f;
    }

    void Update()
    {
        if (isStart) {
            if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance)) {
                if (hit.transform.tag == "wall") {
                    transform.Rotate(transform.up * 180);
                }
            }
            if (!isWandering) {
                    StartCoroutine(wander());
            }
            if (isWalking) {
                transform.position += transform.forward * Time.deltaTime * moveSpeed;
            }
            if (isRotatingLeft) {
                transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
            } else if (isRotatingRight) {
                transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
            }
        } else if (isGoingToCenter) {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }

    IEnumerator wander() {
        int rotTime = Random.Range(1, 2);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(0, 1);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
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

    // public void goToCrowd() {
    //     Debug.Log("?????");
    //     isGoingToCenter = true;
    //     moveSpeed = 2f;
    //     StartCoroutine(goToCrowdRoutine());
    // }

    // IEnumerator goToCrowdRoutine() {
    //     while (isGoingToCenter) {
    //         float dist = Vector3.Distance(this.transform.position, destination);
    //         if (dist <= 2f) {
    //             isGoingToCenter = false;
    //             walk();
    //             yield return null;
    //         }
    //     }
    // }
}
