using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject winText;
    public float distance;

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < distance)
        {
            winText.SetActive(true);
            player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            Destroy(gameObject);
        }
    }
}