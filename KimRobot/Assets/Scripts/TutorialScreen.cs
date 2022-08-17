using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour
{
    public Text TutoText;
    public GameObject Next, Undo;
    public int index=0;

    string[] Tutorialtext = { "����� ���� ���ӿ� ���� �ֽ��ϴ�.",
    "������ ����� ã�� �̰��� ������������.",
    "���ѽð� �ȿ� Ż������ ���ϸ� ����� �̰��� ������ �������� �� �����ϴ�.",
    "�����ð��� ����� ���� �ո� �ֽ��ϴ�.",
    "�̰��� ����� ������ Ư���� ������ �ֽ��ϴ�.",
    "�� �ѿ� ������ �����ϰ� �Ǹ� ���������� �� �� �ֽ��ϴ�.",
    "����, �ʷ��� �ݻ�Ǵ� ����, �׸��� �� ���� ���� ������� Ư���� �ɷ��� ������",
    "�ش� ����Ű�� ���� ���ϴ� ���� �߻��� �� �ֽ��ϴ�.",
    "å�� ���� �ִ� �Ѱ� ������ �������.",
    "���� �� ������ ����ִ� ��ũ��â�� Ȱ��ȭ ��ų �� �ֽ��ϴ�.",
    "����� ��� �ӿ��� ���� ������ ����� �����ΰ���?",//������ ��� ����
    "���� ����� ������ ������� ����� �鿩�� �� �� �ֽ��ϴ�.",
    "���ϴ� ������ ��ġ�Ͽ�, ����� �鿩�� ������.",
    "������ ���ư��� �ڸ��� ������ ���� ��ų �� �ֽ��ϴ�.",
    "������ �� �鿩�� ���̳���?",
    "�׷��ٸ� ����, ����� ���� �� ���� ���Դϴ�.",
    "���� ���� �� ���ڸ� ������� �Է��ϼ���.",
    "�ٸ� ������ ã�Ҵٸ� ����� � ��ü�� ���÷� �� ������ �������� �� �ֽ��ϴ�.",
    "������ ������� ����, ���ѷ� �̰��� ���������ʽÿ�."};
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
