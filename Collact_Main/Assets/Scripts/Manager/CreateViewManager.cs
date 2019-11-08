using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateViewManager : MonoBehaviour
{
    public EventManager eventManager;
    public GameObject characterPrefab;

    private Transform characterTransform;
    private CharacterSettingController characterSettingController;

    void OnEnable() {
        eventManager.startEvent += createCharacter;
    }

    public void createCharacter() {
        Debug.Log("delegate?????");
        GameObject character = Instantiate(characterPrefab);

        characterTransform = character.GetComponent<Transform>();
        characterTransform.SetParent(this.transform);

        characterSettingController = character.GetComponent<CharacterSettingController>();

        characterTransform.position = new Vector3(0, 0, 0);

        characterSettingController.setInitState();
    }

    public void setField(int field) {
        characterSettingController.setField(field);
    }

    public void setSaturation(float saturation) {
        characterSettingController.setSaturation(saturation);
    }

    public void setAcc(int year) {
        characterSettingController.setAcc(year);
    }
}
