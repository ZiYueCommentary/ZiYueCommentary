package com.ziyue.furniture;

import net.minecraft.entity.EntityType;
import net.minecraft.entity.vehicle.MinecartEntity;
import net.minecraft.world.World;

public class ChairEntity extends MinecartEntity {
    public ChairEntity(EntityType<? extends MinecartEntity> entityType, World world){
        super(entityType, world);
    }
}
