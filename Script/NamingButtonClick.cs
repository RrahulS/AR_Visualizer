using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Playables;
using TMPro;

public class NamingButtonClick : MonoBehaviour
{
    [SerializeField] GameObject BottomText, RaycastBlocker, PlantCell, AnimalCell;
    [SerializeField] GameObject[] PlantCellComponent, AnimalCellComponent;
    [SerializeField] string[] AnimalCellInfo, PlantCellInfo, HeartInfo;
    public int index, type;//type 0->Animal cell ,1->Heart ,2->Plant cell
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip[] PlantCellAudio, AnimalCellAudio, HeartAudio;
    [SerializeField] PlayableDirector PlantCelldirector, AnimalCelldirector;
    [SerializeField] PlayableAsset[] PlantCellAsset, AnimalCellAsset;
    [SerializeField] PlayableAsset PlantCellTimeline, AnimalCellTimeline;
    [SerializeField] TextMeshProUGUI TextBox,Heading;

    string[] HeadingtextP = { "Cytoplasm", " Chloroplast" , "Mitochondrion", "Vacuole" , "Cell Wall", "Golgi Apparatus", "Lysosomes", "Endoplasmic Reticulam", "Necleus"};
    string[] HeadingtextA = { "Golgi Apparatus", " Centriole", "Lysosomes", "Endoplasmic Reticulam", "Necleus", "Plasma Membrane ", "Cytoplasm", "Mitochondrion" };
    string[] HeadingtextH = { "Aorta", "Pulmonary Artery" , "Pulmonary Veins", "Left Atrium", "Left Ventrical", "Right Ventrical", "Right Atrium","Vena Cava"};


    void Start()
    {
        BottomText.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -400), 0.5f);
        RaycastBlocker.SetActive(false);
        PlantCell.SetActive(true);
        AnimalCell.SetActive(true);
        PlantCelldirector.playableAsset = PlantCellTimeline;
        AnimalCelldirector.playableAsset = AnimalCellTimeline;
    }
    void SetComponentFalse(bool Bool)
    {
        foreach(GameObject var in PlantCellComponent)
        {
            var.SetActive(Bool);
        }
        foreach (GameObject var in AnimalCellComponent)
        {
            var.SetActive(Bool);
        }
    }
    public void Findtype(int temp)
    {
        if (temp < 10) { index = temp;type = 0;}
        else if(temp>9 && temp < 20) { index = temp-10; type = 1; }
        else { index = temp - 20;type = 2; }
    }
    public void NamingButtonTap(int ind)
    {
        Findtype(ind);
        //print(index);
        RaycastBlocker.SetActive(true);
        if (type == 0) 
        { 
            audiosource.clip = AnimalCellAudio[index];
            AnimalCelldirector.playableAsset = AnimalCellAsset[index];
            AnimalCell.SetActive(false);
            AnimalCelldirector.Play();
            TextBox.text = AnimalCellInfo[index];
            Heading.text = HeadingtextA[index];
        }
        else if (type == 1)
        { 
            audiosource.clip = HeartAudio[index];
            TextBox.text = HeartInfo[index];
            Heading.text = HeadingtextH[index];
        }
        else
        { 
            audiosource.clip = PlantCellAudio[index];
            PlantCelldirector.playableAsset = PlantCellAsset[index];
            PlantCell.SetActive(false);
            PlantCelldirector.Play();
            Heading.text = HeadingtextP[index];
            TextBox.text = PlantCellInfo[index];
        }
        BottomText.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 400), 0.5f);
        audiosource.Play();
    }
    public void PlayAgainButton()
    {
        audiosource.Stop();
        audiosource.Play();
    }
    public void CloseButton()
    {
        BottomText.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -400), 0.5f);
        RaycastBlocker.SetActive(false);
        audiosource.Stop();
        PlantCelldirector.playableAsset = PlantCellTimeline;
        AnimalCelldirector.playableAsset = AnimalCellTimeline;
        PlantCell.SetActive(true);
        AnimalCell.SetActive(true);
        SetComponentFalse(false);
    }
}
