using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private new void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            float speed = Time.deltaTime * 10f;
            Vector3 tpos = Input.GetTouch(0).position;
            if (tpos.x <= Screen.width / 2)
                transform.Translate(-Vector3.right * speed);
            else if (tpos.x >= Screen.width / 2)
                transform.Translate(Vector3.right * speed);
        }
    }


}
