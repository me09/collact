using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EIDTOR
#endif

public class CrowdManager : MonoBehaviour
{
    public GameObject manPrefab;

    private GameObject[] mans;
    private Transform manTransform;
    private WalkingController manWalkingController;
    private CharacterSettingController manSettingController;

    private GameObject currentIndexCharacter;
    private int pooledAmount = 50;
    private int maxAmount = 100;
    private int currentIndex = 0;

    void Start()
    {
        mans = new GameObject[maxAmount];

        for (int i = 0; i < pooledAmount; i++) {
            GameObject man = Instantiate(manPrefab);
            mans[i] = man;

            manTransform = man.GetComponent<Transform>();
            manWalkingController = man.GetComponent<WalkingController>();
            manSettingController = man.GetComponent<CharacterSettingController>();
            manWalkingController.startWalk();
            man.GetComponent<AnimationController>().walk(manWalkingController.getMoveSpeed());
            manTransform.SetParent(this.transform);
            
            int ranX, ranZ;
            ranX = Random.Range(0, 10);
            ranZ = Random.Range(10, 20);
            manTransform.position = new Vector3(ranX, 0, ranZ - 5);
            manTransform.rotation = Quaternion.Euler(manTransform.up * Random.Range(0, 359));

            manSettingController.setCharacterAttribute((i % 7) + 1, Random.Range(0, 100) * 0.01f, (i % 10));
        }

        currentIndexCharacter = mans[currentIndex];
    }

    public void addCrowd(GameObject newCharacter) {
        if (mans[currentIndex] != null) {
            Destroy(currentIndexCharacter);
        }
        mans[currentIndex] = newCharacter;
        currentIndex = currentIndex + 1 < 100 ? currentIndex + 1 : 0;
        currentIndexCharacter = mans[currentIndex];
    }
  
}
