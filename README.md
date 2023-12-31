# [게임개발심화] 팀 프로젝트

## 🎮 *팀원: 조형승(팀장), 사공민수, 정선교, 조성우, 하승권*

---
### 📆 개발 기간
2024.01.02 ~ 2024.01.08

---
### ⚙️ 기술 스택
Unity, Visual Studio, C#

---
### 🧑‍🤝‍🧑 역할 분담
- 조형승 - UI, Sound
- 사공민수 - 적
- 정선교 - 플레이어
- 조성우 - Map, NPC
- 하승권 - 인벤토리, 아이템

---
### 📝 게임 설명

![image](https://github.com/chochozane/TeamProject_TorpenhowHill/assets/130233619/92558d4e-b97b-4968-8de4-2002e19c28f6)

프로젝트명 : Torpenhow Hill

뷰 : 아이소메트릭(쿼터뷰)

해상도 : 1920 * 1080

장르 : 2D / 생존 / 로그라이크 / 타이쿤<br>

스토리 : 
기존에 살던 대륙에서 더 이상 살아가기 힘들었던 주인공이 새로운 땅을 찾아 정착하는 내용<br>
(모티브 : 바이킹)

플레이 방법 :<br>
기본적으로 마우스 클릭으로 움직입니다. A : 공격 / E : 인벤토리 / F : 상호작용 / 스페이스바 : 대화 진행하기<br>
모닥불 하나로 시작하여 마을을 건설하는 게임입니다.<br>
처음에는 자원 수집과 약한 몬스터(적)를 잡으면서 생존을 하고 특정 조건을 만족하면 NPC가 찾아와 정착을 도와달라고 요청(퀘스트)을 합니다. 요청을 들어주면 건물이 지어집니다.<br>
죽으면 게임 오버가 되며 처음부터 다시 시작합니다.<br>
모든 건설(퀘스트) 완료 시 게임클리어가 되며, 이후에 계속해서 게임을 플레이할 수 있습니다.

---
### 📌 주요 기능
#### **필수구현사항**
- 주인공 캐릭터의 이동 및 기본 동작
  - 마우스 클릭으로 플레이어 움직임 구현
  - Idle, Run, Hit, Attack 애니메이션
  - A : 공격 / E : 인벤토리 / F : 상호작용 / 스페이스바 : 대화 진행하기
- 레벨 디자인 및 적절한 게임 오브젝트 배치
  - 다양한 적을 구현하여 레벨 디자인
- 충돌 처리 및 피해량 계산
  - 플레이어와 환경 또는 적 사이의 충돌을 처리하고, 피해량을 계산
- UI/UX 요소
  - 게임 시작 및 일시 정지 메뉴
  - BGM 볼륨 조절
  - 게임 상태를 나타내는 UI 요소 - HP, XP, 시계 및 낮, 밤 구현

#### **선택구현사항**
- 다양한 적 캐릭터와 그들의 행동 패턴 추가
  - 여러 종류의 적 캐릭터를 도입 및 각각 다른 능력치 구현
- 경험치 및 업그레이드 시스템
  - 플레이어가 경험치를 얻고 레벨업을 하면 캐릭터 능력치 업그레이드(MaxHP 및 Damage 증가)
- 사운드 및 음악 효과 추가
  - BGM, 효과음을 추가하여 게임의 오디오 경험 향상
- 스토리텔링 및 대화 시스템
  - NPC 및 퀘스트 구현

---

