using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Camera : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFollow();
    }

    void PlayerFollow()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 10);
    }
}
