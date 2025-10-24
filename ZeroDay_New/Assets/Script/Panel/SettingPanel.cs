using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingPanel : PanelBase
{
   public Button closeButton;
   public Button ExitButton;

   public Slider BGMSlider;

   public Slider SoundSlider;

   private void Start()
   {
      closeButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      ExitButton.onClick.AddListener(() =>
      {
         SaveDataController.SaveData();
         SceneManager.LoadSceneAsync(0);
      });
   }
   private void OnEnable()
   {
      BGMSlider.value = DataManager.userData.BGMVolume;
      SoundSlider.value = DataManager.userData.SoundVolume;
   }

   public void OnMusicSliderChangeValue()
   {
      DataManager.userData.BGMVolume = BGMSlider.value;
      SaveDataController.SaveData();
      EventManager.Send(new EventConst.ChangeMusicVolume() { });
   }

   public void OnSoundSliderChangeValue()
   {
      DataManager.userData.SoundVolume = SoundSlider.value;
      SaveDataController.SaveData();
      EventManager.Send(new EventConst.ChangeSoundVolume() { });
   }

}
