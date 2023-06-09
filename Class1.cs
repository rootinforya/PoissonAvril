﻿using Neuron.Core.Plugins;
using Synapse3.SynapseModule;
using System;
using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using PlayerRoles;
using Synapse3.SynapseModule.Command;
using Neuron.Core.Events;
using Synapse3.SynapseModule.Events;
using MEC;
using System.Collections.Generic;
using Synapse3.SynapseModule.Map.Schematic;
using UnityEngine;
using Synapse3.SynapseModule.Map.Rooms;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Player;
using Synapse3.SynapseModule.Map.Objects;

namespace PoissonAvril
{
    [Plugin(
        Author = "rootinforya",
        Description = "Adds april fools stuff",
        Name = "PoissonAvril",
        Version = "1.0.0"
    )]
    public class PoissonAvril : ReloadablePlugin
    {
    }

    [Automatic]
    public class EventHandler : Listener
    {
        private SynapsePlayer moaiPlayer = null;
        public SynapseSchematic Platypus1 { get; set; }
        public SynapseSchematic Platypus2 { get; set; }
        public SynapseSchematic Platypus3 { get; set; }
        public SynapseSchematic Platypus4 { get; set; }
        public SynapseSchematic Platypus5 { get; set; }
        public SynapseSchematic Platypus6 { get; set; }
        public SynapseSchematic Platypus7 { get; set; }
        public SynapseSchematic Platypus8 { get; set; }
        public SynapseSchematic Platypus9 { get; set; }
        public SynapseSchematic Platypus10 { get; set; }
        public SynapseSchematic Platypus11 { get; set; }
        public SynapseSchematic Moai { get; set; }
        private bool isThere173 = false;

        [EventHandler]
        public void OnRoundStart(RoundStartEvent ev)
        {
            Timing.CallDelayed(0.02f, () =>
            {
                moaiPlayer = null;
                isThere173 = false;
                Platypus1 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("Scp173", new Vector3(6.5f, 12.5f, 12), Vector3.zero).GetMapPosition());
                Platypus2 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("LczCheckpointA", new Vector3(3.5f, 2, 5.5f), Vector3.zero).GetMapPosition());
                Platypus3 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("LczCheckpointB", new Vector3(-3, 2, 6), Vector3.zero).GetMapPosition());
                Platypus4 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("Servers", new Vector3(0, 0, 0), Vector3.zero).GetMapPosition());
                Platypus5 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("LightArmory", new Vector3(1.5f, 1, 0), Vector3.zero).GetMapPosition());
                Platypus6 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("GateB", new Vector3(-5.5f, 1.2f, 0), Vector3.zero).GetMapPosition());
                Platypus7 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("Scp372", new Vector3(5.5f, 1, 4), Vector3.zero).GetMapPosition());
                Platypus8 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("Surface", new Vector3(128, -10, 20), Vector3.zero).GetMapPosition());
                Platypus9 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("Surface", new Vector3(38, 1.4f, -36), Vector3.zero).GetMapPosition());
                Platypus10 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("MicroHid", new Vector3(-5.5f, 1, -4.5f), Vector3.zero).GetMapPosition());
                Platypus11 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("Toilets", new Vector3(-3.5f, 1, -6), Vector3.zero).GetMapPosition());
                Moai = Synapse.Get<SchematicService>().SpawnSchematic(102, new RoomPoint("Scp173", new Vector3(18, 11.5f, 8), Vector3.zero).GetMapPosition());
                Moai.Scale = new Vector3(-1, -1, -1);

                foreach (SynapsePlayer player in Synapse.Get<PlayerService>().Players)
                {
                    if (player.RoleType == RoleTypeId.Scp173)
                    {
                        moaiPlayer = player;
                        Moai.HideFromPlayer(moaiPlayer);
                        isThere173 = true;
                    }
                }
                if (!isThere173)
                {
                    foreach (SynapsePlayer player in Synapse.Get<PlayerService>().Players)
                    {
                        if (player.TeamID == (uint)Team.SCPs)
                        {
                            moaiPlayer = player;
                            player.RoleID = (uint)RoleTypeId.Scp173;
                            Moai.HideFromPlayer(moaiPlayer);
                            isThere173 = true;
                            break;
                        }
                    }
                }
                Platypus1.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus2.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus3.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus4.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus5.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus6.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus7.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus8.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus9.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus10.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus11.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            });
        }

        [EventHandler]
        public void OnUpdate(UpdateEvent ev)
        {
            moaiPlayer.GiveEffect(Synapse3.SynapseModule.Enums.Effect.Invisible);
            moaiPlayer.GiveEffect(Synapse3.SynapseModule.Enums.Effect.Invigorated);
            Moai.Position = moaiPlayer.Position + new Vector3(0, 0.25f, 0);
            Moai.Rotation = Quaternion.Euler(180, moaiPlayer.RotationHorizontal - 90, 0);
        }

        [EventHandler]
        public void OnRespawn(SpawnTeamEvent ev)
        {
            if (ev.TeamId == (uint)Team.ChaosInsurgency)
            {
                foreach (SynapsePlayer player in ev.Players)
                {
                    player.FakeRoleManager.VisibleRole.RoleTypeId = RoleTypeId.ChaosRifleman;
                }
            }
            else
            {
                foreach (SynapsePlayer player in ev.Players)
                {
                    player.FakeRoleManager.VisibleRole.RoleTypeId = RoleTypeId.NtfSergeant;
                }
            }
        }

        [EventHandler]
        public void OnDeath(DeathEvent ev)
        {
            ev.Player.FakeRoleManager.Reset();
            if (ev.Player == moaiPlayer)
            {
                moaiPlayer = null;
                Moai.Destroy();
            }
        }
    }
}
