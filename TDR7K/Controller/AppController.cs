using AutoItX3Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TDR7K.Class;
using TDR7K.Model;

namespace TDR7K.Controller
{
    public class AppController
    {
        AutoItX3 au3 = new AutoItX3();
        IView _view;
      
       
        public AppController(IView view)
        {
            _view = view;
            view.SetController(this);
        }

        public void WhatScene()
        {
            var color = "";
            for (var i = 0; i < 50; i++)
            {
                Thread.Sleep(1999);
                color = PixelColor.Get(614, 579);
                GetScene(color, "D5BA7F", "Scene:Destroyer Gaze", 950, 604, "", "S", "", "", "");
                color = PixelColor.Get(671, 94);
                GetScene(color, "0F0E06", "Scene:Raid Lobby", 54, 63, "", "S", "", "", "");
                color = PixelColor.Get(1116, 34);
                color = PixelColor.Get(172, 554);
                GetScene(color, "FEE771", "Scene:Select Map", 528, 632, "", "S", "", "", "");
                color = PixelColor.Get(797, 582);
                GetScene(color, "1E9D76", "Scene:Select Map:Mystic Wood", 543, 657, "", "S", "", "", "");
                color = PixelColor.Get(222, 518);
                GetScene(color, "DACECE", "Scene:Goddess Elena Monster Got LV30", 1059, 598, "Scene:Goddess Elena Monster Got LV30:OK", "C", "", "", "");
                color = PixelColor.Get(701, 167);
                GetScene(color, "FCF2D2", "Scene:Reward", 0, 0, "", "S", "", "", "");
                color = PixelColor.Get(348, 594);
                GetScene(color, "F4D99B", "Scene:ManageHeroes", 0, 0, "", "C", "", "", "");
                //Go to battle
                color = PixelColor.Get(934, 641);
                GetScene(color, "FA826B", "Scene:ManageRoom", 934, 641, "", "B", "", "", "");
                color = PixelColor.Get(951, 600);
                GetScene(color, "593D1D", "Scene:Dropinfo", 950, 604, "Scene:Dropinfo:Menu:Quick Start", "B", "", "", "");
                color = PixelColor.Get(0, 0);
                GetScene(color, "533B1F", "Scene:Battle", 0, 0, "", "B", "533A1F", "543C20", "533A1C");
            }
        }
        public void IntoAdvBattle()
        {
            GetAdvBattleWave("EDE5EE", 541, 46, 1, 0);
            GetAdvBattleWave("484657", 615, 57, 2, 1);
            GetAdvBattleWave("F8F2F9", 683, 47, 3, 2);
        }

