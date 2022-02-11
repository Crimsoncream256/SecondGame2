using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemOn : MonoBehaviour
{
    public GameObject itemObject; //シーンに置いてある拾うアイテムの変数
    public GameObject gottenObject; //それによって装備されるアイテムの変数
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player") //当たった相手のTagがプレイヤーだったら
        {
            gottenObject.gameObject.SetActive(true); // 装備品のオブジェクトを出現させます
            itemObject.gameObject.SetActive(false); // シーンに置かれたアイテムを消します
        }
    }
}