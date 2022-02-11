using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetRotation : MonoBehaviour
{
    public float rotAngle = 200f;   //回転のスピード
    public GameObject centerObj;    //回転の中心オブジェクト
    private Vector3 targetPos; //中心位置ポジションを入れる変数
    void Start()
    {
        targetPos = centerObj.transform.position;      //回転中心オブジェクトの位置
    }
    void Update()
    {
        Transform centerObj = GameObject.Find("weapon").transform;
        targetPos = centerObj.transform.position;
        transform.RotateAround(targetPos, Vector3.up, rotAngle * Time.deltaTime);
    }
}