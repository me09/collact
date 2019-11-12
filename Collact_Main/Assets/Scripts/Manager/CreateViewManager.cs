using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateViewManager : MonoBehaviour
{
    public EventManager eventManager;
    public GameObject characterPrefab;
    public GameObject currentCreatedCharacter;

    private Transform characterTransform;
    private CharacterSettingController characterSettingController;
    private AnimationController characterAnimationController;

    void OnEnable() {
        eventManager.startEvent += createCharacter;
        eventManager.fieldEvent += setField;
        eventManager.saturationEvent += setSaturation;
        eventManager.yearEvent += setAcc;

        eventManager.animateEvent += startAnimation;
    }

    public void createCharacter() {
        GameObject character = Instantiate(characterPrefab);
        currentCreatedCharacter = character;

        characterTransform = character.GetComponent<Transform>();
        characterTransform.SetParent(this.transform);

        characterTransform.position = new Vector3(1.35f, 0, 26);
        characterTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        characterSettingController = character.GetComponent<CharacterSettingController>();
        characterAnimationController = character.GetComponent<AnimationController>();

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

    public void startAnimation(string trigger) {
        characterAnimationController.animate(trigger);
    }

    public GameObject getCurrentCreatedCharacter() {
        return currentCreatedCharacter;
    }
}
