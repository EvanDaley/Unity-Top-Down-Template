using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rito.RadialMenu_v3.Test
{
    public class RadialMenuController : MonoBehaviour
    {
            public RadialMenu topLevelMenu;
            public RadialMenu constructionMenu;
            public RadialMenu weaponMenu;

            public KeyCode key = KeyCode.Mouse1;

            [Space]
            public Sprite[] topLevelMenuSprites;
            public Sprite[] constructionMenuSprites;
            public Sprite[] weaponMenuSprites;

            private void Start()
            {
                topLevelMenu.SetPieceImageSprites(topLevelMenuSprites);
                constructionMenu.SetPieceImageSprites(constructionMenuSprites);
                weaponMenu.SetPieceImageSprites(weaponMenuSprites);
            }

            private void Update()
            {
                if (Input.GetKeyDown(key))
                {
                    topLevelMenu.Show();
                }
                else if (Input.GetKeyUp(key))
                {
                    topLevelMenu.Hide();
                    constructionMenu.Hide();
                }
            }

            // TODO: Think of a way to generalize this so we don't have to hardcode the menu names
            public void ExecuteSelection(RadialMenu menu)
            {
                Debug.Log(menu);
                Debug.Log(menu.GetSelectedIndex());
                if (menu == topLevelMenu)
                {
                    if (menu.GetSelectedIndex() == 0)
                    {
                        OpenMenu("Weapon");
                    }

                    if (menu.GetSelectedIndex() == 1)
                    {
                        OpenMenu("Construction");
                    }
                }
            }

            public void OpenMenu(string menuName)
            {
                Debug.Log("Opening menu: " + menuName);
                if (menuName == "Construction")
                {
                    constructionMenu.Show();
                }

                if (menuName == "Weapon")
                {
                    weaponMenu.Show();
                }
            }
    }
}