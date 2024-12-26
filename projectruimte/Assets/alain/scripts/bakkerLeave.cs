using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakkerLeave : MonoBehaviour
{
    private GameObject player;
    private GameObject bakkersTv;
    private GameObject rijdendeBus;
    private Animator busAnimatie;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("speler");
        bakkersTv = GameObject.FindWithTag("bakkerstv");
        rijdendeBus = GameObject.FindWithTag("bus");
        busAnimatie = rijdendeBus.GetComponent<Animator>();
    }

    public void GaBuiten()
    {
        player.gameObject.transform.position = new Vector3(-43f, 1f, 45f);
        player.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
        Debug.Log("BYE");
        PlayVideo bakkersfilm = bakkersTv.GetComponent<PlayVideo>();
        bakkersfilm.Stop();
        busAnimatie.enabled = !busAnimatie.enabled;
        rijdendeBus.gameObject.transform.position = new Vector3(-29, 0f, 48);
        rijdendeBus.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
    }
}
