Namespace BattleSystem.Moves.Ghost

    Public Class Astonish

        Inherits Attack

        Public Sub New()
            '#Definitions
            Me.Type = New Element(Element.Types.Ghost)
            Me.ID = 310
            Me.OriginalPP = 15
            Me.CurrentPP = 15
            Me.MaxPP = 15
            Me.Power = 30
            Me.Accuracy = 100
            Me.Category = Categories.Physical
            Me.ContestCategory = ContestCategories.Cute
            Me.Name = Localization.GetString("move_name_" & Me.ID,"Astonish")
            Me.Description = "The user attacks the target while shouting in a startling fashion. This may also make the target flinch."
            Me.CriticalChance = 1
            Me.IsHMMove = False
            Me.Target = Targets.OneAdjacentTarget
            Me.Priority = 0
            Me.TimesToAttack = 1
            '#End

            '#SpecialDefinitions
            Me.MakesContact = True
            Me.ProtectAffected = True
            Me.MagicCoatAffected = False
            Me.SnatchAffected = False
            Me.MirrorMoveAffected = True
            Me.KingsrockAffected = False
            Me.CounterAffected = True

            Me.DisabledWhileGravity = False
            Me.UseEffectiveness = True
            Me.ImmunityAffected = True
            Me.HasSecondaryEffect = True
            Me.RemovesFrozen = False

            Me.IsHealingMove = False
            Me.IsRecoilMove = False

            Me.IsDamagingMove = True
            Me.IsProtectMove = False


            Me.IsAffectedBySubstitute = True
            Me.IsOneHitKOMove = False
            Me.IsWonderGuardAffected = True
            '#End

            Me.AIField1 = AIField.Damage
            Me.AIField2 = AIField.CanFlinch

            Me.EffectChances.Add(30)
        End Sub

        Public Overrides Sub MoveHits(own As Boolean, BattleScreen As BattleScreen)
            Dim substitute As Integer = BattleScreen.FieldEffects.OppSubstitute
            If own = False Then
                substitute = BattleScreen.FieldEffects.OwnSubstitute
            End If

            If substitute = 0 Then
                Dim chance As Integer = GetEffectChance(0, own, BattleScreen)

                If Core.Random.Next(0, 100) < chance Then
                    BattleScreen.Battle.InflictFlinch(Not own, own, BattleScreen, "", "move:astonish")
                End If
            End If
        End Sub

    End Class

End Namespace