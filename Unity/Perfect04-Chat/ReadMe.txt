﻿

■ 채팅 예제 프로그램

● 실행 파일 
04\Chat\bin\chat.exe


● 플레이 방법 
타이틀 화면에서 대화 상대를 기다릴 플레이어는 「채팅방 작성」을 누릅니다.
대기 중인 플레이어와 채팅할 플레이어는 「상대방 IP 주소」 텍스트 필드에 대기중인 플레이어의 IP주소를 입력해서 「채팅방 들어가기」를 눌러주세요.


화면 중앙의 텍스트 필드에 메시지를 입력하고 「말하기」 버튼을 눌러 메시지를 전송합니다. 
대화를 마치려면 화면 오른쪽 아래 「나가기」버튼을 눌러주세요. 


●예제 프로그램 
프로젝트 파일：04\Chat\Assets\Scene\Chat.unity
프로그램：04\Chat\Assets\Scripts

Chat.cs				채팅 프로그램 chat의 시퀀스 제어 및 통신 제어 
TransportTCP.cs			TCP 소켓 통신 프로그램

