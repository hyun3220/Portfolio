##  ✔ 로그인 화면


![1](https://user-images.githubusercontent.com/73989505/144612625-8080fc52-4c43-4ffb-bf4e-13acbd28ce98.JPG)

 * ID, PW를 Firebase와 연동된 데이터와 비교하여 일치 여부를 확인해 전달한다.

## ✔ 회원가입 화면

![2](https://user-images.githubusercontent.com/73989505/144613646-16f46827-528e-4b6a-b2cd-563db9c8eeda.JPG)

 * ID 중복확인 버튼을 통해 작성한 ID가 사용 가능한지 여부 체크
 * **비밀번호 정규식 패턴**을 통해 사용 가능한 비밀번호인지 체크
   
   ✔ 비밀번호 정규식 사용 코드
   ```
   public static bool pwCheck(string password)
        {
            Regex regex = new Regex(@"^(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            Match match = regex.Match(password);
            return match.Success;
        }
    ```

## ✔ 메인 화면 디자인 (관리자 계정 접속)

![3](https://user-images.githubusercontent.com/73989505/144613838-46f51706-473d-408c-afff-cb59781d8c6a.JPG)

 * 관리자 계정으로 로그인 시 도서관 관리, 도서 관리, 사용자 관리 메뉴 사용 가능
 
## ✔ 메인 화면 디자인 (일반 사용자 계정)

![16](https://user-images.githubusercontent.com/73989505/144614036-570416ee-5a19-4ec6-9567-47a73d66b05e.JPG)

 * 관리자가 아닌 일반 사용자가 접속시 **도서 검색** 기능과 정보 수정 기능만 제공

## ✔ 도서 검색 기능

![4](https://user-images.githubusercontent.com/73989505/144614694-ce212301-e303-478d-9d1b-7964de8227e9.JPG)

 * 도서명을 입력한 후 검색 버튼 클릭시 해당 도서가 위치한 부분으로 이동해 선택된(Selected) 상태로 전환
 * 관리자 뿐만 아니라 일반 사용자도 사용 가능하도록 설정

## ✔ 도서관 관리 기능

![5](https://user-images.githubusercontent.com/73989505/144614891-fdb5d6d8-e74a-4e81-80cd-aea52871f2f6.JPG)

 * 도서 현황과 사용자 현황을 출력
 * 현재 총 도서의 수, 총 사용자 수를 출력하고, 대출 중인 도서와 연체 중인 도서를 출력
 * 도서 현황에 출력 되어 있는 도서를 클릭하면 Textbox에 바로 입력되어 대여와 반납 업무를 손쉽게 수행 가능

## ✔ 도서 관리 기능

![6](https://user-images.githubusercontent.com/73989505/144615144-da9d3a57-d497-4041-9205-9b323a438cf4.JPG)

 * 도서를 새로 등록하거나 기존 도서를 수정 및 삭제 할 수 있음


## ✔ 사용자 관리 기능

![7](https://user-images.githubusercontent.com/73989505/144615252-f6be3fba-792c-4d49-a009-982d2949aa92.JPG)

 * 새로운 사용자를 등록, 수정, 삭제 할 수 있음
 * UserID는 숫자만 입력 가능 (숫자가 아닌 문자 입력시 알림 메시지 출력, 텍스트박스 지워짐)
 * Name은 문자 외 숫자는 입력 불가능 (숫자 입력시 문자만 입력하라는 메시지 출력)


## ✔ 비밀번호 수정 기능

![8](https://user-images.githubusercontent.com/73989505/144615295-7604626a-c908-4911-ada6-e2ad892f64d8.JPG)

 * 자신의 비밀번호를 수정할 수 있음
 * 비밀번호 수정 기능 또한 비밀번호 정규식 패턴을 이용하여 변경하려는 비밀번호도 정규식 조건에 맞게 변경 가능하도록 작성
 * 기존 비밀번호와 동일하게 작성될 경우 재설정 알림 메시지 출력

## ✔ 회원 탈퇴 기능

![9](https://user-images.githubusercontent.com/73989505/144615306-a0619c14-8007-4287-8bd7-ca8692c069b2.JPG)

 * 기존 비밀번호를 입력하여 본인 확인 후 회원 탈퇴 수행 가능하도록 작성
 * 기존 비밀번호가 아닌 다른 비밀번호 입력시 재작성 알림 메시지 출력


## ✔ 사용 DB Server 소개

* Firebase를 통한 데이터베이스 관리
```
  // Firebase 연동
  FirebaseConfig fdc = new FirebaseConfig
  {
      AuthSecret = "firebase password",
      BasePath = "https://dominolibraryjoin-default-rtdb.firebaseio.com/"
  };
  
  IFirebaseClient client;
  
  // Clinet 객체에 FirebaseClient 연결, 에러 발생 처리
  try
  {
      client = new FireSharp.FirebaseClient(fdc);
  }
  catch
  {
      MessageBox.Show("오류가 발생했습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
  }
```

