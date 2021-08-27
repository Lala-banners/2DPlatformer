using System;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject moveTips;

    // Start is called before the first frame update
    void Start() {
        moveTips.SetActive(false);
    }

    public void ActivateTips() {
        moveTips.SetActive(true);
    }

    public void DeactivateTips() {
        moveTips.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            ActivateTips();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        DeactivateTips();
    }
}