        //Helper///
        private void GetScene(string color, string GetColor, string msg, int x, int y, string msg2, string Goto, string color2, string color3, string color4)
        {
            if (color == GetColor)
            {
                _view.AddMsgToRichText(msg);
                GameClick(x, y);
                if (msg2 != "")
                {
                    _view.AddMsgToRichText(msg);
                }
                if (Goto == "B")
                {
                    IntoAdvBattle();
                }
                if (Goto == "S")
                {
                    WhatScene();
                }
                if (Goto == "C")
                {
                    ChangeMonster();
                }
            }
        }
        private void ChangeMonster()
        {
            //GameClick(252, 675);
            SortedMonster();
            //var changed = SameHeroes();
            var lvmax = FindMonsterLVmax();
            foreach(var item in lvmax)
            {
                if(item.PixelMark1 == item.ColorMark1 && item.PixelMark2 == item.ColorMark2 &&item.PixelMark3 == item.ColorMark3)
                {
                    ChooseMonster();
                    GameClick(133, 232);
                    _view.AddMsgToRichText("Changed Heroes "+ item.MonsterNO);
                }
                Thread.Sleep(999);
            }
        }
        private void SortedMonster()
        {
            var color = "";
            color = PixelColor.Get(1084, 130);
            if(color != "AC7962")
            {
                GameClick(1084, 130);
            }
        }
        private void ChooseMonster()
        {
            Thread.Sleep(450);
            var joined =  Isjoined();
            var indexmon =  IndexListMonster();
            int FailedCount = 0;
            for (var i = 0; i < indexmon.Count();i++ )
            {
                var GetjoinedColor = PixelColor.Get(joined[i].Xpont,joined[i].YPoint);
                if (joined[i].Color != GetjoinedColor)
                {
                    GameClick(indexmon[i].Xpont, indexmon[i].YPoint);
                    Thread.Sleep(450);
                    GameClick(1036, 624);
                    var failed = PixelColor.Get(560, 517);
                    if (failed == "F7A300")
                    {
                        FailedCount = FailedCount + 1;
                        GameClick(544, 503);
                    }
                    if(FailedCount == 8)
                    {

                    }
                }
            }
            
            
        }
        private void GetAdvBattleWave(string GetColor, int x, int y, int wave, int skill)
        {
            Thread.Sleep(999);
            var color = "";
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(999);
                color = PixelColor.Get(x, y);
                if (color == GetColor)
                {
                    var msg = "Scene:Battle:Wave" + wave;
                    _view.AddMsgToRichText(msg);
                    UsingSkill(skill);
                    break;
                }
            }
        }
        private void UsingSkill(int mark)
        {
            var pos = MarkPoint.SkillMark();
            var wave = mark + 1;
            GameClick(pos[mark].x, pos[mark].y);
            _view.AddMsgToRichText("Scene:Battle:Wave " + wave + " using Skill");
        }
        private void GameClick(int sX, int sY)
        {
            au3.ControlClick("BlueStacks App Player", "", "", "left", 1, sX, sY);
        }
        private List<MonsterLvmaxPixelMark> FindMonsterLVmax()
        {
            var monmark = new List<MonsterLvmaxPixelMark>();
            monmark.Add(new MonsterLvmaxPixelMark
            {
                MonsterNO = 1,
                PixelMark1 = PixelColor.Get(156, 247),
                PixelMark2 = PixelColor.Get(159, 251),
                PixelMark3 = PixelColor.Get(156, 256),
                ColorMark1 = "DEB31D",
                ColorMark2 = "FAB913",
                ColorMark3 = "F89C09"

            });
            monmark.Add(new MonsterLvmaxPixelMark
            {
                MonsterNO = 2,
                PixelMark1 = PixelColor.Get(156, 421),
                PixelMark2 = PixelColor.Get(159, 424),
                PixelMark3 = PixelColor.Get(156, 429),
                ColorMark1 = "D68803",
                ColorMark2 = "F5BC15",
                ColorMark3 = "F09B0A"
            });
            monmark.Add(new MonsterLvmaxPixelMark
            {
                MonsterNO = 3,
                PixelMark1 = PixelColor.Get(156, 593),
                PixelMark2 = PixelColor.Get(159, 597),
                PixelMark3 = PixelColor.Get(156, 602),
                ColorMark1 = "DEB51E",
                ColorMark2 = "FCBD14",
                ColorMark3 = "F69B09"
            });
            return monmark;
        }
        private List<SameHeroes> IsChangeHeroes()
        {

            var herosame = new List<SameHeroes>();
            herosame.Add(new SameHeroes
            {
              color1 = PixelColor.Get(131,168),
              color2 = PixelColor.Get(130,345),
              color3 = PixelColor.Get(143, 251),
              color4 = PixelColor.Get(250, 254),
              color5 = PixelColor.Get(253, 433)
            });
            return herosame;
        }
        private List<ListMonster> IndexListMonster()
        {
            int[,] monlist = new int[,] { { 471, 259 }, { 647, 263 }, { 843, 267 }, { 1042, 274 }, { 483, 507 }, { 676, 571 }, { 846, 522 }, { 1040, 518 } };
            var ListMon = new List<ListMonster>();
            for (var i = 0; i < 9;i++ )
            {
                ListMon.Add(new ListMonster
                {
                    MonsterNO = i+1,
                    Xpont = monlist[i,0],
                    YPoint = monlist[i,1]
                });
            }
                return ListMon;
        }
        private List<ListMonsterJoined> Isjoined()
        {
            var Joined = new List<ListMonsterJoined>();
            int[,] Isjoined = new int[,] { { 457, 182 }, { 645, 182 }, { 832, 182 }, { 1019, 182 }, { 455, 439 }, { 645, 439 }, { 833, 439 }, { 1018, 439 } };
            string [] Iscolor = new string[]
            {
                "DFC583","DFC583","DFC380","DFC583","DFC380","DFC380","DFC380","DFC380"
            };
            for (var e = 0; e < 9; e++)
            {
                Joined.Add(new ListMonsterJoined
                    {
                        MonsterNO = e+1,
                        Xpont = Isjoined[e,0],
                        YPoint = Isjoined[e,1],
                        Color = Iscolor[e]
                    });
            }
            
            


            return Joined;
        }
    }
}
