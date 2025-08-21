An auxiliary mod for Hollow Knight, including three modules: BetterLogic, ExtraFeatures, and BugFixes. This can significantly optimize the gaming experience.


#  Instructions

- The dependencies of this mod are Satchel and HKTool, with Satchel version not lower than 0.8.12 and HKTool version not lower than 2.2.0.0.
- All of the following features are configurable in-game. If you are unclear about the relevant functions, it is recommended to keep the default settings.
- Some bugs have been fixed in GodSeekerPlus, so the mod does not fix them to avoid conflicts.
- When using this mod, if you encounter bugs caused by this mod or other bugs that you want to fix, please give me feedback. Bilibili：是柒不是七233, Discord：QiQi7, QQ group：599201137.



#  Features Introduction

##  1.BetterLogic

**The content related to this module is not a malicious bug, but it reflects the design shortcomings. All are on by default.**  

###  Feature list

- **HealthManagerFix**  
  - Description：Fixed damage loss due to frame rate. The invincibility time of enemies after being hit is now always 0.2s, regardless of frame rate.
  - Additional Notes：Turning on this feature will reduce the duration of Descending Dark's third stage by 0.02s to avoid one more damage. It is highly recommended to turn it on.

- **AbyssalShriekOptimization**  
  - Description：The direction of the Abyssal Shriek does not change with the change in the direction of the little knight.

- **HowlingWraithsOptimization**  
  - Description：Optimize the knockback mechanism of the Howling Wraiths to function like the Abyssal Shriek (repulsion to the left and attraction to the right) or to always knock back.

- **DoubleJumpOptimization**  
  - Description：You can use double jump immediately after attacking.

- **WarpOptimization**  
  - Description：This will cause some bosses to stop recoiling after teleporting, including Gorb, Soul Warrior, Elder Hu, and No Eyes.

- **DetectionOptimization**  
  - Description：Added a detection mechanism to some bosses to prevent certain objects from spawning directly on the player, including Hornet Sentinel's Spikes and the Radiance's Orbs.

- **HiveKnightOptimization**  
  - Description：After the death of the Hive Knight, all the Hivelings die。

- **SlyOptimization**  
  - Description：Adjusted Sly's Great Slash hitbox to make it more in line with the texture。



##  二、辅助功能

**该模块提供部分额外的功能，可以用于辅助练习或实战，默认全部关闭。**  

###  功能列表

- **移除冻结帧**  
  - Description：移除玩家受伤以外的所有冻结帧。

- **显示硬直信息**  
  - Description：显示累计硬直数、连击硬直数、连击计时。

- **显示移动目标**  
  - Description：显示除马尔穆以外所有梦境战士的移动目标。

- **两击必杀**  
  - Description：若一次攻击无法击杀敌人则将血量降为1，可以用于测试，在适当的时机击杀BOSS，避免使用debug频繁调整伤害以及使用kill all可能导致的问题。

- **移除前景**  
  - Description：移除收藏家场景内的部分前景。

-------------------------------------------------------------------------------

##  三、bug修复

**该模块相关内容属于恶性bug，体现了设计上的严重失误，可能会明显影响游戏体验，默认全部开启。**  

###  功能列表

- **碰撞修复**  
  - Description：修复若干碰撞相关bug（通常表现为鬼畜、无前摇），如格母卡墙、收藏家平地抓、滚滚无前摇跳滚等等。
  - Additional Notes：该bug是对日常游戏影响最为显著的bug，是极其严重的设计失误，并且对于其他一些bug的修复也依赖于该功能，非常推荐开启。

- **多判修复**  
  - Description：修复连续受伤导致无敌时间丢失的bug。

- **战吼修复**  
  - Description：可以安全的使用菜单卡战吼，收藏家硬直时会取消战吼。

- **卡墙修复**  
  - Description：当部分BOSS碰撞箱与地形有重合时，会平移BOSS以避免其卡到战斗区域之外，包括二见和芬达哥。

- **硬直修复**  
  - Description：修复部分BOSS的硬直bug，包括硬直滑行（表哥、席奥、梦表），硬直立刻起身（席奥、斯莱），芬达哥无法正常打出连击硬直，前辈飞天大草和硬直星爆。

- **动画修复**  
  - Description：修复若干动画导致的卡死bug，如卡战吼下砸升天、大师p2卡死等等。
  - 补充说明：属于严重的设计失误，推荐开启（关闭后需重进存档才能生效）。

- **随机选择修复**  
  - Description：修复战斗时间较长的情况下BOSS出招异常的bug，如收藏家一波三古神、辐光p2连续横刺。
  - Additional Notes：属于严重的设计失误，但是对日常影响较小，推荐开启。

- **物品回收修复**  
  - Description：修复切换场景时召唤的物体不能正确回收的bug，如辐光光剑残留。
  - Additional Notes：属于严重的设计失误，但是对日常影响较小，推荐开启。

- **无敌状态修复**  
  - Description：修复特定操作可以使小骑士卡上无敌状态的bug。

- **假骑士修复**  
  - Description：修复假骑士的已知bug，包括地波大小异常。

- **草团子修复**  
  - Description：修复草团子的已知bug，包括提前遁地。

- **一见修复**  
  - Description：修复一见的已知bug，包括低空斜冲。

- **芬达哥修复**  
  - Description：修复芬达哥的已知bug，包括落地后水平位移、p2特殊钻地保留。

- **双师傅修复**  
  - Description：修复双师傅的已知bug，包括奥罗冲刺斩会与各种攻击拼刀、马托在奥罗冲刺斩时不格挡、在另一位师傅仍在攻击时就释放剑技（逻辑之外的剑技）、p2剑技完全消失。

- **波波修复**  
  - Description：修复波波的已知bug，包括灵车漂移。

- **三螳螂修复**  
  - Description：修复三螳螂的已知bug，包括螳螂领主左横冲刷脸、战斗姐妹p2结束后（进入两只螳螂的阶段）可能立刻进行攻击。

- **马尔穆修复**  
  - Description：修复马尔穆的已知bug，包括急停霸体和反弹霸体。

- **虫母修复**  
  - Description：修复虫母的已知bug，包括死亡后小吸虫不消失。

- **收藏家修复**  
  - Description：修复收藏家的已知bug，包括滚滚量子纠缠、蚊子霸体、蚊子虚空碰撞箱。

- **有翼诺斯克修复**  
  - Description：修复有翼诺斯克的已知bug，包括倒车。

- **二见修复**  
  - Description：修复二见的已知bug，包括低空斜冲、斜冲卡墙、无前摇冲刺。

- **白芬达修复**  
  - Description：修复白芬达的已知bug，包括落地后水平位移。

- **前辈修复**  
  - Description：修复前辈的已知bug，包括免疫吸虫、地刺残留。

- **辐光修复**  
   Description：修复辐光的已知bug，包括光球残留碰撞箱、自缚、剑雨残留、p4光球残留。

-------------------------------------------------------------------------------

