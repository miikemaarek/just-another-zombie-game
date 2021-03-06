﻿/**
* PlayerBaseState.cs
* Created by Michael Marek (2016)
*
* Default player state when not interacting with anything or performing any actions.
**/

using UnityEngine;
using System.Collections;

public class PlayerBaseState : ActorState
{
    private PlayerInputComponent        input;
    private PlayerMovementComponent     movement;
    private PlayerInteractableComponent interact;
    private PlayerEquipmentComponent    equipment;
    private InventoryComponent          inventory;
    private ProgressComponent           progress;

    /**
    **/
    public override ActorState HandleInput(GameObject parent)
    {
        if (input._Sprint)
            return new PlayerSprintingState();

        if (input._Interact)
            if (interact.WithinReach())
                return new PlayerInteractionState();

        if (input.Inventory && inventory.allowUse)
            return new PlayerManageInventoryState();

        if (input._Hotswap)
            return new PlayerHotswapState();

        if (input._Reload)
            return new PlayerReloadState();

        return null;
    }

    /**
    **/
    public override void Update(GameObject parent)
    {
    }

    /**
    **/
    public override void Initialize(GameObject parent)
    {
        input = parent.GetComponent<PlayerInputComponent>();
        movement = parent.GetComponent<PlayerMovementComponent>();
        interact = parent.GetComponent<PlayerInteractableComponent>();
        equipment = parent.GetComponent<PlayerEquipmentComponent>();
        inventory = parent.GetComponent<InventoryComponent>();
        progress = parent.GetComponent<ProgressComponent>();
    }

    /**
    **/
    public override void OnEnter(GameObject parent)
    {
        movement.allowMovement = true;
        movement.allowAiming = true;

        interact.allowInteraction = true;

        equipment.allowItemUse = true;

        progress.Reset();
    }

    /**
    **/
    public override void OnExit(GameObject parent)
    {
    }
}
