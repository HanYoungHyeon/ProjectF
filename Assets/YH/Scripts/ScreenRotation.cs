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

    private int rightFingerId;
    float halfScreenWidth;  //ȭ�� ���ݸ� ��ġ�ϸ� ī�޶� ȸ��
    private Vector2 prevPoint;

    private Vector3 originalPos;
    public Transform cameraTransform;
    public float cameraSensitivity;

    private Vector2 lookInput;
    private float cameraPitch; //pitch ����


    void Start()
    {
        cameraSensitivity = 2;
        this.rightFingerId = -1;    //-1�� �������� �ƴ� �հ���
        this.halfScreenWidth = Screen.width / 2;
        this.originalPos = new Vector3(0, 0, 0);
        this.cameraPitch = 35f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, this.player.transform.position + new Vector3(0, this.transform.position.y, 0), this.speed);

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
                        Debug.Log("������ �հ��� �Է�");
                    }
                    break;

                case TouchPhase.Moved:

                    //�̰��� �߰��ϸ� ���� ������ ��ư�� ���� �� ȭ���� ���ư��� �ʴ´�
                    if (!EventSystem.current.IsPointerOverGameObject(i))
                    {
                        if (t.fingerId == this.rightFingerId)
                        {

                            //����
                            //this.prevPoint = t.position - t.deltaPosition;
                            ////this.transform.RotateAround(transform.position, Vector3.up, -(t.position.x - this.prevPoint.x) * 0.2f);
                            //this.cameraTransform.localRotation = Quaternion.Euler(t.position.x - this.prevPoint.x, 0, 0);
                            //this.prevPoint = t.position;

                            //this.lookInput = t.deltaPosition * this.cameraSensitivity * Time.deltaTime;
                            //this.prevPoint = t.position - t.deltaPosition;
                            //this.cameraPitch = Mathf.Clamp(this.cameraPitch - this.prevPoint.x, 20f, 160f);
                            //this.cameraTransform.localRotation = Quaternion.Euler(0, this.prevPoint.x, 0);
                            this.lookInput = t.deltaPosition * this.cameraSensitivity * Time.deltaTime;
                            this.transform.Rotate(transform.up, lookInput.x);
                            //����
                            
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
                        Debug.Log("������ �հ��� ��");

                    }
                    break;

                case TouchPhase.Canceled:

                    if (t.fingerId == this.rightFingerId)
                    {
                        this.rightFingerId = -1;
                        Debug.Log("������ �հ��� ��");

                    }
                    break;
            }
        }
    }


}