using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    Canvas interactiveCanvas;
    bool isTrigger = false;

    delegate void OnInteractive();
    OnInteractive onInteractive;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        interactiveCanvas = GameObject.FindGameObjectWithTag("InteractiveUI").GetComponent<Canvas>();
        interactiveCanvas.enabled = false;

        onInteractive += () => GameInstance.GetInst().ChangeScene(GameInstance.JumpGameScene);
    }

    // Update is called once per frame
    void Update()
    {
        RenderUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTrigger = true;
        interactiveCanvas.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isTrigger = false;
        interactiveCanvas.enabled = false;
    }

    void RenderUpdate()
    {
        if (isTrigger)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                // 상호작용 로직
                Debug.Log("상호작용 시작");
                onInteractive();
            }
        }
    }
}
