using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
 Collider2D coll; //변수 생성 및 초기화

private void Awake()
 {
 coll = GetComponent<Collider2D>();
 
}

private void OnTriggerExit2D(Collider2D collision) //충돌했는지 확인 collision
 {
 if(!collision. CompareTag("Area"))
 {
 return;
 }

Vector3 playerPos = GameManager.instance.player.transform.position; //Gamemanger를 활용해서 player의 position을 가져옴
 Vector3 myPos = transform.position;//맵의 위치

float diffX = Mathf.Abs(playerPos.x - myPos.x); //플레이어 위치와 맵의 위치의 x값의 차
 float diffY = Mathf.Abs(playerPos.y - myPos.y);//플레이어 위치와 맵의 위치의 y값의 차

Vector3 playerDir = GameManager.instance.player.inputVec;//플레이어의 벡터값을 가져옴
 float dirX = playerDir.x > 0 ? 1 : -1; //3차 연산자 조건이 맞아? 로 물어보고 맞으면 -1 틀리면 1 출력
 float dirY = playerDir.y > 0 ? 1 : -1; //이부분은 원래 x,y가 0보다 작니?이런식이였지만 버그가 발생해 x,y가 크니로 바꿔서 하니까 버그가 사라짐

switch(transform.tag)
 {
 case "Ground":
 if(diffX > diffY)
 {
 transform. Translate(Vector3.right * dirX * 40);
 }
 else if(diffX < diffY)
 {
 transform. Translate(Vector3.up * dirY * 40);
 }
 break;
 case "Enemy":
 if(coll.enabled)
 {
 transform. Translate(playerDir * 20 + new Vector3(Random.Range(-3f,3f), Random.Range(-3f, 3f),0.0f));
 }
 break;
 }
 }

}