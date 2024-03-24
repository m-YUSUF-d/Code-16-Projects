using Photon.Pun;
using UnityEngine;

public class FighterFire : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private GameObject[] rockets;

    [SerializeField] private float time;
    [SerializeField] private float rocketNumber;

    private float timer;


    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer > time && rocketNumber > 0)
        {
            foreach (var point in points)
            {
                Instantiate(rockets[0], point.transform.position, point.transform.rotation).GetComponent<Ammo>().jet = gameObject;
            }
            timer = 0;
        }
    }
}
