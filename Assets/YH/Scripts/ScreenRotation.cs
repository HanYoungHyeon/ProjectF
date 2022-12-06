using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenRotation : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    private Vector2 prevPoint;
    private Vector2 lookInput;
    private int rightFingerId;
    private float halfScreenWidth;  //ȭ�� ���ݸ� ��ġ�ϸ� ī�޶� ȸ��
    private float cameraPitch; //pitch ����
    public float cameraSensitivity;
    public Transform cameraTransform;
    void Start()
    {
        cameraSensitivity = 2;
        this.rightFingerId = -1;    //-1�� �������� �ƴ� �հ���
        this.halfScreenWidth = Screen.width / 2;
        this.cameraPitch = 35f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, this.player.transform.position + new Vector3(0, this.transform.position.y, 0), this.speed);
        Debug.DrawLine(cameraTransform.position, cameraTransform.forward, Color.red);
        GetTouchInput();
    }

    private void GetTouchInput()
    {
        //��� ��ġ�� �ԷµǴ°�
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            switch (t.phase)
            {
                case TouchPhase.Began:

                    if (t.position.x > this.halfScreenWidth && this.rightFingerId == -1)
                    {
                        this.rightFingerId = t.fingerId;
                    }
                    break;

                case TouchPhase.Moved:

                    //�̰��� �߰��ϸ� ���� ������ ��ư�� ���� �� ȭ���� ���ư��� �ʴ´�
                    if (!EventSystem.current.IsPointerOverGameObject(i))
                    {
                        if (t.fingerId == this.rightFingerId)
                        {
                            this.prevPoint = t.position - t.deltaPosition;
                            float horizon = t.position.x - this.prevPoint.x;
                            this.transform.RotateAround(this.player.transform.position, Vector3.up, -(horizon) * 0.2f) ;
                            this.prevPoint = t.position;

                            this.lookInput = t.deltaPosition * this.cameraSensitivity * Time.deltaTime;
                            this.cameraPitch = Mathf.Clamp(this.cameraPitch - this.lookInput.y, 10f, 35f);
                            this.cameraTransform.localRotation = Quaternion.Euler(this.cameraPitch, 0, 0);
                            
                        }
                    }
                    break;

                case TouchPhase.Stationary:

                    if (t.fingerId == this.rightFingerId)
                    {
                        this.lookInput = Vector2.zero;

                    }
                    break;

                case TouchPhase.Ended:

                    if (t.fingerId == this.rightFingerId)
                    {
                        this.rightFingerId = -1;
                    }
                    break;

                case TouchPhase.Canceled:

                    if (t.fingerId == this.rightFingerId)
                    {
                        this.rightFingerId = -1;
                    }
                    break;
            }
        }
    }
}
