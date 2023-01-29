# FTK_Easy_Targetting

FTK Easy Targetting is a mod that lessens the probability that an enemy will choose to target a weak player because they are weaker than the others.

When an enemy rolls high enough to use a proficiency (item ability), they then roll to see if they use that proficiency's 'tendency' to select an appropriate target.

The tendency's this mod modifies:

- AttackLeastHealth	
- AttackLeastResist
- AttackLeastArmor
- AttackLeastEvade
- AttackHasNoSanctum


The tendency's that this mod does not modify:
- AttackMostHealth
- AttackMostResist
- AttackMostArmor
- AttackMostEvade
- AttackSlowest
- AttackFastest
- AttackMostFocus
- AttackMostGold
- AttackHasSanctum
- AttackMostDamage
- AttackLeastDamage

Even if the probability to not use the modified tendencies is set to 1, the enemy may still randomly roll to attack the weakest player. This mod does NOT forbid attacking the weakest player. It just makes it less likely.