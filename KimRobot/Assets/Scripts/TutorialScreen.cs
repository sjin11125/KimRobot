using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour
{
    public Text TutoText;
    public GameObject Next, Undo;
    public int index=0;

    string[] Tutorialtext = { "당신은 지금 기억속에 갇혀 있습니다.",
    "소중한 기억을 찾아 이곳을 빠져나가세요.",
    "제한시간 안에 탈출하지 못하면 당신은 이곳을 영원히 빠져나갈 수 없습니다.",
    "남은시간은 당신의 왼쪽 손목에 있습니다.",
    "이곳엔 당신을 도와줄 특별한 도구가 있습니다.",
    "이 총에 원석을 장착하게 되면 레이저건을 쏠 수 있습니다.",
    "빨강, 초록은 반사되는 성질, 그리고 두 색이 섞인 노란색은 특별한 능력이 있으며",
    "해당 조작키를 통해 원하는 색을 발사할 수 있습니다.",
    "책상 옆에 있는 총과 원석을 집어보세요.",
    "이제 이 총으로 잠겨있는 스크린창을 활성화 시킬 수 있습니다.",
    "당신의 기억 속에서 가장 소중한 사람은 누구인가요?",//레이저 쏘기 연인
    "이제 당신은 소중한 사람과의 기억을 들여다 볼 수 있습니다.",
    "원하는 사진을 터치하여, 기억을 들여다 보세요.",
    "앞으로 나아가는 자만이 소중한 것을 지킬 수 있습니다.",
    "기억속은 잘 들여다 보셨나요?",
    "그렇다면 이제, 당신은 답할 수 있을 것입니다.",
    "다음 별에 들어갈 숫자를 순서대로 입력하세요.",
    "다른 원석을 찾았다면 당신은 어떤 물체를 들어올려 이 공간을 빠져나갈 수 있습니다.",
    "기억들이 사라지기 전에, 서둘러 이곳을 빠져나가십시오."};
    private void Update()
    {
        TutoText.text = Tutorialtext[index]; 
        if (index>= Tutorialtext.Length)
        {
            Next.SetActive(false);
        }
        if (index==0)
        {
            Undo.SetActive(false);
        }
        if (index < Tutorialtext.Length&&index>0)
        {

            Next.SetActive(true);
            Undo.SetActive(true);
        }
    }
    public void NextText()
    {
        index++;
        //TutoText.text = Tutorialtext[index];
    }
    public void UndoText()
    {
        index--;
        //TutoText.text = Tutorialtext[index];
    }

}
